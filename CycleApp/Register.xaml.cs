using Cycle.Info;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
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

namespace CycleApp
{
    /// <summary>
    /// Логика взаимодействия для Register.xaml
    /// </summary>
    public partial class Register : Window
    {
        private Context cont;
        public Register(Context context)
        {
            InitializeComponent();
            TextBoxFullName.Focus();
            cont = context;
        }

        private void ButtonRegister_Click(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(TextBoxFullName.Text))
            {
                MessageBox.Show(" Please, enter your full name", "Warning");
                TextBoxFullName.Focus();
                return;
            }
            if (string.IsNullOrWhiteSpace(TextBoxEmail.Text))
            {
                MessageBox.Show(" Please, enter your email", "Warning");
                TextBoxEmail.Focus();
                return;
            }
            if (string.IsNullOrWhiteSpace(PasswordBox.Password))
            {
                MessageBox.Show(" Please, enter your password", "Warning");
                PasswordBox.Focus();
                return;
            }

            foreach (var user in cont.Users)
            {
                if (user.Email == TextBoxEmail.Text)
                {
                    MessageBox.Show(" User with this email already exists\n Please try a different email", "Warning");
                    TextBoxEmail.Focus();
                    return;
                }
            }

            string NewFullName = TextBoxFullName.Text.Trim();
            string NewEmail = TextBoxEmail.Text.Trim();
            string NewPassword = User.GetHash(PasswordBox.Password.Trim());

            cont.Users.Add(new User()
            {
                FullName = NewFullName,
                Email = NewEmail,
                Password = NewPassword,
                CardNumber = 0,
                Balance = 0,
                BikeTaken = 0,
                BeginingOfRent = DateTime.Now
            }
            );
            cont.SaveChanges();

            MainWindow mainWindow = new MainWindow();
            mainWindow.Show();
            this.Close();
        }

        private void ButtonBack_Click(object sender, RoutedEventArgs e)
        {
            var mainWindow = new MainWindow();
            mainWindow.Show();
            this.Close();
        }
    }
}
