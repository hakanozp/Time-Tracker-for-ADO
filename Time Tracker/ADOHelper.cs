using Microsoft.TeamFoundation.WorkItemTracking.WebApi.Models;
using Microsoft.TeamFoundation.WorkItemTracking.WebApi;
using Microsoft.VisualStudio.Services.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;
using Microsoft.VisualStudio.Services.WebApi;
using Microsoft.TeamFoundation.Core.WebApi;
using Microsoft.CodeAnalysis;
using Microsoft.TeamFoundation.Work.WebApi;
using System.Net.Http;
using Microsoft.TeamFoundation.Core.WebApi.Types;
using Microsoft.VisualStudio.Services.WebApi.Patch.Json;
using JsonPatchDocument = Microsoft.VisualStudio.Services.WebApi.Patch.Json.JsonPatchDocument;
using Microsoft.VisualStudio.Services.WebApi.Patch;
using System.Numerics;
using System.Web;

namespace TimeTracker
{
    public class ADOHelper
    {
        public string Organization { get; set; }
        public string Project { get; set; }
        public string PersonalAccessToken { get; set; }
        public string OrganizationUrl { get; set; }
        //public int ItemId { get; set; }

        public async Task<System.Collections.Generic.IList<WorkItem>> GetItemList(string itemType, string areaPath = "", string state = "", bool assignedToMe = false)
        {

            string query = "Select [Id] " +
                                "From WorkItems " +
                                "Where [Work Item Type] = '" + itemType + "' " +
                                    "And [System.TeamProject] = '" + Project + "' ";

            if (areaPath != "")
            {
                query += "And [System.AreaPath] = '" + areaPath + "' ";
            }
            if (state == "")
            {
                query += "And [System.State] NOT IN ('Closed', 'Removed', 'Resolved')";
            }
            else
            {
				query += "And [System.State] = '" + state + "' ";
			}

            if (assignedToMe)
            {
                query += "and [System.AssignedTo] = @me ";
            }

            query += "Order By [ID] Asc";

            // create a wiql object and build our query
            var wiql = new Wiql()
            {
                // NOTE: Even if other columns are specified, only the ID & URL are available in the WorkItemReference
                Query = query,
            };

            Uri uri = new Uri(OrganizationUrl);
            var credentials = new VssBasicCredential(string.Empty, PersonalAccessToken);

            try
            {
                // create instance of work item tracking http client
                using (var httpClient = new WorkItemTrackingHttpClient(uri, credentials))
                {
                    // execute the query to get the list of work items in the results
                    var result = await httpClient.QueryByWiqlAsync(wiql).ConfigureAwait(false);
                    var ids = result.WorkItems.Select(item => item.Id).ToArray();

                    // some error handling
                    if (ids.Length == 0)
                    {
                        return Array.Empty<WorkItem>();
                    }

                    // build a list of the fields we want to see
                    var fields = new[] { "System.Id", "System.Title", "System.State", "System.AreaPath" };

                    // get work items for the ids found in query
                    return await httpClient.GetWorkItemsAsync(ids, fields, result.AsOf).ConfigureAwait(false);
                    
                }
            }
            catch (Exception exc)
            {
                MessageBox.Show(exc.Message);
                return Array.Empty<WorkItem>();
            }
        }

        private async Task<System.Collections.Generic.IList<WorkItem>> _GetItemInfo(int itemId)
        {

            string query = "Select [Id] " +
                                "From WorkItems " +
                                "Where [System.Id] = '" + itemId.ToString() + "' ";

            // create a wiql object and build our query
            var wiql = new Wiql()
            {
                // NOTE: Even if other columns are specified, only the ID & URL are available in the WorkItemReference
                Query = query,
            };

            Uri uri = new Uri(OrganizationUrl);
            var credentials = new VssBasicCredential(string.Empty, PersonalAccessToken);

            try
            {
                // create instance of work item tracking http client
                using (var httpClient = new WorkItemTrackingHttpClient(uri, credentials))
                {
                    // execute the query to get the list of work items in the results
                    var result = await httpClient.QueryByWiqlAsync(wiql).ConfigureAwait(false);
                    var ids = result.WorkItems.Select(item => item.Id).ToArray();

                    // some error handling
                    if (ids.Length == 0)
                    {
                        return Array.Empty<WorkItem>();
                    }

                    // build a list of the fields we want to see
                    var fields = new[] { "System.Id", "System.WorkItemType", "System.Title", "System.State", "System.AreaPath", "System.IterationPath", "System.Tags", "Microsoft.VSTS.Scheduling.CompletedWork" };

                    // get work items for the ids found in query
                    return await httpClient.GetWorkItemsAsync(ids, fields, result.AsOf).ConfigureAwait(false);

                }
            }
            catch (Exception exc)
            {
                MessageBox.Show(exc.Message);
                return Array.Empty<WorkItem>();
            }
        }

