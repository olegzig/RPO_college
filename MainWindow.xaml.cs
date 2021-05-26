using System.Data;
using System.Data.OleDb;
using System.Windows;
using System.Windows.Controls;
using System.Linq;

namespace RPO_college
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        string getInfo;
        DataSet ds;
        OleDbConnection con;
        OleDbDataAdapter da;

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

            con = new OleDbConnection(@"Provider=Microsoft.Jet.OLEDB.4.0;Data Source=DB.mdb;Persist Security Info=True");//подключаем БД
            getInfo = "SELECT Пароль, ФИО FROM Преподователи";//Выбираем что получать
            ds = new DataSet();//создаём датасет
            da = new OleDbDataAdapter(getInfo, con);//создаём датаадаптер (отправляем запрос в БД?)
            da.Fill(ds,"Преподователи");//заполняем то что хранится в таблице "Преподователи" в ds
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
