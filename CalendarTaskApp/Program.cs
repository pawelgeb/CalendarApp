using System;
using System.Collections.Generic;

namespace CalendarTaskApp
{

    internal class Program
    {

        //todo:
        /* 1. Dla każdego dnia można dodać więcej niż tylko jedno zadanie. Zadania są wyświetlane zgodnie z kolejnością dodawania. *Zadania mają swój priorytet (Priorytet to enum: Low, Medium, High, domyslnie zawsze Medium). Zadania wyświetlamy sortujac po priorytecie. Piorytet trzeba też pokazac
         * 2. Refaktor, Twój kalendarz ma być osobną klasą, która udostępnia metody publiczne, do jego obsługi. Odczyt i zapis pliku powinien być w osobnej klsie (np FileReader i FileWriter)
         * 3. Wyświetlanie tasków dla: dnia, tygodnia, miesiąca. Jeśli user wybierze wyświetlanie, to pytamy o to, czy chce zobaczyć listę wszystkich czy posortowane dla tygodnia/miesiąca/roku - w taki przypapadku grupujemy taski po wybranym.
         * 4. Usuwanie zadań, które zostały wykonane! * Usuwanie przez oznaczenie flagi isActive = false; ;)
         * 5. Serializacja do JSON'a
         */


        static void Main(string[] args)
        {
            Dictionary<DateTime, List<MyTask>> dictionary = new Dictionary<DateTime, List<MyTask>>();

            DateTime key;
            int userNumber;

            CalendarTask myTask = new CalendarTask(DataReader.Read());
            Console.WriteLine("Welcome to Calendar App");
            do
            {
                myTask.CalendarDisplay();
                userNumber = InputFromUser.numberUser();
                switch (userNumber)
                {
                    case 1:
                        {
                            Console.WriteLine("Please enter date (dd/MM/yyyy)");
                            string keyString;
                            keyString = Console.ReadLine();
                            key = DateTime.Parse(keyString);
                            Console.WriteLine("Please enter task");
                            string task = Console.ReadLine();
                            myTask.AddTask(key, task);
                            break;
                        }
                    case 2:
                        {
                            dictionary = myTask.GetTasksDictionary();
                            foreach (DateTime key2 in dictionary.Keys)
                            {
                                foreach (MyTask val in dictionary[key2])
                                {
                                    Console.WriteLine($"Date: {key2.ToShortDateString()}, Task: {val}");
                                }
                            }

                            break;
                        }
                    case 3:
                        {
                            break;
                        }
                }
            }
            while (userNumber != 3);

            DataWriter.Write(dictionary);

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
