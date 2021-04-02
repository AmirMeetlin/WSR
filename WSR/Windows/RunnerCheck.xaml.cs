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
    /// Логика взаимодействия для RunnerCheck.xaml
    /// </summary>
    public partial class RunnerCheck : Window
    {
        public RunnerCheck()
        {
            InitializeComponent();
        }
        private void btnBack_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
        private void btnLogin_Click(object sender, RoutedEventArgs e)
        {
            Autorization autorization = new Autorization();
            this.Hide();
            autorization.ShowDialog();
        }
    }
}
