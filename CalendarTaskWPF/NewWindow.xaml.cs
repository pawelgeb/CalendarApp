using CalendarTaskApp;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Windows;
using System.Windows.Controls;

namespace CalendarTaskWPF
{
    /// <summary>
    /// Interaction logic for NewWindow.xaml
    /// </summary>
    public partial class NewWindow : Window

    {
        public string text;
        private DateTime dateTask;
        private Priority priorityTask;
        public List<MyTask> myList = new List<MyTask>();

        public NewWindow()
        {
            InitializeComponent();

        }

        private void ComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }
        private void Text_Box(object sender, ContextMenuEventArgs e)
        {
            string text2;
            text2 = textBoxTask.Text.ToString();

        }

        private void Calendar_Task(object sender, ContextMenuEventArgs e)
        {
            dateTask = taskCalendar.DisplayDate;
        }

        private void ComboBox_Task(object sender, ContextMenuEventArgs e)
        {
            priorityTask = (Priority)int.Parse(ComboBoxTask.Text);
        }

        private void SaveTask(object sender, RoutedEventArgs e)
        {
            CalendarTask myTaskWPF = new CalendarTask(DataReader.Read());
            DateTime date = dateTask;
            string task = text;
            Priority priority = priorityTask;

            myTaskWPF.AddTask(date, task, priority);
            DataWriter.Write(myList);


        }

    }

    public class DataWriterWPF
    {
        readonly static string destPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "taskFileJson.json");

        public static void Write(List<string> text)
        {

            string dictionaryJson = JsonConvert.SerializeObject(text, Formatting.Indented);
            File.WriteAllText(destPath, dictionaryJson, System.Text.Encoding.UTF8);
        }

    }
}
