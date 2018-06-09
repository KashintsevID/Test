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

namespace CycleApp
{
    /// <summary>
    /// Логика взаимодействия для Register.xaml
    /// </summary>
    public partial class Register : Window
    {
        public Register()
        {
            InitializeComponent();
            WriteFullName1.Focus();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(WriteFullName1.Text) || string.IsNullOrWhiteSpace(WriteEmail1.Text) || string.IsNullOrWhiteSpace(WritePassword1.Password))
            {
                MessageBox.Show("Not all options are filled");
            }
            else
            {
                User user = new User(WriteFullName1.Text, WriteEmail1.Text, WritePassword1.Password, false);
                // users.Add(user);
                Repository repo = new Repository();
                bool b = false;
                foreach (var u in repo.Users)
                {
                    if (user.Email == u.Email)
                    {
                        b = true;
                    }
                }
                if (b == false)
                {
                    Repository _repo = new Repository(user);
                }
                if (b == true)
                {
                    MessageBox.Show("The account is already exist");
                }

                MessageBox.Show("Registration was successful");
                Close();
                var main = new MainWindow();
                main.Show();

            }
        }
    }
}
