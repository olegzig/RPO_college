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
    /// Логика взаимодействия для Tables.xaml
    /// </summary>
    public partial class Tables : Window
    {
        public Tables()
        {
            InitializeComponent();
            Closed += CloseAll;
        }

        private void Button_Return(object sender, RoutedEventArgs e)
        {
            Menu window = new Menu();
            window.Show();
            this.Close();
        }
        public void CloseAll(object sender, EventArgs e)
        {
            Menu window = new Menu();
            window.Show();
        }
    }
}
