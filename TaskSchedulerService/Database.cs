using System;
using System.Collections.Generic;
using System.Data.SQLite;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaskSchedulerService
{
    class Database
    {
        public static string currentPath = "";
        private static string pathToDatabase = "TaskScheduler";
        private static string connectionString = "";
        private static SQLiteCommand _command = new SQLiteCommand();

        public static void Connect()
        {
            pathToDatabase = $"{currentPath}\\{pathToDatabase}";
            connectionString = $"Data Source={pathToDatabase}";
            File.WriteAllText(@"E:\Fast files\Project\Task-Sheduler\Debug\logsServiceDB.txt", pathToDatabase);

            using (var connection = new SQLiteConnection(connectionString))
            {
                connection.Open();
                _command.Connection = connection;
                connection.Close();
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
                connection.Close();
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

                            task.CheckDays();

                            tasks.Add(task);
                        }
                    }
                }
                connection.Close();
            }

            return tasks;
        }

        public static void UpdateTaskTime(long id, string timeStart)
        {
            string sqlExpression = $"UPDATE Tasks SET TimeStart='{timeStart}' WHERE Id='{id}'";
            using (var connection = new SQLiteConnection(connectionString))
            {
                connection.Open();
                SQLiteCommand command = new SQLiteCommand();
                command.Connection = connection;
                command = new SQLiteCommand(sqlExpression, connection);

                command.ExecuteNonQueryAsync();

                connection.Close();
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

                connection.Close();
            }
        }
    }
}
