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

        public MainWindow()
        {
            InitializeComponent();

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
    }
}

