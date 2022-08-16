namespace CalendarTaskApp
{
    internal class MyTask
    {

        public string Name { get; set; }
        public Priority Priority { get; set; }

    }

    public enum Priority
    {
        Low = 1,
        Medium = 2,
        High = 3
    }
}
