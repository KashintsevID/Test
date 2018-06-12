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
    /// Логика взаимодействия для Display.xaml
    /// </summary>
    public partial class Display : Window
    {
        private Context cont;
        private User currentUser;
        public Display(Context context, User curUser)
        {
            currentUser = curUser;
            cont = context;
            InitializeComponent();
            this.ListStations.ItemsSource = cont.Stations.ToList();

           

            UserName.Text = currentUser.FullName;
            Balance.Text = currentUser.Balance.ToString();
            foreach (var s in cont.Stations )
            {
                s.NumderOfAVAILABLESlots = s.NumberOfSlots - s.NumberOfBikes;
            }
          
        }

        private void Rules_Click(object sender, RoutedEventArgs e)
        {
            var rulesWindow = new Rules_of_renting_bicycles();
            Hide();
            rulesWindow.ShowDialog();
            Show();
            
        }

        private void Price_Click(object sender, RoutedEventArgs e)
        {
            var priceWindow = new Price();
            Hide();
            priceWindow.ShowDialog();
            Show();
        }

        private void Exit_Click(object sender, RoutedEventArgs e)
        {
            var mainWindow = new MainWindow();
            Close();
            mainWindow.Show();
        }

        private void AboutOurCompany_Click(object sender, RoutedEventArgs e)
        {
            var aboutCycle = new About_CYCLE();
            Hide();
            aboutCycle.ShowDialog();
            Show();
        }

        private void TransferMoney_Click(object sender, RoutedEventArgs e)
        {
            var transferMoney = new TransferMoney(cont, currentUser);
            transferMoney.ShowDialog();
        }
    }
}
