using System;
using System.Collections.Generic;
using System.IO;

namespace CalendarTaskApp
{
    public static class DataReader
    {
        readonly static string destPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "taskFile.txt");
        static DateTime date2;
        static Dictionary<DateTime, List<MyTask>> myDictionary = new Dictionary<DateTime, List<MyTask>>();
        static Priority priority;

        static Dictionary<DateTime, List<MyTask>> Read()
        {
            if (File.Exists(destPath))
            {
                using (var day = new StreamReader(destPath))
                {
                    string line = null;

                    while ((line = day.ReadLine()) != null)
                    {
                        string[] parts = line.Split(new string[1] { "##-mySeparator-##" }, StringSplitOptions.RemoveEmptyEntries);
                        date2 = DateTime.Parse(parts[0]);
                        priority = parts[2];
                        AddTask(date2, parts[1], priority);
                    }
                }
            }

            void AddTask(DateTime key, string task, Priority priority = Priority.Medium)
            {
                if (myDictionary.ContainsKey(key))
                {
                    myDictionary[key].Add(new MyTask() { Name = task, Priority = priority });
                    return;
                }

                myDictionary.Add(key, new List<MyTask>() { new MyTask() { Name = task, Priority = priority } });
            }

            return myDictionary;


            //todo: if the file does not exist return null or empty dict
            //throw new NotImplementedException();
        }

    }
}
