using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SQLite;
using Microsoft.TeamFoundation.Build.WebApi;
using Microsoft.TeamFoundation.Work.WebApi;
using System.Windows.Controls;
using System.Data.Entity.Core.Common.CommandTrees.ExpressionBuilder;
using System.Windows.Forms;
using System.Data.Entity.ModelConfiguration.Configuration;


namespace TimeTracker
{

	public class TimeEntry
	{
		public string Category { get; set; }
		public int ItemId { get; set; }
		public string ItemType { get; set; }
		public string Title { get; set; }
		public string Board { get; set; }
		public string Story { get; set; }
		public string StartTime { get; set; }
		public string EndTime { get; set; }
		public string Duration { get; set; }
		public string Tags { get; set; }
		public string Description { get; set; }
		public string Project { get; set; }
		public string AreaPath { get; set; }
		public string Iteration { get; set; }
		public Boolean CloseItem { get; set; }
		public int ParentId { get; set; }
		public DateTime? CreateDate { get; set; }
		public string OperationMode { get; set; }
		public Boolean Saved { get; set; }
		public DateTime? StartDate { get; set; }
		public DateTime? TargetDate { get; set; }
		public string OriginalEstimate { get; set; }
		public Boolean UpdateOrgEst { get; set; }
		public string WbsCode { get; set; }
		public string State { get; set; }


		public void Clear()
		{
			Category = null;
			ItemId = 0;
			ItemType = null;
			Title = null;
			Board = null;
			Story = null;
			StartTime = null;
			EndTime = null;
			Duration = null;
			Tags = null;
			Description = null;
			Project = null;
			AreaPath = null;
			Iteration = null;
			CloseItem = false;
			ParentId = 0;
			CreateDate = null;
			OperationMode = null;
			Saved = false;			
			StartDate = null;
			TargetDate = null;
			OriginalEstimate = null;
			UpdateOrgEst = false;
			WbsCode = null;
			State = null;
		}
	}

	public class DBHelper
	{
		internal static string connectionString = "Data Source='TimeTracker.db';Version=3;";

		//        public SQLiteConnection CreateConnection(string connectionString)
		//        {
		//            cn = new SQLiteConnection(connectionString);

		//            return cn;
		//        }

		//        public DataTable GetData(string commandText)
		//        {
		//            DataTable result = new DataTable();
		//            using (SQLiteCommand cmd = new SQLiteCommand(commandText, cn))
		//            {
		//                cn.Open();
		//                using (SQLiteDataReader reader = cmd.ExecuteReader())
		//                {
		//                    result.Load(reader);
		//                }
		//                cn.Close();
		//            }
		//            return result;
		//        }

		//        public void ExecuteStatement(string sql)
		//        {
		//            using (SQLiteCommand cmd = new SQLiteCommand(sql, cn))
		//            {
		//                cn.Open();
		//                cmd.ExecuteNonQuery();
		//                cn.Close();
		//            }
		//        }
		//    }

		public void CreateTables()
		{
			try
			{
				CreateTimeEntryTable();
				CreateFavoriteBoardsTable();
				CreateFavoriteToDoListTable();
				CreateNewItemsTable();

			}
			catch (Exception exc)
			{

				throw exc;
			}
		}

		internal static void CreateTimeEntryTable()
		{
			string sql = string.Empty;

			using (SQLiteConnection connection = new SQLiteConnection(connectionString))
			{
				connection.Open();

				// Create the table
				string createTableQuery = @"
                CREATE TABLE IF NOT EXISTS TimeEntries (
					Id TEXT PRIMARY KEY,
                    Category TEXT,
                    ItemId INTEGER,
                    ItemType TEXT,
                    Title TEXT,
                    Board TEXT,
                    Story TEXT,
                    StartTime TEXT,
                    EndTime TEXT,
                    Duration TEXT,
                    Tags TEXT,
                    Description TEXT,
                    Project TEXT,
                    AreaPath TEXT,
                    Iteration TEXT,
                    CloseItem INTEGER,
                    ParentId INTEGER,
                    CreateDate NUMERIC,
                    OperationMode TEXT,
                    Saved INTEGER,
                    StartDate NUMERIC,
                    TargetDate NUMERIC,
                    OriginalEstimate TEXT,
                    UpdateOrgEst INTEGER,
                    WbsCode TEXT,
                    State TEXT
                )";
				using (SQLiteCommand createTableCommand = new SQLiteCommand(createTableQuery, connection))
				{
					createTableCommand.ExecuteNonQuery();
				}

				// Close the connection
				connection.Close();
			}
		}

		internal static void CreateFavoriteBoardsTable()
		{
			string sql = string.Empty;

			using (SQLiteConnection connection = new SQLiteConnection(connectionString))
			{
				connection.Open();

				// Create the table
				string createTableQuery = @"
                CREATE TABLE IF NOT EXISTS FavoriteBoards (
					BoardName TEXT
                )";
				using (SQLiteCommand createTableCommand = new SQLiteCommand(createTableQuery, connection))
				{
					createTableCommand.ExecuteNonQuery();
				}

				// Close the connection
				connection.Close();
			}
		}

