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
            CheckingActiveRide();
            this.ListStations.ItemsSource = cont.Stations.OrderBy(s => s.NearestMetroStation).ToList();
            UserName.Text = currentUser.FullName;
            Balance.Text = currentUser.Balance.ToString();
            DataGridRides.ItemsSource = cont.Rides.Where(r => r.UserId == currentUser.Id && r.IsRideFinished == true).ToList();
            List<string> metroStations = new List<string>();
            foreach (Station station in cont.Stations)
            {
                if (!metroStations.Contains(station.NearestMetroStation))
                    metroStations.Add(station.NearestMetroStation);
            }
            ComboBoxMetro.ItemsSource = metroStations.OrderBy(m => m);
        }

        private void CheckingActiveRide()
        {
            foreach (Ride ride in cont.Rides)
            {
                if (ride.UserId == currentUser.Id && ride.IsRideFinished == false)
                {
                    ActiveRide.Text = $"Текущая поездка:\n Велосипед - {ride.BicycleId}\n Начало поездки - {ride.BeginingOfRide}";
                    return;
                }
            }
            ActiveRide.Text = "Нет активных поездок";
        }

        private void FilteringStations()
        {
            if (ComboBoxMetro.SelectedItem != null)
            {
                string metro = ComboBoxMetro.SelectedItem as string;
                List<Station> bikeStations = new List<Station>();
                bikeStations.AddRange(cont.Stations.Where(s => s.NearestMetroStation.Equals(metro)));
                ListStations.ItemsSource = bikeStations;
            }
            else
                ListStations.ItemsSource = cont.Stations.OrderBy(s => s.NearestMetroStation).ToList();
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
            var transfer = new TransferMoney(cont,currentUser);
            if (transfer.ShowDialog() == true || transfer.IsActive == false)
                IsEnabled = true;
            Balance.Text = currentUser.Balance.ToString();
        }

        private void RedactorAccount_Click(object sender, RoutedEventArgs e)
        {
            IsEnabled = false;
            var editingProfile = new ProfileEditing(cont, currentUser);
            if (editingProfile.ShowDialog() == true || editingProfile.IsActive == false)
                IsEnabled = true;
            UserName.Text = currentUser.FullName;
        }

        private void ComboBoxMetro_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            FilteringStations();
        }

        private void ButtonUpdate_Click(object sender, RoutedEventArgs e)
        {
            Balance.Text = currentUser.Balance.ToString();
            DataGridRides.ItemsSource = cont.Rides.Where(r => r.UserId == currentUser.Id && r.IsRideFinished == true).ToList();
            FilteringStations();
            CheckingActiveRide();
        }

        private void ButtonDeleteHistory_Click(object sender, RoutedEventArgs e)
        {
            foreach (Ride ride in cont.Rides)
            {
                if (ride.UserId == currentUser.Id && ride.IsRideFinished == true)
                    cont.Rides.Remove(ride);
            }
            cont.SaveChanges();
        }
    }
}
