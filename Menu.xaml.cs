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
                case "Учащиеся":
                    this.Hide();
                    tables.Show();
                    break;
                case "Выйти":
                    Environment.Exit(0);
                    break;
            }
        }
    }
}
/*
        <Button Grid.Column="0" Grid.Row="0" Content="Учащиеся" Click="Button_Click"/>
        <Button Grid.Column="1" Grid.Row="0" Content="Преподователи" Click="Button_Click"/>
        <Button Grid.Column="2" Grid.Row="0" Content="Диссертации" Click="Button_Click"/>
        <Button Grid.Column="0" Grid.Row="1" Content="Кафедры" Click="Button_Click"/>
        <Button Grid.Column="1" Grid.Row="1" Content="Преподователи и&#xa;дисциплины" Click="Button_Click"/>
        <Button Grid.Column="2" Grid.Row="1" Content="Преподователи и занятия" Click="Button_Click"/>
        <Button Grid.Column="0" Grid.Row="2" Content="Учащиеся и их оценки" Click="Button_Click"/>
        <Button Grid.Column="1" Grid.Row="2" Content="Отличники" Click="Button_Click"/>
        <Button Grid.Column="2" Grid.Row="2" Content="Экзаменаторы" Click="Button_Click"/>
        <Button Grid.Column="0" Grid.Row="3" Content="Экзаменаторы и оценки" Click="Button_Click"/>
        <Button Grid.Column="1" Grid.Row="3" Content="Дипломные работы" Click="Button_Click"/>
        <Button Grid.Column="2" Grid.Row="3" Content="Рудоводители дипломных&#xa;работ" Click="Button_Click"/>
        <Button Grid.Column="1" Grid.Row="4" Content="Нагрузка преподователей" Click="Button_Click"/>
        <Button Grid.Column="0" Grid.Row="4" Content="Разлогинится" Background="LightBlue" Click="Button_Click"/>
        <Button Grid.Column="2" Grid.Row="4" Content="Выйти" Background="IndianRed" Click="Button_Click"/>
 */
