using System;
using System.Linq;

namespace CalendarTaskApp
{

    internal class Program
    {

        //todo:
        /* 1. Dla każdego dnia można dodać więcej niż tylko jedno zadanie. Zadania są wyświetlane zgodnie z kolejnością dodawania. *Zadania mają swój priorytet (Priorytet to enum: Low, Medium, High, domyslnie zawsze Medium). Zadania wyświetlamy sortujac po priorytecie. Piorytet trzeba też pokazac
         * 2. Refaktor, Twój kalendarz ma być osobną klasą, która udostępnia metody publiczne, do jego obsługi. Odczyt i zapis pliku powinien być w osobnej klsie (np FileReader i FileWriter)
         * 3. Wyświetlanie tasków dla: dnia, tygodnia, miesiąca. Jeśli user wybierze wyświetlanie, to pytamy o to, czy chce zobaczyć listę wszystkich czy posortowane dla tygodnia/miesiąca/roku - w taki przypapadku grupujemy taski po wybranym.
        
         * 4. Serializacja do JSON'a - Nowe metody do Read oraz Write, zmiana słownika na listę, dodać pole DateTime do MyTask
         * 5. Dodaj flagę IsActive, dodaj pole int Index, Dodaj nową operację - wykonanie zadania, która przestawi flage IsActive na false, dodaj sortowanie po priority oraz ukrywanie wykonanych zadań
         */


        static void Main(string[] args)
        {

            DateTime date;
            int userNumber;

            CalendarTask myTask = new CalendarTask(DataReader.Read());
            Console.WriteLine("Welcome to Calendar App");
            do
            {
                Console.WriteLine("Please chose number (1-3) to get action:");
                Console.WriteLine("1 - add a task for your list");
                Console.WriteLine("2 - view a month tasks");
                Console.WriteLine("3 - save task list and exit program");
                userNumber = InputFromUser.numberUser();
                switch (userNumber)
                {
                    case 1:
                        {
                            Console.WriteLine("Please enter date (dd/MM/yyyy)");
                            string dateString;
                            String priorityString;
                            Priority priority;
                            int[] priorityArray = new int[3] { 1, 2, 3 };
                            dateString = Console.ReadLine();
                            date = DateTime.Parse(dateString);
                            Console.WriteLine("Please enter task");
                            string task = Console.ReadLine();
                            Console.WriteLine("Please enter a priority (1 - low, 2 - Medium, 3 - High) default: Medium");
                            priorityString = Console.ReadLine();
                            if (!string.IsNullOrEmpty(priorityString))
                            {
                                //może jakaś inna walidacja? np. int in range? int w arrayu int[3]{1,2,3}
                                while (!Enumerable.Range(1, 3).Contains(Int32.Parse(priorityString)))
                                {
                                    Console.WriteLine("Wrong priority number. Enter a prority again:");
                                    priorityString = Console.ReadLine();

                                }

                                priority = (Priority)int.Parse(priorityString);
                                myTask.AddTask(date, task, priority);

                            }
                            else
                            {
                                myTask.AddTask(date, task);
                            }
                            break;
                        }
                    case 2:
                        {
                            //sortowanie po priorytecie
                            foreach (var task in myTask.GetTasksDictionary())
                            {
                                Console.WriteLine($"Date: {task.DateTime} Task: {task.Name} Priority: {task.Priority}");
                            }
                        }

                        break;
                    case 3:
                        {
                            break;
                        }
                }
            }
            while (userNumber != 3);


            DataWriter.Write(myTask.GetTasksDictionary());

            //DataWriter.Write(myTask.GetDictionary());

            //todo: Ad2. tutaj ma być pętla czytająca input z klawiatury (1-3) a następnie ma wołać odpowiednie metody z obiektu kalendarz, aby obsługiwać flow
            // read input
            // jeśli 1 ->
            // {
            // input od usera
            // calendar.AddTask(input)

            // jeśli 2 ->
            // {
            // input od usera (opcjonalny - enter bez wpisania wartości powoduje wybranie wartości domyslnej)


            //Console.WriteLine("Wybierz sortowanie: 1 - dnienne, 2- tygodniowe, 3- jakieśtam, domyślnie dzienne");
            //var inp = Console.ReadLine();
            //if (inp == "")
            //    throw new NotImplementedException();


            // calendar.ReadTasks(input_opcjonalny)

            // jeśli 3 ->
            // end


        }



    }
}
