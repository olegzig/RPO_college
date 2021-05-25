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
        string getInfo;
        string WWC;
        OleDbDataAdapter da;
        DataSet ds;
        OleDbConnection DataBase = new OleDbConnection(@"Provider=Microsoft.Jet.OLEDB.4.0;Data Source=DB.mdb;Persist Security Info=True"); //readonly
        public Tables(string WhatWasCho)
        {
            InitializeComponent();

            WWC = WhatWasCho;
            Closed += Close;

            DataBase.Open();
            switch (WhatWasCho)
            {
                case "Учащиеся":
                    getInfo = "SELECT * FROM Учащиеся";
                    da = new OleDbDataAdapter(getInfo, DataBase);
                    ds = new DataSet();

                    da.Fill(ds, "[Учащиеся]");
                    ds.Tables[0].TableName = "MyTable";
                    MyTable.ItemsSource = ds.Tables["MyTable"].DefaultView;
                    break;
                case "Преподователи":
                    getInfo = "SELECT * FROM Преподователи";
                    da = new OleDbDataAdapter(getInfo, DataBase);
                    ds = new DataSet();

                    da.Fill(ds, "[Преподователи]");
                    ds.Tables[0].TableName = "MyTable";
                    MyTable.ItemsSource = ds.Tables["MyTable"].DefaultView;
                    break;
                case "Диссертации":
                    getInfo = "SELECT * FROM Диссертации";
                    da = new OleDbDataAdapter(getInfo, DataBase);
                    ds = new DataSet();

                    da.Fill(ds, "[Диссертации]");
                    ds.Tables[0].TableName = "MyTable";
                    MyTable.ItemsSource = ds.Tables["MyTable"].DefaultView;
                    break;
                case "Кафедры":
                    getInfo = "SELECT Группа, Кафедра FROM Занятия";
                    da = new OleDbDataAdapter(getInfo, DataBase);
                    ds = new DataSet();

                    da.Fill(ds, "[Занятия]");
                    ds.Tables[0].TableName = "MyTable";
                    MyTable.ItemsSource = ds.Tables["MyTable"].DefaultView;
                    break;
                case "Преподователи и\nдисциплины":
                    getInfo = "SELECT ФИО, Кафедра FROM Преподователи";
                    da = new OleDbDataAdapter(getInfo, DataBase);
                    ds = new DataSet();

                    da.Fill(ds, "[Преподователи]");
                    ds.Tables[0].TableName = "MyTable";
                    MyTable.ItemsSource = ds.Tables["MyTable"].DefaultView;
                    break;
                case "Занятия":
                    getInfo = "SELECT * FROM Занятия";
                    da = new OleDbDataAdapter(getInfo, DataBase);
                    ds = new DataSet();

                    da.Fill(ds, "[Занятия]");
                    ds.Tables[0].TableName = "MyTable";
                    MyTable.ItemsSource = ds.Tables["MyTable"].DefaultView;
                    break;
                case "Учащиеся и их оценки":
                    getInfo = "SELECT * FROM Оценки";
                    da = new OleDbDataAdapter(getInfo, DataBase);
                    ds = new DataSet();

                    da.Fill(ds, "[Оценки]");
                    ds.Tables[0].TableName = "MyTable";
                    MyTable.ItemsSource = ds.Tables["MyTable"].DefaultView;
                    break;
                case "Отличники":
                    getInfo = "SELECT * FROM Оценки WHERE Оценка > 7";
                    da = new OleDbDataAdapter(getInfo, DataBase);
                    ds = new DataSet();

                    da.Fill(ds, "[Учащиеся]");
                    ds.Tables[0].TableName = "MyTable";
                    MyTable.ItemsSource = ds.Tables["MyTable"].DefaultView;
                    break;
                case "Экзаменаторы":
                    getInfo = "SELECT * FROM Преподователи WHERE [Руководитель курсовой] = true";
                    da = new OleDbDataAdapter(getInfo, DataBase);
                    ds = new DataSet();

                    da.Fill(ds, "[Преподователи]");
                    ds.Tables[0].TableName = "MyTable";
                    MyTable.ItemsSource = ds.Tables["MyTable"].DefaultView;
                    break;
                case "Экзаменаторы и оценки":
                    getInfo = "SELECT * FROM [Экзамены и курсачи]";
                    da = new OleDbDataAdapter(getInfo, DataBase);
                    ds = new DataSet();

                    da.Fill(ds, "[Учащиеся]");
                    ds.Tables[0].TableName = "MyTable";
                    MyTable.ItemsSource = ds.Tables["MyTable"].DefaultView;
                    break;
                case "Дипломные работы":
                    getInfo = "SELECT Оценка, ФИО, Дициплина FROM[Дипломные работы]";
                    da = new OleDbDataAdapter(getInfo, DataBase);
                    ds = new DataSet();

                    da.Fill(ds, "[Дипломные работы]");
                    ds.Tables[0].TableName = "MyTable";
                    MyTable.ItemsSource = ds.Tables["MyTable"].DefaultView;
                    break;
                case "Рудоводители дипломных\nработ":
                    getInfo = "SELECT [ФИО Руководителя] FROM [Дипломные работы]";
                    da = new OleDbDataAdapter(getInfo, DataBase);
                    ds = new DataSet();

                    da.Fill(ds, "[Дипломные работы]");
                    ds.Tables[0].TableName = "MyTable";
                    MyTable.ItemsSource = ds.Tables["MyTable"].DefaultView;
                    break;
                case "Нагрузка преподователей":
                    getInfo = "SELECT * FROM Нагрузка";
                    da = new OleDbDataAdapter(getInfo, DataBase);
                    ds = new DataSet();

                    da.Fill(ds, "[Нагрузка]");
                    ds.Tables[0].TableName = "MyTable";
                    MyTable.ItemsSource = ds.Tables["MyTable"].DefaultView;
                    break;
                default:
                    MessageBox.Show("Вы всё сломали!");
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

        private void Button_Save(object sender, RoutedEventArgs e)
        {
            switch (WWC)
            {
                case "Учащиеся":

                    MessageBox.Show("save");
                    break;
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
        <Button Grid.Column="2" Grid.Row="1" Content="Занятия" Click="Button_Click"/>
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
