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

namespace WSR.Windows
{
    /// <summary>
    /// Логика взаимодействия для MoreInfo.xaml
    /// </summary>
    public partial class MoreInfo : Window
    {
        System.Windows.Threading.DispatcherTimer StartTimer = new System.Windows.Threading.DispatcherTimer();
        DateTime voteTime = new DateTime(2021, 11, 24, 6, 0, 0);
        public MoreInfo()
        {
            InitializeComponent();
            StartTimer.Tick += StartTimer_Tick;
            StartTimer.Interval = new TimeSpan(0, 0, 1);
            StartTimer.Start();
        }

        void StartTimer_Tick(object sender, EventArgs e)
        {
            TimeSpan TimeRemaining = voteTime - DateTime.Now;
            tbStartTimer.Text = TimeRemaining.Days + " дней " + TimeRemaining.Hours + " часов и " + TimeRemaining.Minutes + " минут до старта марафона ";
        }
        private void btnBack_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void btnCharityOrgs_Click(object sender, RoutedEventArgs e)
        {
            CharityOrganizations charityOrganizations = new CharityOrganizations();
            this.Close();
            charityOrganizations.ShowDialog();
            
        }
    }
}
