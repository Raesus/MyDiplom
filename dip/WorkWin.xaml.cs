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
using System.Windows.Threading;

namespace dip
{
    /// <summary>
    /// Логика взаимодействия для WorkWin.xaml
    /// </summary>
    public partial class DispatcherTimerSample : Window
    {
        DispatcherTimer timer = new DispatcherTimer();
        DispatcherTimer timer2 = new DispatcherTimer();
        int s = 1;
        int m = 0;
        int H = 0;
        int s2 = 1;
        int m2 = 0;
        int H2 = 0;
        public DispatcherTimerSample()
            {
                InitializeComponent();

                timer.Interval = TimeSpan.FromSeconds(1);
                timer2.Interval = TimeSpan.FromSeconds(1);
                timer2.Tick += Timer_Tick2;
                timer.Tick += Timer_Tick;

            }

            void Timer_Tick(object sender, EventArgs e)
            {
                WTime.Content = H + ":" + m + ":" +s;

                if (m < 60)
                {
                    if (s < 59)
                    {
                        s++;
                    }
                    else if (s >= 59)
                    {
                        m++;
                        s = 0;
                    }

                }
                else if (m == 60 && s >= 59)
                {
                    m = 0;
                    s = 0;
                    H++;
                }
            }
        void Timer_Tick2(object sender, EventArgs e)
        {
            PTime.Content = H2 + ":" + m2 + ":" + s2;

            if (m2 < 60)
            {
                if (s2 < 59)
                {
                    s2++;
                }
                else if (s >= 59)
                {
                    m2++;
                    s2 = 0;
                }

            }
            else if (m2 == 60 && s2 >= 59)
            {
                m2 = 0;
                s2 = 0;
                H2++;
            }
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

        private void Start_Click(object sender, RoutedEventArgs e)
        {
            timer.Start();
            timer2.Stop();
        }

        private void Pause_Click(object sender, RoutedEventArgs e)
        {
            timer.Stop();
            timer2.Start();
        }
    }
}
