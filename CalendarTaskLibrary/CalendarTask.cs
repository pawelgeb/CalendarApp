using System;
using System.Collections.Generic;

namespace CalendarTaskApp
{
    public class CalendarTask
    {
        #region My Variables

        List<MyTask> myList = new List<MyTask>();

        #endregion

        public CalendarTask() { }

        public CalendarTask(List<MyTask> myList)
        {
            this.myList = myList;
        }

        public List<MyTask> GetTasksDictionary()
        {

            return myList;
        }
        public void AddTask(DateTime date, string task, Priority priority = Priority.Medium)
        {
            myList.Add(new MyTask() { DateTime = date, Name = task, Priority = priority });
        }
    }
}
