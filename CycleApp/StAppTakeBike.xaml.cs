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
    /// Логика взаимодействия для StAppTakeBike.xaml
    /// </summary>
    public partial class StAppTakeBike : Window
    {
        private Context cont;
        private User currentUser;
        private Station currentStation;
        public StAppTakeBike(Context context,User curUser,Station curStation)
        {
            currentStation = curStation;
            currentUser = curUser;
            cont = context;

            InitializeComponent();
            UserName.Text = currentUser.FullName;
            Balance.Text = currentUser.Balance.ToString();
        }
        private bool TryGetSelectedBicycle(out Bicycle  bicycle)
        {
            bicycle = DGBicyclesOnStation.SelectedItem as Bicycle ;
            if (bicycle == null)
            {
                MessageBox.Show("Select an item from the table");
                return false;
            }
            return true;
        }
        private void ButtonTakyBike_Click(object sender, RoutedEventArgs e)
        {
            if (!TryGetSelectedBicycle(out var bicycle)) return;

            if (decimal.Parse(Balance.Text) >= 60)
            {
                var stAppTakeLastW = new StAppTakeLastW(bicycle);
                stAppTakeLastW.Show();
                Close();
            }
            else
            {
                MessageBox.Show("На вашем счёте недостаточно средств, пополните баланс через мобильное приложение"); 
            }
        }

        private void ButtonUpdate_Click(object sender, RoutedEventArgs e)
        {
            Balance.Text = currentUser.Balance.ToString();
        }

        private void Exit_Click(object sender, RoutedEventArgs e)
        {
            var stAppEnter = new StAppEnter();
            Close();
            stAppEnter.Show();
        }
    }
}
