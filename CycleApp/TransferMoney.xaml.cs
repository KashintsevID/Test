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
    /// Логика взаимодействия для TransferMoney.xaml
    /// </summary>
    public partial class TransferMoney : Window
    {
        private Context cont;
        private User currentUser;
        public TransferMoney(Context context, User curUser)
        {
            cont = context;
            currentUser=curUser;
            InitializeComponent();
            
            foreach (var user in cont.Users)
            {
                if (user.Email == currentUser.Email)
                {
                    if (user.CardNumber == null)
                    {
                        NumberOfCard.Text = "Карта не добавлена";
                    }
                    else
                    {
                       NumberOfCard.Text = user.CardNumber;
                    }
                   
                }
            }
            }
      
        private void ButtonReturn_Click(object sender, RoutedEventArgs e)
        {
            DialogResult  = true;
            Close();
        }

        

        private void ButtonAddMoney_Click(object sender, RoutedEventArgs e)
        {
            if (Sum.Text == "Введите сумму")
            {
                MessageBox.Show("Вы не ввели сумму");
            }
            else
            {
                
                foreach (var user in cont.Users)
                {
                    if (user.Email == currentUser.Email)
                    {
                        user.Balance += decimal.Parse(Sum.Text);

                    }
                }
                cont.SaveChanges();
                MessageBox.Show("Баланс пополнен на " + int.Parse(Sum.Text) + "рублей");
            }
        }
        private void Update(Context cont,User currentUser)
        {
            foreach (var user in cont.Users)
            {
                if (user.Email == currentUser.Email)
                {
                    if (user.CardNumber == null)
                    {
                        NumberOfCard.Text = "Карта не добавлена";
                    }
                    else
                    {
                        NumberOfCard.Text = user.CardNumber;
                    }
                }
            }
        }

        private void ButtonChangeCard_Click(object sender, RoutedEventArgs e)
        {
            this.Visibility = Visibility.Hidden;
            var changeCardWindow = new ChangeCard(cont,currentUser);
            changeCardWindow.ShowDialog();
            Update(cont,currentUser);
            this.Visibility = Visibility.Visible;


        }
    }
}
