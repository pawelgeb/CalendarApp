using System;

namespace CalendarTaskApp
{
    internal static class InputFromUser
    {
        static int numberFromUser;
        public static int numberUser()
        {

            try
            {
                numberFromUser = Int32.Parse(Console.ReadLine());
            }
            catch (Exception)
            {
                Console.WriteLine("Wrong input format. Please enter number");
            }
            return numberFromUser;
        }
    }
}