        public async Task<string> GetItemTags(int itemId)
        {
            string tags = string.Empty;

            if (itemId > 0) 
            {
                var workItems = await _GetItemInfo(itemId);

                if (workItems[0].Fields.ContainsKey("System.Tags"))
                {
                    tags = (string)workItems[0].Fields["System.Tags"];
                }
            }
            return tags;
        }


        public Dictionary<Guid, string> GetProjectList()
        { 
            Dictionary<Guid, string> projectList = new Dictionary<Guid, string>();

            VssConnection connection = new VssConnection(new Uri(OrganizationUrl), new VssBasicCredential(string.Empty, PersonalAccessToken));

            // Get the project ID
            var projectHttpClient = connection.GetClient<ProjectHttpClient>();
            var projects = projectHttpClient.GetProjects().Result;

            foreach (TeamProjectReference project in projects)
            {
                if (project.Name == "PBI_DS")
                    projectList.Add(project.Id, project.Name);
            }

            return projectList;
        }

        public List<String> GetBoardList(Guid projectId) 
        {
            List<String> boardList = new List<String>();

            VssConnection connection = new VssConnection(new Uri(OrganizationUrl), new VssBasicCredential(string.Empty, PersonalAccessToken));

            TeamHttpClient teamClient = connection.GetClient<TeamHttpClient>();
            List<WebApiTeam> teams = teamClient.GetTeamsAsync(projectId.ToString()).Result;
            teams = teams.OrderBy(t => t.Name).ToList();

            boardList.Add("");
            foreach (WebApiTeam team in teams)
            {
                boardList.Add(team.Name);
            }
            
            return boardList;
        }

        public List<String> GetIterationList(Guid projectId) 
        {
            List<String> iterationList = new List<String>();

            VssConnection connection = new VssConnection(new Uri(OrganizationUrl), new VssBasicCredential(string.Empty, PersonalAccessToken));

            WorkHttpClient workClient = connection.GetClient<WorkHttpClient>();
            TeamContext tc = new TeamContext(projectId);
            tc.Team = "PBI_DS";

            
            List<TeamSettingsIteration> teamSettings = workClient.GetTeamIterationsAsync(tc).Result;
            teamSettings = teamSettings.OrderBy(t => t.Path).ToList();

            iterationList.Add("");
            foreach (TeamSettingsIteration teamSetting in teamSettings)
            {
                iterationList.Add(teamSetting.Path);
            }

            return iterationList;
        }

