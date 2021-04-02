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
    /// Логика взаимодействия для RunnerMenu.xaml
    /// </summary>
    public partial class RunnerMenu : Window
    {
        public RunnerMenu()
        {
            InitializeComponent();
        }
        private void btnBack_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void btnContacts_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Контактная информация Marathon Skills 2016");
        }
    }
}
