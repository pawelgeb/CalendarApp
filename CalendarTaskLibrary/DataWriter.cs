using Newtonsoft.Json;

namespace CalendarTaskApp
{
    public static class DataWriter
    {
        //readonly static string destPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "taskFile.txt");
        //internal static void Write2(Dictionary<DateTime, List<MyTask>> dictionary)
        //{
        //    using (StreamWriter file = new StreamWriter(destPath))
        //    {
        //        foreach (var entry in dictionary)
        //        {
        //            foreach (var task in entry.Value)
        //            {
        //                file.WriteLine($"{entry.Key.ToShortDateString()} ##-mySeparator-## {task.Name} ##-mySeparator-## {task.Priority}");
        //            }
        //        }
        //    }

        //}

        readonly static string destPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "taskFileJson.json");

        public static void Write(List<MyTask> myList)
        {
            string dictionaryJson = JsonConvert.SerializeObject(myList, Formatting.Indented);
            File.WriteAllText(destPath, dictionaryJson, System.Text.Encoding.UTF8);
        }
    }
}

//throw new NotImplementedException();
