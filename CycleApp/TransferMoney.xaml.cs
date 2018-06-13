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
            StackPanelPassword.Visibility = Visibility.Hidden;
            if (currentUser.CardNumber != null)
                NumberOfCard.Text = currentUser.CardNumber.ToString();
            else
            {
                NumberOfCard.Text = "Нет карты оплаты";
                StackPanelSum.IsEnabled = false;
            }
        }
            
        private void ButtonReturn_Click(object sender, RoutedEventArgs e)
        {
            DialogResult  = true;
            Close();
        }
        
        private void ButtonAddMoney_Click(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(Sum.Text) || int.Parse(Sum.Text) <= 0 || !Sum.Text.All(char.IsDigit))
            {
                MessageBox.Show(" Вы не ввели сумму корректно", "Внимание");
                return;
            }
            else
                StackPanelPassword.Visibility = Visibility.Visible;
        }

        private void Update(Context cont,User currentUser)
        {
            if (currentUser.CardNumber == null)
                NumberOfCard.Text = "Карта не добавлена";
            else
                NumberOfCard.Text = currentUser.CardNumber.ToString();
        }

        private void ButtonChangeCard_Click(object sender, RoutedEventArgs e)
        {
            var changeCardWindow = new ChangeCard(cont,currentUser);
            changeCardWindow.ShowDialog();
            StackPanelSum.IsEnabled = true;
            Update(cont,currentUser);
        }

        private void ButtonConfirm_Click(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrEmpty(Password.Password) || currentUser.CardPassword != User.GetHash(Password.Password))
            { 
                MessageBox.Show(" Введите пароль от карты корректно", "Внимание");
                return;
            }
            else
            {
                currentUser.Balance += decimal.Parse(Sum.Text);
                cont.SaveChanges();
                MessageBox.Show("Баланс пополнен на " + int.Parse(Sum.Text) + " рублей");
                this.Close();
            }
        }
    }
}