		internal static void CreateFavoriteToDoListTable()
		{
			string sql = string.Empty;

			using (SQLiteConnection connection = new SQLiteConnection(connectionString))
			{
				connection.Open();

				// Create the table
				string createTableQuery = @"
                CREATE TABLE IF NOT EXISTS TodoList (
					Title TEXT,
                    Description TEXT
                )";
				using (SQLiteCommand createTableCommand = new SQLiteCommand(createTableQuery, connection))
				{
					createTableCommand.ExecuteNonQuery();
				}

				// Close the connection
				connection.Close();
			}
		}

		internal static void CreateNewItemsTable()
		{
			string sql = string.Empty;

			using (SQLiteConnection connection = new SQLiteConnection(connectionString))
			{
				connection.Open();

				// Create the table
				string createTableQuery = @"
                CREATE TABLE IF NOT EXISTS NewItems (
					ItemId INTEGER PRIMARY KEY,
                    WbsCode TEXT
                )";
				using (SQLiteCommand createTableCommand = new SQLiteCommand(createTableQuery, connection))
				{
					createTableCommand.ExecuteNonQuery();
				}

				// Close the connection
				connection.Close();
			}
		}

		public void SaveTimeEntry(TimeEntry te)
		{
			using (SQLiteConnection connection = new SQLiteConnection(connectionString))
			{
				connection.Open();

				Guid newId = Guid.NewGuid();

				// Insert data into the table
				string sql = @"
                INSERT INTO TimeEntries (Id, Category, ItemId, ItemType, Title, Board, Story, StartTime, EndTime, Duration, Tags, Description, Project, AreaPath, Iteration, CloseItem, ParentId, CreateDate, OperationMode, Saved, StartDate, TargetDate, OriginalEstimate, UpdateOrgEst, WbsCode, State)
                VALUES (@Id, @Category, @ItemId, @ItemType, @Title, @Board, @Story, @StartTime, @EndTime, @Duration, @Tags, @Description, @Project, @AreaPath, @Iteration, @CloseItem, @ParentId, @CreateDate, @OperationMode, @Saved, @StartDate, @TargetDate, @OriginalEstimate, @UpdateOrgEst, @WbsCode, @State)";
				using (SQLiteCommand insertCommand = new SQLiteCommand(sql, connection))
				{
					insertCommand.Parameters.AddWithValue("@Id", newId.ToString());
					insertCommand.Parameters.AddWithValue("@Category", te.Category);
					insertCommand.Parameters.AddWithValue("@ItemId", te.ItemId);
					insertCommand.Parameters.AddWithValue("@ItemType", te.ItemType);
					insertCommand.Parameters.AddWithValue("@Title", te.Title);
					insertCommand.Parameters.AddWithValue("@Board", te.Board);
					insertCommand.Parameters.AddWithValue("@Story", te.Story);
					insertCommand.Parameters.AddWithValue("@StartTime", te.StartTime);
					insertCommand.Parameters.AddWithValue("@EndTime", te.EndTime);
					insertCommand.Parameters.AddWithValue("@Duration", te.Duration);
					insertCommand.Parameters.AddWithValue("@Tags", te.Tags);
					insertCommand.Parameters.AddWithValue("@Description", te.Description);
					insertCommand.Parameters.AddWithValue("@Project", te.Project);
					insertCommand.Parameters.AddWithValue("@AreaPath", te.AreaPath);
					insertCommand.Parameters.AddWithValue("@Iteration", te.Iteration);
					insertCommand.Parameters.AddWithValue("@CloseItem", te.CloseItem);
					insertCommand.Parameters.AddWithValue("@ParentId", te.ParentId);
					insertCommand.Parameters.AddWithValue("@CreateDate", te.CreateDate);
					insertCommand.Parameters.AddWithValue("@OperationMode", te.OperationMode);
					insertCommand.Parameters.AddWithValue("@Saved", te.Saved);
					insertCommand.Parameters.AddWithValue("@StartDate", te.StartDate);
					insertCommand.Parameters.AddWithValue("@TargetDate", te.TargetDate);
					insertCommand.Parameters.AddWithValue("@OriginalEstimate", te.OriginalEstimate);
					insertCommand.Parameters.AddWithValue("@UpdateOrgEst", te.UpdateOrgEst);
					insertCommand.Parameters.AddWithValue("@WbsCode", te.WbsCode);
					insertCommand.Parameters.AddWithValue("@State", te.State);

					insertCommand.ExecuteNonQuery();
				}


				// Close the connection
				connection.Close();
			}
		}
		public SQLiteDataReader LoadTimeEntries(string sql)
		{
			//string connectionString = "Data Source='TimeTracker.db';Version=3;";

			SQLiteConnection connection = new SQLiteConnection(connectionString);

			connection.Open();

			SQLiteCommand selectCommand = new SQLiteCommand(sql, connection);
			SQLiteDataReader reader = selectCommand.ExecuteReader();

			return reader;
		}

