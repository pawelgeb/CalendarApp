using CalendarTaskApp;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;

namespace CalendarTaskWPF
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        //private string text;
        CalendarTask myTask = new CalendarTask(DataReader.Read());
        public MainWindow()
        {
            InitializeComponent();
            List_Task.ItemsSource = myTask.GetTasksDictionary();
            foreach (var task in myTask.GetTasksDictionary())
            {

            }



            //text = "nasz nowy standardowy tedst";
            //naszTextBox.Text = text;
        }

        private void ListBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            NewWindow window2 = new NewWindow();
            window2.Show();
            //var result = MessageBox.Show(naszTextBox.Text, text, MessageBoxButton.YesNo);
            //if (result == MessageBoxResult.No)
            //{
            //    text = "kliknięto 'NO'";
            //    naszTextBox.Text = text;
            //}

            //if (result == MessageBoxResult.Yes)
            //{
            //    text = "kliknięto 'YES'";
            //    naszTextBox.Text = text;

        }

        private void ViewTask_ListView(object sender, ContextMenuEventArgs e)
        {




        }
    }
}

