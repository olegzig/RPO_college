using System;
using System.Data;
using System.Data.OleDb;
using System.Data.SqlClient;
using System.Windows;
using System.Windows.Media;

namespace RPO_college
{
    /// <summary>
    /// Логика взаимодействия для Tables.xaml
    /// </summary>
    public partial class Tables : Window
    {
        private readonly string getInfo;//readonly
        private readonly SqlDataAdapter da;
        private readonly DataSet ds;
        private SqlCommandBuilder cmd;
        //private readonly OleDbConnection DataBase = new OleDbConnection(@"Provider=Microsoft.Jet.OLEDB.4.0;Data Source=DB.mdb;Persist Security Info=True"); //readonly
        private readonly SqlConnection DataBase = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\boris\Source\Repos\olegzig\RPO_college\Database1.mdf;Integrated Security=True");

        public Tables(string WhatWasCho)
        {
            InitializeComponent();

            if (MainWindow.IsTeacher)
            {
                NotifyIfTeacher.Foreground = Brushes.Green;
                NotifyIfTeacher.Content = "Преподаватель";
            }
            else
            {
                NotifyIfTeacher.Foreground = Brushes.Red;
                NotifyIfTeacher.Content = "Учащийся";
            }
            Closed += Close;

            DataBase.Open();
            switch (WhatWasCho)
            {
                case "Учащиеся":
                    getInfo = "SELECT * FROM Учащиеся";
                    da = new SqlDataAdapter(getInfo, DataBase);
                    ds = new DataSet();

                    da.Fill(ds, "[Учащиеся]");
                    ds.Tables[0].TableName = "MyTable";
                    MyTable.ItemsSource = ds.Tables["MyTable"].DefaultView;
                    break;

                case "Преподаватели":
                    if (MainWindow.IsTeacher)
                    {
                        getInfo = "SELECT * FROM Преподаватели";
                    }
                    else
                    {
                        getInfo = "SELECT Код, ФИО, Факультет, Кафедра, Категория, Пол, Дети, Рождение, ЗП, [Тип_Занятий], [Руководитель_Курсовой] FROM Преподаватели";
                    }
                    da = new SqlDataAdapter(getInfo, DataBase);
                    ds = new DataSet();

                    da.Fill(ds, "[Преподаватели]");
                    ds.Tables[0].TableName = "MyTable";
                    MyTable.ItemsSource = ds.Tables["MyTable"].DefaultView;
                    break;

                case "Диссертации":
                    getInfo = "SELECT * FROM Диссертации";
                    da = new SqlDataAdapter(getInfo, DataBase);
                    ds = new DataSet();

                    da.Fill(ds, "[Диссертации]");
                    ds.Tables[0].TableName = "MyTable";
                    MyTable.ItemsSource = ds.Tables["MyTable"].DefaultView;
                    break;

                case "Кафедры":
                    getInfo = "SELECT Группа, Кафедра FROM Занятия";
                    da = new SqlDataAdapter(getInfo, DataBase);
                    ds = new DataSet();

                    da.Fill(ds, "[Занятия]");
                    ds.Tables[0].TableName = "MyTable";
                    MyTable.ItemsSource = ds.Tables["MyTable"].DefaultView;
                    break;

                case "Преподаватели и\nдисциплины":
                    getInfo = "SELECT ФИО, Кафедра FROM Преподаватели";
                    da = new SqlDataAdapter(getInfo, DataBase);
                    ds = new DataSet();

                    da.Fill(ds, "[Преподаватели]");
                    ds.Tables[0].TableName = "MyTable";
                    MyTable.ItemsSource = ds.Tables["MyTable"].DefaultView;
                    break;

                case "Занятия":
                    getInfo = "SELECT * FROM Занятия";
                    da = new SqlDataAdapter(getInfo, DataBase);
                    ds = new DataSet();

                    da.Fill(ds, "[Занятия]");
                    ds.Tables[0].TableName = "MyTable";
                    MyTable.ItemsSource = ds.Tables["MyTable"].DefaultView;
                    break;

                case "Учащиеся и их оценки":
                    getInfo = "SELECT * FROM Оценки";
                    da = new SqlDataAdapter(getInfo, DataBase);
                    ds = new DataSet();

                    da.Fill(ds, "[Оценки]");
                    ds.Tables[0].TableName = "MyTable";
                    MyTable.ItemsSource = ds.Tables["MyTable"].DefaultView;
                    break;

                case "Отличники":
                    getInfo = "SELECT * FROM Оценки WHERE Оценка > 7";
                    da = new SqlDataAdapter(getInfo, DataBase);
                    ds = new DataSet();

                    da.Fill(ds, "[Учащиеся]");
                    ds.Tables[0].TableName = "MyTable";
                    MyTable.ItemsSource = ds.Tables["MyTable"].DefaultView;
                    break;

                case "Экзаменаторы":
                    if (MainWindow.IsTeacher)
                    {
                        getInfo = "SELECT * FROM Преподаватели WHERE ([Руководитель_Курсовой] = true)";
                    }
                    else
                    {
                        getInfo = "SELECT ФИО, Факультет, Кафедра, Категория, Пол, Дети, Рождение, ЗП, [Руководитель_Курсовой], [Тип_Занятий], Код FROM Преподаватели WHERE ([Руководитель_Курсовой] = 1)";//тут мб из-за бита будет ошибка
                    }
                    da = new SqlDataAdapter(getInfo, DataBase);
                    ds = new DataSet();

                    da.Fill(ds, "[Преподаватели]");
                    ds.Tables[0].TableName = "MyTable";
                    MyTable.ItemsSource = ds.Tables["MyTable"].DefaultView;
                    break;

                case "Экзаменаторы и оценки":
                    getInfo = "SELECT * FROM [Экзамены и курсачи]";
                    da = new SqlDataAdapter(getInfo, DataBase);
                    ds = new DataSet();

                    da.Fill(ds, "[Учащиеся]");
                    ds.Tables[0].TableName = "MyTable";
                    MyTable.ItemsSource = ds.Tables["MyTable"].DefaultView;
                    break;

                case "Дипломные работы":
                    getInfo = "SELECT Оценка, ФИО, Дисциплина FROM[ДипломныеРаботы]";
                    da = new SqlDataAdapter(getInfo, DataBase);
                    ds = new DataSet();

                    da.Fill(ds, "[ДипломныеРаботы]");
                    ds.Tables[0].TableName = "MyTable";
                    MyTable.ItemsSource = ds.Tables["MyTable"].DefaultView;
                    break;

                case "Рудоводители дипломных\nработ":
                    getInfo = "SELECT Дисциплина, [ФИО_Руководителя] FROM[Дипломные работы]";
                    da = new SqlDataAdapter(getInfo, DataBase);
                    ds = new DataSet();

                    da.Fill(ds, "[Дипломные работы]");
                    ds.Tables[0].TableName = "MyTable";
                    MyTable.ItemsSource = ds.Tables["MyTable"].DefaultView;
                    break;

                case "Нагрузка преподавателей":
                    getInfo = "SELECT * FROM Нагрузка";
                    da = new SqlDataAdapter(getInfo, DataBase);
                    ds = new DataSet();

                    da.Fill(ds, "[Нагрузка]");
                    ds.Tables[0].TableName = "MyTable";
                    MyTable.ItemsSource = ds.Tables["MyTable"].DefaultView;
                    break;

                default:
                    MessageBox.Show("Вы всё сломали!");
                    break;
            }
            cmd = new SqlCommandBuilder(da);
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
            catch (Exception err)
            {
                MessageBox.Show(err.Message, "err with close bd", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void Button_Save(object sender, RoutedEventArgs e)
        {
            if (MainWindow.IsTeacher)
            {
                RemoveNullColumnFromDataset();
                da.Update(ds, "MyTable");
                MessageBox.Show("Saved");
            }
            else
            {
                MessageBox.Show("Вы не преподаватель", "Не удалось", MessageBoxButton.OK, MessageBoxImage.Warning);
            }
        }
        private void RemoveNullColumnFromDataset()
        {
            
            for (int i = ds.Tables[0].Rows.Count - 1; i >= 0; i--)
            {
                if (ds.Tables[0].Rows[i][1] == DBNull.Value)
                    ds.Tables[0].Rows[i].Delete();
            }
            ds.AcceptChanges();
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