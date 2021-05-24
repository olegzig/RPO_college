﻿using System;
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
using System.Windows.Navigation;
using System.Windows.Shapes;

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

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            login.Visibility = Visibility.Hidden;
            thcr.Visibility = Visibility.Visible;
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            login.Visibility = Visibility.Hidden;
            stud.Visibility = Visibility.Visible;
        }

        private void Button_Back(object sender, RoutedEventArgs e)
        {
            Button btn = sender as Button;

            if(btn.Parent == stud)
            {
                stud.Visibility = Visibility.Hidden;
                login.Visibility = Visibility.Visible;
            }
            else
            {
                thcr.Visibility = Visibility.Hidden;
                login.Visibility = Visibility.Visible;
            }
        }

        private void Button_Loin(object sender, RoutedEventArgs e)
        {
            Menu menu = new Menu();
            menu.Show();
            this.Visibility = Visibility.Hidden;
        }
        
    }
}