        public int CreateTask(ADOTask newEntry)
        {
            int itemId = 0;

            using (HttpClient client = new HttpClient())
            {

                VssBasicCredential credentials = new VssBasicCredential("", PersonalAccessToken);
                JsonPatchDocument patchDocument = new JsonPatchDocument();

                Uri uri = new Uri(OrganizationUrl);

                patchDocument.Add(new JsonPatchOperation()
                {
                    Operation = Operation.Add,
                    Path = "/fields/System.AssignedTo",
                    Value = newEntry.AssignedTo
                }
                                  );

                patchDocument.Add(new JsonPatchOperation()
                {
                    Operation = Operation.Add,
                    Path = "/fields/System.Title",
                    Value = newEntry.Title
                }
                                  );
                patchDocument.Add(new JsonPatchOperation()
                {
                    Operation = Operation.Add,
                    Path = "/fields/System.Description",
                    Value = newEntry.Description
                }
                                  );

                patchDocument.Add(new JsonPatchOperation()
                {
                    Operation = Operation.Add,
                    Path = "/fields/System.State",
                    Value = newEntry.State
                }
                                  );

                patchDocument.Add(new JsonPatchOperation()
                {
                    Operation = Operation.Add,
                    Path = "/fields/System.IterationPath",
                    Value = newEntry.IterationPath
                }
                                  );
                patchDocument.Add(new JsonPatchOperation()
                {
                    Operation = Operation.Add,
                    Path = "/fields/System.AreaPath",
                    Value = newEntry.AreaPath
                }
                                  );

                patchDocument.Add(new JsonPatchOperation()
                {
                    Operation = Operation.Add,
                    Path = "/fields/Microsoft.VSTS.Scheduling.StartDate",
                    Value = newEntry.StartDate.ToString("yyyy-MM-ddTHH:mm:ssZ")
                }
                                  );
                patchDocument.Add(new JsonPatchOperation()
                {
                    Operation = Operation.Add,
                    Path = "/fields/Microsoft.VSTS.Scheduling.TargetDate",
                    Value = newEntry.TargetDate.ToString("yyyy-MM-ddTHH:mm:ssZ")
                }
                                  );
                patchDocument.Add(new JsonPatchOperation()
                {
                    Operation = Operation.Add,
                    Path = "/fields/Microsoft.VSTS.Scheduling.OriginalEstimate",
                    Value = newEntry.OriginalEstimate
                }
                                  );

                patchDocument.Add(new JsonPatchOperation()
                {
                    Operation = Operation.Add,
                    Path = "/fields/Microsoft.VSTS.Scheduling.CompletedWork",
                    Value = newEntry.CompletedWork
                }
                                  );

                patchDocument.Add(new JsonPatchOperation()
                {
                    Operation = Operation.Add,
                    Path = "/fields/System.Tags",
                    Value = newEntry.Tags
                }
                  );

                patchDocument.Add(new JsonPatchOperation()
                {
                    Operation = Operation.Add,
                    Path = "/fields/System.History",
                    Value = newEntry.History
                }
                );

                patchDocument.Add(new JsonPatchOperation()
                {
                    Operation = Operation.Add,
                    Path = "/fields/Custom.AccountType",
                    Value = newEntry.WBS
                }
                );

                string rel_url = string.Format("{0}/{1}/_apis/wit/workitems/{2}", OrganizationUrl, Project, newEntry.ParentId);

                patchDocument.Add(new JsonPatchOperation()
                {
                    Operation = Operation.Add,
                    Path = "/relations/-",
                    Value = new
                    {
                        rel = "System.LinkTypes.Hierarchy-Reverse",
                        url = rel_url
                    }
                }
                                  );

                VssConnection connection = new VssConnection(uri, credentials);
                WorkItemTrackingHttpClient workItemTrackingHttpClient = connection.GetClient<WorkItemTrackingHttpClient>();

                WorkItem result = workItemTrackingHttpClient.CreateWorkItemAsync(patchDocument, Project, newEntry.ItemType).Result;
                itemId = (int)result.Id;

                //try
                //{
                //    WorkItem result = workItemTrackingHttpClient.CreateWorkItemAsync(patchDocument, Project, newEntry.ItemType).Result;
                //    //MessageBox.Show("Task Successfully Created: Task #" + result.Id.ToString());
                //    itemId = (int)result.Id;
                //}
                //catch (AggregateException ex)
                //{
                //    itemId = 0;
                //    MessageBox.Show(ex.InnerException.Message);
                //}
            }

            return itemId;
        }

