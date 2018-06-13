using Cycle.Info;
using Cycle.Info.Classes;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
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
            this.DataGridStations.ItemsSource = cont.Stations.OrderBy(s => s.NearestMetroStation).ToList();
            this.DataGridRides.ItemsSource = cont.Rides.Where(r => r.UserId == currentUser.Id).OrderBy(r => r.BeginingOfRide).ToList();
            UserName.Text = currentUser.FullName;
            Balance.Text = currentUser.Balance.ToString();
            List<string> metroStations = new List<string>();
            foreach (Station station in cont.Stations)
            {
                if (!metroStations.Contains(station.NearestMetroStation))
                    metroStations.Add(station.NearestMetroStation);
            }
            ComboBoxMetro.ItemsSource = metroStations.OrderBy(m => m);
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
            IsEnabled = false;
            var transfer = new TransferMoney(currentUser);
            if (transfer.ShowDialog() == true || transfer.IsActive == false)
            {
                IsEnabled = true;
            }
        }

        private void ComboBoxMetro_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            //if (ComboBoxMetro.SelectedItem != null)
            //{
            //    string metro = ComboBoxMetro.ItemsSource.ToString();
            //    List<Station> bikeStations = cont.Stations.Where(s => s.NearestMetroStation.Equals(metro)).ToList();
            //    DataGridStations.ItemsSource = bikeStations;
            //}
        }

        private void ButtonDeleteHistory_Click(object sender, RoutedEventArgs e)
        {
            foreach (Ride ride in cont.Rides)
            {
                if (ride.UserId == currentUser.Id)
                    cont.Rides.Remove(ride);
            }
            cont.SaveChanges();
        }

        private void RedactorAccount_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
