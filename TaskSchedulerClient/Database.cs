using System;
using System.Collections.Generic;
using System.Data.SQLite;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaskSchedulerClient
{
    class Database
    {
        private static string pathToDatabase = "TaskScheduler";
        private static string connectionString = $"Data Source={pathToDatabase}";
        private static SQLiteCommand _command = new SQLiteCommand();

        private static string _createTable =
            "CREATE TABLE Tasks ("
            + "Id INTEGER PRIMARY KEY AUTOINCREMENT,"
            + "Name STRING,"
            + "TimeStart STRING,"
            + "Path TEXT,"
            + "Type STRING"
            + ");";

        public static void Connect()
        {
            using (var connection = new SQLiteConnection(connectionString))
            {
                connection.Open();
                _command.Connection = connection;
            }
        }

        public static void AddTask(Models.Task task)
        {
            string name = task.Name;
            string time = task.TimeStart.ToString();
            string path = task.Path;
            string type = ((int)task.Type).ToString();

            using (var connection = new SQLiteConnection(connectionString))
            {
                connection.Open();
                _command.Connection = connection;
                _command.CommandText = $"INSERT INTO Tasks (Name, TimeStart, Path, Type) VALUES ('{name}', '{time}', '{path}', '{type}')";

                _command.ExecuteNonQuery();
            }
        }

        public static List<Models.Task> GetTasks()
        {
            List<Models.Task> tasks = new List<Models.Task>();
            string sqlExpression = "SELECT * FROM Tasks";
            using (var connection = new SQLiteConnection(connectionString))
            {
                connection.Open();

                _command = new SQLiteCommand(sqlExpression, connection);
                using (SQLiteDataReader reader = _command.ExecuteReader())
                {
                    if (reader.HasRows) // если есть данные
                    {
                        while (reader.Read())   // построчно считываем данные
                        {
                            var id = reader.GetValue(0);
                            var name = reader.GetValue(1);
                            var timeStart = reader.GetValue(2);
                            var path = reader.GetValue(3);
                            var type = reader.GetValue(4);

                            Models.Task task = new Models.Task();
                            task.Id = (long)id;
                            task.Name = (string)name;
                            task.TimeStart = DateTime.Parse((string)timeStart);
                            task.Path = (string)path;

                            switch (int.Parse(type.ToString())) 
                            {
                                case 0:
                                    task.Type = Models.TypeAction.EveryDay;
                                    break;
                                case 1:
                                    task.Type = Models.TypeAction.EveryWeek;
                                    break;
                            }

                            tasks.Add(task);
                        }
                    }
                }
            }

            return tasks;
        }

        public static void UpdateTaskTime(long id, string timeStart)
        {
            string sqlExpression = $"UPDATE Tasks SET TimeStart={timeStart} WHERE Id='{id}'";
            using (var connection = new SQLiteConnection(connectionString))
            {
                connection.Open();

                _command = new SQLiteCommand(sqlExpression, connection);

                _command.ExecuteNonQuery();
            }
        }

        public static void DeleteTask(long id)
        {
            string sqlExpression = $"DELETE FROM Tasks WHERE Id='id'";
            using (var connection = new SQLiteConnection(connectionString))
            {
                connection.Open();

                _command = new SQLiteCommand(sqlExpression, connection);
                _command.ExecuteNonQuery();
            }
        }
    }
}
