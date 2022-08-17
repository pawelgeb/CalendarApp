using System;

namespace CalendarTaskApp
{
    internal class MyTask
    {

        public string Name { get; set; }
        public DateTime DateTime { get; set; }
        public Priority Priority { get; set; }
        public bool IsCompleted { get; set; } = false;

    }

    public enum Priority
    {
        Low = 1,
        Medium = 2,
        High = 3
    }
}
