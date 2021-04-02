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
using System.Data;
using System.Data.SqlClient;

namespace WSR.Windows
{
    /// <summary>
    /// Логика взаимодействия для Autorization.xaml
    /// </summary>
    public partial class Autorization : Window
    {
        SqlCommand cmd = new SqlCommand();
        SqlConnection conn = new SqlConnection("Server=.\\SQLEXPRESS;Database=WSRDB; Integrated Security=true");



        System.Windows.Threading.DispatcherTimer StartTimer = new System.Windows.Threading.DispatcherTimer();
        DateTime voteTime = new DateTime(2021, 11, 24, 6, 0, 0);
        public Autorization()
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
            if (textBox.Text == "Enter your email address")
            {
                textBox.Text = "";
            }
            if (textBox.Text == "Enter your password")
            {
                textBox.Text = "";
            }
        }
        private void tb_LostFocus(object sender, RoutedEventArgs e)
        {
            TextBox textBox = (TextBox)sender;
            if (textBox.Name == "tbEmail" && textBox.Text == "")
            {
                tbEmail.Text = "Enter your email address";
            }
            if (textBox.Name == "tbPas" && textBox.Text == "")
            {
                tbPas.Text = "Enter your password";
            }
        }
        private string CheckDB(string login, string password)
        {
            conn.Open();
            cmd = new SqlCommand("SELECT Email, Password, RoleId FROM [User] ", conn);
            SqlDataReader rd = cmd.ExecuteReader();
            string Id = "error";
            while (rd.Read())
            {
                string userLogin = rd["Email"].ToString();
                string passwordDB = rd["Password"].ToString();
                if (login == userLogin && password == passwordDB)
                {
                    Id = rd["RoleId"].ToString();
                    conn.Close();
                    return Id;
                }
            }
            return Id;
        }

        private void btnLogin_Click(object sender, RoutedEventArgs e)
        {
            if(CheckDB(tbEmail.Text, tbPas.Text) =="R")
            {
                RunnerMenu runnerMenu = new RunnerMenu();
                this.Hide();
                runnerMenu.ShowDialog();
            }
            else if (CheckDB(tbEmail.Text, tbPas.Text) == "С")
            {
                CoordinatorMenu coordinatorMenu = new CoordinatorMenu();
                this.Hide();
                coordinatorMenu.ShowDialog();
            }
            else if (CheckDB(tbEmail.Text, tbPas.Text) == "A")
            {

                AdministratorMenu administratorMenu = new AdministratorMenu();
                this.Hide();
                administratorMenu.ShowDialog();
            }
            else {
                MessageBox.Show("Логин или пароль указаны неверно");
            }
        }
    }
}
//private bool CheckDB(string login, string password)
//{
//    conn.Open();
//    cmd = new SqlCommand("SELECT Email, Password FROM [User] ", conn);
//    SqlDataReader rd = cmd.ExecuteReader();
//    bool comand = false;
//    while (rd.Read())
//    {
//        string userLogin = rd["Email"].ToString();
//        string passwordDB = rd["Password"].ToString();
//        if (login == userLogin && password == passwordDB)
//        {
//            conn.Close();
//            comand = true;
//            return comand;
//        }
//    }
//    return comand;
//}

//private void btnLogin_Click(object sender, RoutedEventArgs e)
//{
//    if (CheckDB(tbEmail.Text, tbPas.Text))
//    {
//        MessageBox.Show("УРА УРААА ");
//    }
//}