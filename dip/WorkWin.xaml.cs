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

namespace dip
{
    /// <summary>
    /// Логика взаимодействия для WorkWin.xaml
    /// </summary>
    public partial class WorkWin : Window
    {
        public WorkWin()
        {
            InitializeComponent();
        }

        private void Exp1_Collapsed(object sender, RoutedEventArgs e)
        {
            Grid.Height = 323;
        }

        private void Exp1_Expanded(object sender, RoutedEventArgs e)
        {
            Exp2.IsExpanded = false;
            Grid.Height = 240;
        }

        private void Exp2_Collapsed(object sender, RoutedEventArgs e)
        {
            Grid.Height = 323;
        }

        private void Exp2_Expanded(object sender, RoutedEventArgs e)
        {
            Exp1.IsExpanded = false;
            Grid.Height = 295;
        }

        private void Change_Click(object sender, RoutedEventArgs e)
        {
            this.Hide();
            MainWindow f = new MainWindow();
            f.ShowDialog();
            this.Close();
        }

        private void Exit_Click(object sender, RoutedEventArgs e)
        {
            System.Windows.Application.Current.Shutdown();
        }
    }
}
