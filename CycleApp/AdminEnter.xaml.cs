using Cycle.Info;
using Cycle.Info.Classes;
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
    /// Логика взаимодействия для AdminEnter.xaml
    /// </summary>
    public partial class AdminEnter : Window
    {
        private Context context = new Context();
        public AdminEnter()
        {
            InitializeComponent();
            TextBoxLogin.Focus();
        }

        private void ButtonEnter_Click(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(TextBoxLogin.Text))
            {
                MessageBox.Show(" Введите ваш логин", "Внимание");
                TextBoxLogin.Focus();
                return;
            }

            if (string.IsNullOrWhiteSpace(PasswordBox.Password))
            {
                MessageBox.Show(" Введите ваш пароль", "Внимание");
                PasswordBox.Focus();
                return;
            }

            foreach (Administrator admin in context.Administrators)
            {
                if ((admin.Login == TextBoxLogin.Text) && (admin.Password == PasswordBox.Password.Trim()))
                {
                    Administrator currentAdmin = admin;
                    var display = new AdminDisplay(context, currentAdmin);
                    display.Show();
                    this.Close();
                    return;
                }
            }

            MessageBox.Show(" Логин или пароль были введены некорректно\n Повторите ввод", "Администратор не найден");
            return;
        }
    }
}
