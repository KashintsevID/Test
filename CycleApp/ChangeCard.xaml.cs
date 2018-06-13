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
using System.Windows.Shapes;

namespace CycleApp
{
    /// <summary>
    /// Логика взаимодействия для ChangeCard.xaml
    /// </summary>
    public partial class ChangeCard : Window
    {
        private Context cont;
        private User currentUser;
        public ChangeCard(Context context, User curUser)
        {
            currentUser = curUser;
            cont = context;
            InitializeComponent();
        }
        private void Back_Click(object sender, RoutedEventArgs e)
        {
            DialogResult = true;
            Close();
        }

        private void ButtonChangeCard_Click(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrEmpty(NumberC.Text) || string.IsNullOrEmpty(PasswordC.Password))
            {
                MessageBox.Show("Не все поля заполнены");
            }
            else{
                //currentUser.CardNumber = NumberC.Text;
                foreach (var user in cont.Users)
                {
                    if (user.Email ==currentUser.Email)
                    {
                        user.CardNumber = NumberC.Text;
                        
                    }
                }
                cont.SaveChanges();
                MessageBox.Show("Карта изменена");
                DialogResult = true;
                Close();
            }
        }
    }
}