        public int CreateUserStory(ADOTask newEntry)
        {
            int itemId = 0;

            using (HttpClient client = new HttpClient())
            {

                VssBasicCredential credentials = new VssBasicCredential("", PersonalAccessToken);
                JsonPatchDocument patchDocument = new JsonPatchDocument();

                Uri uri = new Uri(OrganizationUrl);

                patchDocument.Add(new JsonPatchOperation()
                {
                    Operation = Operation.Add,
                    Path = "/fields/System.AssignedTo",
                    Value = newEntry.AssignedTo
                }
                                  );

                patchDocument.Add(new JsonPatchOperation()
                {
                    Operation = Operation.Add,
                    Path = "/fields/System.Title",
                    Value = newEntry.Title
                }
                                  );
                patchDocument.Add(new JsonPatchOperation()
                {
                    Operation = Operation.Add,
                    Path = "/fields/System.Description",
                    Value = newEntry.Description
                }
                                  );

                patchDocument.Add(new JsonPatchOperation()
                {
                    Operation = Operation.Add,
                    Path = "/fields/System.State",
                    Value = newEntry.State
                }
                                  );

                patchDocument.Add(new JsonPatchOperation()
                {
                    Operation = Operation.Add,
                    Path = "/fields/System.IterationPath",
                    Value = newEntry.IterationPath
                }
                                  );
                patchDocument.Add(new JsonPatchOperation()
                {
                    Operation = Operation.Add,
                    Path = "/fields/System.AreaPath",
                    Value = newEntry.AreaPath
                }
                                  );


                string rel_url = string.Format("{0}/{1}/_apis/wit/workitems/{2}", OrganizationUrl, Project, newEntry.ParentId);

                patchDocument.Add(new JsonPatchOperation()
                {
                    Operation = Operation.Add,
                    Path = "/relations/-",
                    Value = new
                    {
                        rel = "System.LinkTypes.Hierarchy-Reverse",
                        url = rel_url
                    }
                }
                                  );


                VssConnection connection = new VssConnection(uri, credentials);
                WorkItemTrackingHttpClient workItemTrackingHttpClient = connection.GetClient<WorkItemTrackingHttpClient>();

                WorkItem result = workItemTrackingHttpClient.CreateWorkItemAsync(patchDocument, Project, newEntry.ItemType).Result;
                itemId = (int)result.Id;
            }

            return itemId;
        }


        public void SetItemState(int itemId, string newState)
        {
            using (HttpClient client = new HttpClient())
            {
                VssBasicCredential credentials = new VssBasicCredential("", PersonalAccessToken);
                JsonPatchDocument patchDocument = new JsonPatchDocument();

                Uri uri = new Uri(OrganizationUrl);

                patchDocument.Add(new JsonPatchOperation()
                {
                    Operation = Operation.Replace,
                    Path = "/fields/System.State",
                    Value = newState
                }
                                  );

                VssConnection connection = new VssConnection(uri, credentials);
                WorkItemTrackingHttpClient workItemTrackingHttpClient = connection.GetClient<WorkItemTrackingHttpClient>();

                WorkItem result = workItemTrackingHttpClient.UpdateWorkItemAsync(patchDocument, itemId).Result;
            }
        }

		public void CloseItem(int itemId, bool updateOriginalEstimate, double completed)
		{
			using (HttpClient client = new HttpClient())
			{
				VssBasicCredential credentials = new VssBasicCredential("", PersonalAccessToken);
				JsonPatchDocument patchDocument = new JsonPatchDocument();

				Uri uri = new Uri(OrganizationUrl);

				patchDocument.Add(new JsonPatchOperation()
				{
					Operation = Operation.Replace,
					Path = "/fields/System.State",
					Value = "Closed"
				}
								  );

                if (updateOriginalEstimate == true)
                {
                    patchDocument.Add(new JsonPatchOperation()
                    {
                        Operation = Operation.Replace,
                        Path = "/fields/Microsoft.VSTS.Scheduling.OriginalEstimate",
                        Value = completed
                    }
                                      );
                }

					VssConnection connection = new VssConnection(uri, credentials);
				WorkItemTrackingHttpClient workItemTrackingHttpClient = connection.GetClient<WorkItemTrackingHttpClient>();

				WorkItem result = workItemTrackingHttpClient.UpdateWorkItemAsync(patchDocument, itemId).Result;
			}
		}

