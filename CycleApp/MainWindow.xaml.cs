using Cycle.Info;
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

namespace CycleApp
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private Context context = new Context();
        public MainWindow()
        {
            InitializeComponent();
            CopyDatatoDB(context);   //не использовать без необходимости
        }

        static void CopyDatatoDB(Context context)  //метод для заполнения базы данных
        {
            DBRepository dbrepo = new DBRepository();

            context.Bicycles.AddRange(dbrepo.Bicycles);
            context.Stations.AddRange(dbrepo.Stations);
            context.SaveChanges();
        }

        private void ButtonRegister_Click(object sender, RoutedEventArgs e)
        {
            var registerWindow = new Register(context);
            registerWindow.Show();
            Hide();
        }

        private void ButtonLogin_Click(object sender, RoutedEventArgs e)
        {
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

            foreach (var user in context.Users)
            {
                if ((user.Email == TextBoxEmail.Text) && (user.Password == User.GetHash(PasswordBox.Password.Trim())))
                {
                    User currentUser = user;
                    var display = new Display(context, currentUser);
                    display.Show();
                    this.Close();
                    return;
                }
            }

            MessageBox.Show(" Email or password were written incorrectly\n Please try again or register", "No such user");
            return;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            User us = new User();
            var dispW = new Display(context,us);

        }
    }
}
