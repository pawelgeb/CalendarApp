namespace CalendarTaskApp
{
    internal class Program
    {

        //todo:
        /* 1. Dla każdego dnia można dodać więcej niż tylko jedno zadanie. Zadania są wyświetlane zgodnie z kolejnością dodawania. *Zadania mają swój priorytet (Priorytet to enum: Low, Medium, High, domyslnie zawsze Medium). Zadania wyświetlamy sortujac po priorytecie. Piorytet trzeba też pokazac
         * 2. Refaktor, Twój kalendarz ma być osobną klasą, która udostępnia metody publiczne, do jego obsługi. 
         * 3. Wyświetlanie tasków dla: dnia, tygodnia, miesiąca. Jeśli user wybierze wyświetlanie, to pytamy o to, czy chce zobaczyć listę wszystkich czy posortowane dla tygodnia/miesiąca/roku - w taki przypapadku grupujemy taski po wybranym.
         * 4. A może by dodać godzinę?
         */

        static void Main(string[] args)
        {

            CalendarTask myTask = new CalendarTask();
            myTask.CalendarAppGo();

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
