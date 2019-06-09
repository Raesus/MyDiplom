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
using System.Data.SqlClient;

namespace dip
{
    /// <summary>
    /// Логика взаимодействия для Registr.xaml
    /// </summary>
    public partial class Registr : Window
    {
        public Registr()
        {
            InitializeComponent();
        }

        private void Regis_Click(object sender, RoutedEventArgs e)
        {
            SqlConnection con = new SqlConnection(@"Data Source=KRAI-ПК\SQLEXPRESS;Initial Catalog=Diplom;User ID=sa;Password=1234");
            con.Open();
            SqlCommand cmd = new SqlCommand("INSERT INTO [User] (Name, Role, Nmbr, Login, Psswrd) VALUES ('" + FIO.Text + "','Ученик','" + Numb.Text + "','" + Login.Text + "', '" + Pass.Text + "')", con);

            cmd.ExecuteNonQuery();
            con.Close();
            this.Hide();
            MainWindow f = new MainWindow();
            f.ShowDialog();
            this.Close();
        }

        private void Back_Click(object sender, RoutedEventArgs e)
        {
            this.Hide();
            MainWindow f = new MainWindow();
            f.ShowDialog();
            this.Close();
        }
    }
}
