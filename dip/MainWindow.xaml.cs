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
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Data.SqlClient;

namespace dip
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

        private void LogIn_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                
                SqlConnection con = new SqlConnection(@"Data Source=KRAI-ПК\SQLEXPRESS;Initial Catalog=Diplom;User ID=sa;Password=1234");
                SqlCommand cmd = new SqlCommand("SELECT Role FROM [User] WHERE Login='" + Log.Text + "' AND Psswrd='" + Password.Password + "'", con);
                con.Open();
                string x = cmd.ExecuteScalar().ToString();
                if (x.Trim() == "Администратор")
                {

                    WorkWin f = new WorkWin();
                    this.Hide();
                    f.ShowDialog();
                    this.Close();
                }
                else if (x.Trim() == "Ученик" || x.Trim() == "Стажер" || x.Trim() == "Постоянный" || x.Trim() == "Гибкий")
                {
                    this.Hide();
                    MainWork f = new MainWork();
                    f.ShowDialog();
                    this.Close();
                }
                User.Login = Log.Text;
                User.pass = Password.Password.ToString();
                con.Close();
            }

            catch
            {
                MessageBox.Show("Ошибка!");
            }
        }

        private void Reg_Click(object sender, RoutedEventArgs e)
        {
            this.Hide();
            Registr f = new Registr();
            f.ShowDialog();
            this.Close();
        }
    }
}
