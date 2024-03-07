//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;
//using System.Data.SQLite;
//using System.Data;

//namespace TimeTracker
//{
//    internal class SQLiteHelper
//    {
//        private SQLiteConnection cn;

//        public SQLiteHelper()
//        {
            
//        }

//        //private SQLiteConnection conn;

//        public SQLiteConnection CreateConnection(string connectionString)
//        {
//            cn = new SQLiteConnection(connectionString);

//            return cn;
//        }

//        public void CreateTables() 
//        {
//            string sql = "CREATE TABLE TimeEntry (Id INTEGER IDENTITY(1,1)," +
//                                                    "Board VARCHAR(30)," +
//                                                    "Story VARCHAR(30)," +
//                                                    "Category VARCHAR(10), " +
//                                                    "Title VARCHAR(100)," +
//                                                    "Description VARCHAR(200)," +
//                                                    "StartDate DATETIME," +
//                                                    "Duration TIME," +
//                                                    "ADOItemId BIGINT)";
//            ExecuteStatement(sql);
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
//}
