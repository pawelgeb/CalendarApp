using System;
using System.Collections.Generic;
using System.IO;

namespace CalendarTaskApp
{
    internal class CalendarTask
    {
        #region My Variables

        readonly string destPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "taskFile.txt");

        Dictionary<DateTime, List<MyTask>> myDictionary = new Dictionary<DateTime, List<MyTask>>();

        #endregion

        public CalendarTask() { }

        public CalendarTask(Dictionary<DateTime, List<MyTask>> dictionary)
        {
            myDictionary = dictionary;
        }

        public Dictionary<DateTime, List<MyTask>> GetTasksDictionary()
        {

            return myDictionary;
        }

        public void CalendarDisplay()
        {
            Console.WriteLine("Please chose number (1-3) to get action:");
            Console.WriteLine("1 - add a task for your list");
            Console.WriteLine("2 - view a month tasks");
            Console.WriteLine("3 - save task list and exit program");
        }


        public void ShowTasks()
        {
            foreach (DateTime key in myDictionary.Keys)
            {
                foreach (MyTask val in myDictionary[key])
                {
                    Console.WriteLine($"Date: {key.ToShortDateString()}, Task: {val}");
                }
            }
        }

        public void AddTask(DateTime key, string task, Priority priority = Priority.Medium)
        {

            if (myDictionary.ContainsKey(key))
            {
                myDictionary[key].Add(new MyTask() { Name = task, Priority = priority });
                return;
            }
            myDictionary.Add(key, new List<MyTask>() { new MyTask() { Name = task, Priority = priority } });
        }

    }

}




//    class MyTask
//    {
//        public DateTime Date { get; set; }
//        public string Name { get; set; }
//        public Priority Priority { get; set; }
//    }

//}



/* var dateTime = DateTime.UtcNow;
 Console.WriteLine(dateTime.ToUniversalTime()
              .ToString("yyyy'-'MM'-'dd'T'HH':'mm':'ss'.'fff'Z'"));
 Console.WriteLine(dateTime.ToString());
 Console.WriteLine(dateTime.ToShortTimeString());
 Console.Write("Nasz czas: ");
 Console.WriteLine(TimeZoneInfo.ConvertTime(dateTime, TimeZoneInfo.FindSystemTimeZoneById("Central European Standard Time")));
 Console.WriteLine(dateTime.Year);
 Console.WriteLine(dateTime.Month);
 Console.WriteLine(dateTime.Day);
 Console.WriteLine();
 var dateTime2 = new DateTime(2022, 02, 27);
 Console.WriteLine(GetDateTimeString(dateTime2.AddDays(1)));
 Console.WriteLine(GetDateTimeString(dateTime2.AddDays(2)));
 Console.WriteLine(GetDateTimeString(dateTime2.AddDays(3)));
 Console.WriteLine(GetDateTimeString(dateTime2.AddDays(4)));
 Console.ReadLine();
}
private static string GetDateTimeString(DateTime dateTime)
{
 return $"This is a day {dateTime.Day}, of a month {dateTime.Month} of a year {dateTime.Year}.";
*/