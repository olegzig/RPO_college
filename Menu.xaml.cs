using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

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
            Tables tables = new Tables();

            switch (btn.Content)
            {
                default:
                    this.Close();
                    WhatWasChoosed.BUF = btn.Content.ToString();
                    tables.Show();
                    break;

                case "Выйти":
                    Environment.Exit(0);
                    break;
                case "Разлогинится":
                    this.Close();
                    MainWindow window = new MainWindow();
                    window.Show();
                    break;
            }
        }
    }
    public static class WhatWasChoosed 
    {
        public static string BUF;
    }

}
