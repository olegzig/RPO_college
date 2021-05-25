using System;
using System.Collections.Generic;
using System.Data;
using System.Data.OleDb;
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
    /// Логика взаимодействия для Tables.xaml
    /// </summary>
    public partial class Tables : Window
    {
        OleDbConnection DataBase = new OleDbConnection(@"Provider=Microsoft.Jet.OLEDB.4.0;Data Source=DB.mdb;Persist Security Info=True");
        public Tables(string WhatWasCho)
        {
            InitializeComponent();

            DataBase.Open();
            Closed += Close;


            switch (WhatWasCho)
            {
                case "Учащиеся":
                    string getInfo = "SELECT * FROM Учащиеся";
                    OleDbDataAdapter da = new OleDbDataAdapter(getInfo, DataBase);
                    OleDbCommandBuilder cb = new OleDbCommandBuilder(da);
                    DataSet ds = new DataSet();

                    da.Fill(ds, "[Учащиеся]");
                    ds.Tables[0].TableName = "table";
                    table.ItemsSource = ds.Tables["table"].DefaultView;

                    break;
            }
        }

        private void Button_Return(object sender, RoutedEventArgs e)
        {
            Menu window = new Menu();
            window.Show();
            this.Close();
        }
        private void Close(object sender, EventArgs e)
        {
            try
            {
                DataBase.Close();
            }
            catch
            {
                //Hello world!
            }
        }
    }
}
//WhatWasClosed
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