		public void DeleteTimeEntries(DateTime selectedDate)
		{
			//string connectionString = "Data Source='TimeTracker.db';Version=3;";

			SQLiteConnection connection = new SQLiteConnection(connectionString);

			connection.Open();

			string sql = "DELETE FROM TimeEntries WHERE CreateDate = '" + selectedDate.ToString("yyyy\\-MM\\-dd 00:00:00") + "'";
			SQLiteCommand cmd = new SQLiteCommand(sql, connection);
			cmd.ExecuteNonQuery();

			cmd.Dispose();
			connection.Close();
		}

		public SQLiteDataReader LoadFavoriteBoards()
		{
			//string connectionString = "Data Source='TimeTracker.db';Version=3;";
			string sql = "SELECT * FROM FavoriteBoards";
			SQLiteConnection connection = new SQLiteConnection(connectionString);

			connection.Open();

			SQLiteCommand selectCommand = new SQLiteCommand(sql, connection);
			SQLiteDataReader reader = selectCommand.ExecuteReader();

			return reader;
		}

		internal static void DeleteFavoriteBoards()
		{
			//string connectionString = "Data Source='TimeTracker.db';Version=3;";

			SQLiteConnection connection = new SQLiteConnection(connectionString);

			connection.Open();

			string sql = "DELETE FROM FavoriteBoards";
			SQLiteCommand cmd = new SQLiteCommand(sql, connection);
			cmd.ExecuteNonQuery();

			cmd.Dispose();
			connection.Close();
		}

		public void SaveFavoriteBoards(List<string> boardNames)
		{
			//delete existing before saving
			DeleteFavoriteBoards();

			//string connectionString = "Data Source='TimeTracker.db';Version=3;";

			using (SQLiteConnection connection = new SQLiteConnection(connectionString))
			{
				connection.Open();

				// Insert data into the table
				string sql = @"
                INSERT INTO FavoriteBoards (BoardName) VALUES (@BoardName)";
				using (SQLiteCommand insertCommand = new SQLiteCommand(sql, connection))
				{
					foreach (string boardname in boardNames)
					{
						insertCommand.Parameters.AddWithValue("@BoardName", boardname);
						insertCommand.ExecuteNonQuery();
					}
				}

				// Close the connection
				connection.Close();
			}
		}

		public SQLiteDataReader LoadTodoList()
		{
			string sql = "SELECT * FROM TodoList";
			SQLiteConnection connection = new SQLiteConnection(connectionString);

			connection.Open();

			SQLiteCommand selectCommand = new SQLiteCommand(sql, connection);
			SQLiteDataReader reader = selectCommand.ExecuteReader();

			return reader;
		}

		public void SaveTodoList(DataGridViewRowCollection gridViewRows)
		{
			//delete existing before saving
			DeleteTodoList();

			using (SQLiteConnection connection = new SQLiteConnection(connectionString))
			{
				connection.Open();

				// Insert data into the table
				string sql = @"
                INSERT INTO TodoList (Title, Description) VALUES (@Title, @Description)";
				using (SQLiteCommand insertCommand = new SQLiteCommand(sql, connection))
				{
					foreach (DataGridViewRow row in gridViewRows)
					{
						string title = row.Cells["coltitle"].Value?.ToString();
						string description = row.Cells["colDescription"].Value?.ToString();

						insertCommand.Parameters.AddWithValue("@Title", title);
						insertCommand.Parameters.AddWithValue("@Description", description);
						insertCommand.ExecuteNonQuery();
					}
				}

				// Close the connection
				connection.Close();
			}
		}
		internal static void DeleteTodoList()
		{
			SQLiteConnection connection = new SQLiteConnection(connectionString);

			connection.Open();

			string sql = "DELETE FROM TodoList";
			SQLiteCommand cmd = new SQLiteCommand(sql, connection);
			cmd.ExecuteNonQuery();

			cmd.Dispose();
			connection.Close();
		}

		public void SaveNewItem(int itemId, string wbsCode)
		{

			using (SQLiteConnection connection = new SQLiteConnection(connectionString))
			{
				connection.Open();

				string sql = @"
                INSERT INTO NewItems (ItemId, WbsCode)
                VALUES (@ItemId, @WbsCode)";
				using (SQLiteCommand insertCommand = new SQLiteCommand(sql, connection))
				{
					insertCommand.Parameters.AddWithValue("@ItemId", itemId);
					insertCommand.Parameters.AddWithValue("@WbsCode", wbsCode);

					insertCommand.ExecuteNonQuery();
				}

				connection.Close();
			}

		}
	}
}
