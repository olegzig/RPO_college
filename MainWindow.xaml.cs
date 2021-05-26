using System.Windows;
using System.Windows.Controls;

namespace RPO_college
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)//задейстуется если чел входит как учитель
        {
            login.Visibility = Visibility.Hidden;
            thcr.Visibility = Visibility.Visible;
        }

        private void Button_Back(object sender, RoutedEventArgs e)
        {
            Button btn = sender as Button;

            thcr.Visibility = Visibility.Hidden;
            login.Visibility = Visibility.Visible;
        }

        private void Button_Loin(object sender, RoutedEventArgs e)//тут проверять
        {
            Menu menu = new Menu();
            menu.Show();
            this.Close();
        }
    }
}
