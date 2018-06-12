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
            currentUser = curUser;
            InitializeComponent();
            NumberOfCard.Text = currentUser.CardNumber.ToString();
        }
        private void Click_Back(object sender, RoutedEventArgs e)
        {
            DialogResult = true;
            Close();
        }

    }
}
