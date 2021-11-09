using System.Data;
using System.Data.Sql;
using System.Windows;
using System.Windows.Controls;
using System.Linq;
using System.Data.SqlClient;

namespace RPO_college
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        string getInfo;
        DataSet ds;
        SqlConnection con;
        SqlDataAdapter da;

        static bool _isTeacher;
        static bool _isTryLoginAsTeacher;
        public static bool IsTeacher { get => _isTeacher; set => _isTeacher = value; }//t = вошёл как учитель
        public static bool IsTryLoginAsTeacher { get => _isTryLoginAsTeacher; set => _isTryLoginAsTeacher = value; }//t = пытается войти как учитель

        public MainWindow()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)//задейстуется если чел входит как учитель
        {
            login.Visibility = Visibility.Hidden;
            thcr.Visibility = Visibility.Visible;

            con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=|DataDirectory|\Database1.mdf;Integrated Security=True;;Connect Timeout=30");//подключаем БД
            getInfo = "SELECT Пароль, ФИО FROM Преподаватели";//Выбираем что получать
            ds = new DataSet();//создаём датасет
            da = new SqlDataAdapter(getInfo, con);//создаём датаадаптер (отправляем запрос в БД?)
            da.Fill(ds,"Преподаватели");//заполняем то что хранится в таблице "Преподователи" в ds
            con.Close();//закрываем подключение
            IsTryLoginAsTeacher = true;
        }

        private void Button_Back(object sender, RoutedEventArgs e)
        {
            thcr.Visibility = Visibility.Hidden;
            login.Visibility = Visibility.Visible;
            IsTryLoginAsTeacher = false;
        }

        private void Button_Loin(object sender, RoutedEventArgs e)//тут проверять
        {
            Button button = sender as Button;
            if(button.Content.ToString() == "Войти как ученик")
            {
                IsTryLoginAsTeacher = false;
                IsTeacher = false;
            }

            if (IsTryLoginAsTeacher)
            {
                foreach(DataTable dt in ds.Tables)
                {
                    foreach(DataRow dr in dt.Rows)
                    {
                        var cells = dr.ItemArray;

                        if (cells[0].ToString() == Поле_Пароль.Text && cells[1].ToString() == Поле_Логин.Text)//passw, FIO А.В.Варлокович
                        {
                            IsTeacher = true;
                            Menu menu = new Menu();
                            menu.Show();
                            this.Close();
                            return;
                        }
                    }
                    MessageBox.Show("Неправильный логин или пароль", "Ошибка", MessageBoxButton.OK);
                }
            }
            else
            {
                Menu menu = new Menu();
                menu.Show();
                this.Close();
            }
        }
    }
}
