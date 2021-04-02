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
using System.Threading;
using WSR.Windows;

namespace WSR
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class StartWindow : Window
    {
        System.Windows.Threading.DispatcherTimer StartTimer = new System.Windows.Threading.DispatcherTimer();
        DateTime voteTime = new DateTime(2021, 11, 24, 6, 0, 0);
        public StartWindow()
        {
            InitializeComponent();
            StartTimer.Tick += StartTimer_Tick;
            StartTimer.Interval = new TimeSpan(0,0,1);
            StartTimer.Start();
        }


        void StartTimer_Tick(object sender, EventArgs e)
        {
            TimeSpan TimeRemaining = voteTime - DateTime.Now;
            tbStartTimer.Text = TimeRemaining.Days + " дней " + TimeRemaining.Hours + " часов и " + TimeRemaining.Minutes + " минут до старта марафона ";
        }

        private void btnSponsorship_Click(object sender, RoutedEventArgs e)
        {
            SponsorARunner sponsorARunner = new SponsorARunner();
            this.Hide();
            sponsorARunner.ShowDialog();
            this.Show();
        }

        private void btnMoreInfo_Click(object sender, RoutedEventArgs e)
        {
            MoreInfo moreInfo = new MoreInfo();
            this.Hide();
            moreInfo.ShowDialog();
            this.Show();
        }

        private void btnLogin_Click(object sender, RoutedEventArgs e)
        {
            Autorization autorization = new Autorization();
            this.Hide();
            autorization.ShowDialog();
            this.Show();
        }

        private void btnRunnerCheck_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
