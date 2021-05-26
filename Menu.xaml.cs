using System;
using System.Windows;
using System.Windows.Controls;

namespace RPO_college
{
    /// <summary>
    /// Логика взаимодействия для Menu.xaml
    /// </summary>
    public partial class Menu : Window
    {
        public Menu()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Button btn = sender as Button;
            Tables tables;

            switch (btn.Content)
            {
                default:
                    tables = new Tables(btn.Content.ToString());
                    tables.Show();
                    this.Close();
                    break;

                case "Выйти":
                    Environment.Exit(0);
                    break;
                case "Разлогинится":
                    MainWindow window = new MainWindow();
                    window.Show();
                    this.Close();
                    break;
            }
        }
    }
}
