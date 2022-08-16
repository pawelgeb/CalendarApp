using System;
using System.Collections.Generic;
using System.IO;

namespace CalendarTaskApp
{
    public static class DataWriter
    {
        readonly static string destPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "taskFile.txt");
        public static void Write(Dictionary<DateTime, List<string>> dictionary)
        {
            using (StreamWriter file = new StreamWriter(destPath))
            {
                foreach (var entry in dictionary)
                {
                    foreach (var task in entry.Value)
                    {
                        file.WriteLine($"{entry.Key.ToShortDateString()} ##-mySeparator-## {task}");
                    }
                }
            }
        }
        //throw new NotImplementedException();
    }
}
