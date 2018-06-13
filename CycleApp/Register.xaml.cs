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
                MessageBox.Show(" Введите своё имя и фамилию", "Внимание");
                TextBoxFullName.Focus();
                return;
            }
            if (string.IsNullOrWhiteSpace(TextBoxEmail.Text))
            {
                MessageBox.Show(" Введите вашу почту", "Внимание");
                TextBoxEmail.Focus();
                return;
            }
            if (string.IsNullOrWhiteSpace(PasswordBox.Password))
            {
                MessageBox.Show(" Введите ваш пароль", "Внимание");
                PasswordBox.Focus();
                return;
            }

            foreach (var user in cont.Users)
            {
                if (user.Email == TextBoxEmail.Text)
                {
                    MessageBox.Show(" На данную почту уже зарегистрирован пользователь\n Попробуйте другой адрес", "Внимание");
                    TextBoxEmail.Focus();
                    return;
                }
            }

            string NewFullName = TextBoxFullName.Text.Trim();
            string NewEmail = TextBoxEmail.Text.Trim();
            string NewPassword = User.GetHash(PasswordBox.Password.Trim());

            User newUser = new User()
                {
                FullName = NewFullName,
                Email = NewEmail,
                Password = NewPassword,
                CardNumber = null,
                CardPassword = null,
                Balance = 0 };
            cont.Users.Add(newUser);
            cont.SaveChanges();

            Display display = new Display(cont, newUser);
            display.Show();
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