		public async Task UpdateTaskAsync(ADOTask updateEntry)
        {

            double existingCompleted= await GetOriginalCompletedAsync(updateEntry.Id);
            existingCompleted += updateEntry.CompletedWork;

            using (HttpClient client = new HttpClient())
            {
                VssBasicCredential credentials = new VssBasicCredential("", PersonalAccessToken);
                JsonPatchDocument patchDocument = new JsonPatchDocument();

                Uri uri = new Uri(OrganizationUrl);

                patchDocument.Add(new JsonPatchOperation()
                {
                    Operation = Operation.Replace,
                    Path = "/fields/Microsoft.VSTS.Scheduling.CompletedWork",
                    Value = existingCompleted
                }
                                  );

                patchDocument.Add(new JsonPatchOperation()
                {
                    Operation = Operation.Replace,
                    Path = "/fields/System.IterationPath",
                    Value = updateEntry.IterationPath
                }
                                  );

                patchDocument.Add(new JsonPatchOperation()
                {
                    Operation = Operation.Add,
                    Path = "/fields/System.History",
                    Value = updateEntry.History
                }
                  );

                patchDocument.Add(new JsonPatchOperation()
                {
                    Operation = Operation.Replace,
                    Path = "/fields/Microsoft.VSTS.Scheduling.TargetDate",
                    Value = updateEntry.TargetDate.ToString("yyyy-MM-ddTHH:mm:ssZ")
                }
                                );

                if ( updateEntry.UpdateOriginalEstimate == true ) 
                {
                    patchDocument.Add(new JsonPatchOperation()
                    {
                        Operation = Operation.Replace,
                        Path = "/fields/Microsoft.VSTS.Scheduling.OriginalEstimate",
                        Value = existingCompleted
                    }
                                      );

                }

                VssConnection connection = new VssConnection(uri, credentials);
                WorkItemTrackingHttpClient workItemTrackingHttpClient = connection.GetClient<WorkItemTrackingHttpClient>();

                WorkItem result = workItemTrackingHttpClient.UpdateWorkItemAsync(patchDocument, updateEntry.Id).Result;               
            }
        }

        private async Task<double> GetOriginalCompletedAsync(int itemId)
        {
            string originalCompleted = "0";

            if (itemId > 0)
            {
                var workItems = await _GetItemInfo(itemId);

                if (workItems[0].Fields.ContainsKey("Microsoft.VSTS.Scheduling.CompletedWork"))
                {
                    originalCompleted = workItems[0].Fields["Microsoft.VSTS.Scheduling.CompletedWork"].ToString();
                }
            }
            return Math.Round(Convert.ToDouble(originalCompleted), 1);
        }

		public async Task<System.Collections.Generic.IList<WorkItem>> GetOpenItems(string project)
		{

            string query = "Select [Id] " +
                                "From WorkItems " +
                                "Where [System.WorkItemType] IN ('Task', 'Bug') " +
                                    "And [System.TeamProject] = '" + project + "' " +
                                    "And [System.State] IN ('Active', 'New') " +
                                    "And [System.AssignedTo] = @me " +
								"Order By [System.AreaPath], [Id] Asc";

			// create a wiql object and build our query
			var wiql = new Wiql()
			{
				// NOTE: Even if other columns are specified, only the ID & URL are available in the WorkItemReference
				Query = query,
			};

			Uri uri = new Uri(OrganizationUrl);
			var credentials = new VssBasicCredential(string.Empty, PersonalAccessToken);

			try
			{
				// create instance of work item tracking http client
				using (var httpClient = new WorkItemTrackingHttpClient(uri, credentials))
				{
					// execute the query to get the list of work items in the results
					var result = await httpClient.QueryByWiqlAsync(wiql).ConfigureAwait(false);
					var ids = result.WorkItems.Select(item => item.Id).ToArray();

					// some error handling
					if (ids.Length == 0)
					{
						return Array.Empty<WorkItem>();
					}

					// build a list of the fields we want to see
					//var fields = new[] { "System.Id", "System.Title", "System.State", "System.AreaPath", "System.WorkItemType", "System.IterationPath", "System.Tags", "Microsoft.VSTS.Scheduling.OriginalEstimate", "Microsoft.VSTS.Scheduling.CompletedWork, Custom.AccountType" };
					var fields = new[] { "System.Id", "System.Title", "System.State", "System.AreaPath", "System.WorkItemType", "System.IterationPath", "System.Tags", "Microsoft.VSTS.Scheduling.OriginalEstimate", "Microsoft.VSTS.Scheduling.CompletedWork" };

					// get work items for the ids found in query
					return await httpClient.GetWorkItemsAsync(ids, fields, result.AsOf).ConfigureAwait(false);

				}
			}
			catch (Exception exc)
			{
				MessageBox.Show(exc.Message);
				return Array.Empty<WorkItem>();
			}
		}

	}
}
