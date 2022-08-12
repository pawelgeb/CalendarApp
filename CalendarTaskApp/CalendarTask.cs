using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;

namespace CalendarTaskApp
{
    internal class CalendarTask
    {
        #region My Variables

        int numberToChose = 0;
        readonly string destPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "taskFile.txt");

        Dictionary<string, List<string>> myDictionary = new Dictionary<string, List<string>>();

        DateTime date2;

        string key;

        #endregion

        public CalendarTask() { }

        public CalendarTask(Dictionary<string, List<string>> dictionary)
        {
            myDictionary = dictionary;
        }

        public void CalendarAppGo()
        {
            ReadData();

            Console.WriteLine("Welcome in Calendar Task program.");

            CalendarDisplay();

            bool choseValue = true;

            while (choseValue)
            {
                switch (numberToChose)
                {
                    case 1:
                        {
                            EnterTask();
                            CalendarDisplay();
                            break;
                        }
                    case 2:
                        {
                            ShowTasks();
                            CalendarDisplay();
                            break;
                        }
                    case 3:
                        {
                            choseValue = false;
                            break;

                        }
                    default:
                        {
                            Console.WriteLine("Wrong number");
                            CalendarDisplay();
                            break;
                        }
                }
            }

            WriteData();

        }

        //private string DisplayDayData(KeyValuePair<string, List<string>> selectedDate)
        //{

        //    return $"Date: {selectedDate.Key} Task: {selectedDate.Value}";

        //}
        public void CalendarDisplay()
        {
            var dateTime = DateTime.UtcNow;
            Console.WriteLine(dateTime.ToString());
            Console.WriteLine();
            Console.WriteLine("Please chose number (1-3) to get action:");
            Console.WriteLine("1 - add a task for your list");
            Console.WriteLine("2 - view a month tasks");
            Console.WriteLine("3 - save task list and exit program");

            try
            {
                numberToChose = Int32.Parse(Console.ReadLine());
            }
            catch (Exception)
            {
                Console.WriteLine("Wrong input format. Please enter number");
                CalendarDisplay();
            }

        }
        public void EnterTask()
        {

            Console.WriteLine("Please enter a date time (dd/MM/yyyy)");
            string date = Console.ReadLine();
            bool dateCorrect;
            List<string> myList = new List<string>();

            dateCorrect = DateTime.TryParseExact(date, "dd/MM/yyyy", CultureInfo.InvariantCulture, DateTimeStyles.None, out date2);

            if (dateCorrect == false)
            {
                throw new Exception("Incorrect date format");
            }
            Console.WriteLine("Please enter a task");
            string task = Console.ReadLine();

            AddTask(date, task);
        }

        public Dictionary<string, List<string>> GetDictionary()
        {
            return myDictionary;
        }

        public void ShowTasks()
        {
            foreach (string key in myDictionary.Keys)
            {
                foreach (string val in myDictionary[key])
                {
                    Console.Write($"Date: {key}, Task: {val}");
                }
            }
        }

        public void ReadData()
        {
            if (File.Exists(destPath))
            {
                using (var day = new StreamReader(destPath))
                {
                    string line = null;

                    while ((line = day.ReadLine()) != null)
                    {
                        string[] parts = line.Split(new string[1] { "##-mySeparator-##" }, StringSplitOptions.RemoveEmptyEntries);
                        key = parts[0];
                        AddTask(key, parts[1]);
                    }
                }
            }
        }

        public void WriteData()
        {
            using (StreamWriter file = new StreamWriter(destPath))
            {
                foreach (var entry in myDictionary)
                {
                    foreach (var task in entry.Value)
                    {
                        file.WriteLine($"{entry.Key} ##-mySeparator-## {task}");
                    }
                }
            }
        }


        public void AddTask(string key, string task)
        {
            if (myDictionary.ContainsKey(key))
            {
                myDictionary[key].Add(task);
                return;
            }

            myDictionary.Add(key, new List<string>() { task });
        }

    }

    public enum Priority
    {
        Low = 1,
        Medium = 2,
        High = 3
    }

    class MyTask
    {
        public DateTime Date { get; set; }
        public string Name { get; set; }
        public Priority Priority { get; set; }
    }

}



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