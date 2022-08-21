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
        CalendarTask myTask = new CalendarTask(DataReader.Read());
        public NewWindow()
        {
            InitializeComponent();

        }

        private void ComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }
        private void Text_Box(object sender, ContextMenuEventArgs e)
        {
            //text = textBoxTask.Text.ToString();

        }

        private void SaveTask(object sender, RoutedEventArgs e)

        {
            string text = textBoxTask.Text.ToString();
            DateTime dateTask = DateTime.Parse(taskCalendar.ToString());
            Priority priorityTask = (Priority)int.Parse(ComboBoxTask.Text);

            DateTime date = dateTask;
            string task = text;
            Priority priority = priorityTask;
            myTask.AddTask(date, task, priority);

            DataWriter.Write(myTask.GetTasksDictionary());

        }

    }
}

