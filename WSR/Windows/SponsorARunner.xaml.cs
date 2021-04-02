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
using WSR.Windows;
//using System.Data;
//using System.Data.SqlClient;

namespace WSR.Windows
{
    /// <summary>
    /// Логика взаимодействия для Sponsorship.xaml
    /// </summary>
    public partial class SponsorARunner : Window
    {
        System.Windows.Threading.DispatcherTimer StartTimer = new System.Windows.Threading.DispatcherTimer();
        DateTime voteTime = new DateTime(2021, 11, 24, 6, 0, 0);

        public SponsorARunner()
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
        private void tb_GotFocus(object sender, RoutedEventArgs e)
        {
            TextBox textBox = (TextBox)sender;
            if (textBox.Text == "Ваше имя")
            {
                textBox.Text = "";
            }
            if (textBox.Text == "Владелец карты")
            {
                textBox.Text = "";
            }
            if (textBox.Text == "1234 1234 1234 1234")
            {
                textBox.Text = "";
            }
            if (textBox.Text == "01")
            {
                textBox.Text = "";
            }
            if (textBox.Text == "2017")
            {
                textBox.Text = "";
            }
            if (textBox.Text == "123")
            {
                textBox.Text = "";
            }
            if (textBox.Text == "50")
            {
                textBox.Text = "";
            }

        }
        private void tb_LostFocus(object sender, RoutedEventArgs e)
        {
            TextBox textBox = (TextBox)sender;
            if (textBox.Name == "tbName" && textBox.Text == "")
            {
                tbName.Text = "Ваше имя";
            }
            if (textBox.Name == "tbCard" && textBox.Text == "")
            {
                tbCard.Text = "Владелец карты";
            }
            if (textBox.Name == "tbNumOfCard" && textBox.Text == "")
            {
                tbNumOfCard.Text = "1234 1234 1234 1234";
            }
            if (textBox.Name == "tbDurationMonth" && textBox.Text == "")
            {
                tbDurationMonth.Text = "01";
            }
            if (textBox.Name == "tbDurationYear" && textBox.Text == "")
            {
                tbDurationYear.Text = "2017";
            }
            if (textBox.Name == "tbCVC" && textBox.Text == "")
            {
                tbCVC.Text = "123";
            }
            if (textBox.Name == "tbSum" && textBox.Text == "")
            {
                tbSum.Text = "50";
            }
        }

        private void btnPay_Click(object sender, RoutedEventArgs e)
        {
            DateTime Duration = new DateTime(Convert.ToInt32(tbDurationYear.Text), Convert.ToInt32(tbDurationMonth.Text), 1, 0, 0, 0);
            if (tbDurationYear.Text == "" || tbDurationYear.Text == "2017" || tbCVC.Text == "" || tbName.Text == "" || tbName.Text == "Ваше имя" || tbCard.Text == "" || tbCard.Text == "Владелец карты" || tbNumOfCard.Text == "" || tbNumOfCard.Text == "1234 1234 1234 1234" || tbDurationMonth.Text == "" || tbDurationMonth.Text == "01")
            {
                MessageBox.Show("Заполните все поля");

            }
            else if (tbNumOfCard.Text.Length != 16)
            {
                MessageBox.Show("Номер карты заполнен некорректно");
            }
            else if (tbDurationMonth.Text.Length != 2 || tbDurationYear.Text.Length != 4|| Convert.ToInt32(tbDurationMonth.Text)>12)
            {
                MessageBox.Show("Срок действия заполнен некорректно");
            }
            else if (tbCVC.Text.Length != 3)
            {
                MessageBox.Show("CVC заполнен некорректно");
            }
            else if (Duration <= DateTime.Now)
            {
                MessageBox.Show("Срок действия карты истек");
            }
            else
            {
                SponsorARunnerValidation sponsorARunnerValidation = new SponsorARunnerValidation(tbSum.Text);
                this.Close();
                sponsorARunnerValidation.ShowDialog();
            }
        }

        private void tbText_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            int val;
            if (int.TryParse(e.Text, out val))
            {
                e.Handled = true;
            }
        }
        private void tbNum_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            int val;
            if (!int.TryParse(e.Text, out val))
            {
                e.Handled = true;
            }
        }

        private void btnMoneyMinus_Click(object sender, RoutedEventArgs e)
        {
            tbSum.Text = Convert.ToString((Convert.ToInt32(tbSum.Text) - 10));
        }

        private void btnMoneyPlus_Click(object sender, RoutedEventArgs e)
        {
            tbSum.Text = Convert.ToString((Convert.ToInt32(tbSum.Text) + 10));
        }

        private void tbSum_TextChanged(object sender, TextChangedEventArgs e)
        {
            tbMoney.Text = tbSum.Text;
        }
    }
}
