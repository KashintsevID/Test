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
        public StAppTakeBike(Context context, User curUser, Station curStation)
        {
            currentStation = curStation;
            currentUser = curUser;
            cont = context;
            InitializeComponent();
            UserName.Text = currentUser.FullName;
            Balance.Text = currentUser.Balance.ToString();
            this.DataGridBikes.ItemsSource = cont.Bicycles.Where(b => b.StationId == currentStation.Id).ToList();
        }

        private void ButtonUpdate_Click(object sender, RoutedEventArgs e)
        {
            Balance.Text = currentUser.Balance.ToString();
        }
        
        private void Exit_Click_1(object sender, RoutedEventArgs e)
        {
            var stAppEnter = new StAppEnter();
            Close();
            stAppEnter.Show();
        }

        private void ButtonTakeBike_Click(object sender, RoutedEventArgs e)
        {
            if (DataGridBikes.SelectedItem == null)
            {
                MessageBox.Show(" Выберите велосипед");
                return;
            }
            else if (decimal.Parse(Balance.Text) < 60)
            {
                MessageBox.Show(" На вашем счёте недостаточно средств\n Пополните баланс через мобильное приложение", "Недостаточно средств");
                return;
            }
            else
            {
                Bicycle selectedBike = DataGridBikes.SelectedItem as Bicycle;
                var lastWarning = new StAppTakeLastW(cont, currentUser, selectedBike);
                IsEnabled = false;
                if (lastWarning.ShowDialog() == true || lastWarning.IsActive == false)
                    Close();
            }
        }
    }
}
