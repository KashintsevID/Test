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
    /// Логика взаимодействия для StAppTakeLastW.xaml
    /// </summary>
    public partial class StAppTakeLastW : Window
    {
        private Context context;
        private User currentUser;
        private Bicycle bicycle;
        private Station currentStation;
        public StAppTakeLastW(Context cont, User curUser, Station curStation, Bicycle bike)
        {
            context = cont;
            bicycle = bike;
            currentUser = curUser;
            currentStation = curStation;
            InitializeComponent();
            NumserOsSlot.Text = bicycle.CurrentSlot.ToString();
        }

        private void ButtonEnd_Click(object sender, RoutedEventArgs e)
        {
            currentStation.NumberOfBikes -= 1;
            currentStation.NumberOfSlots += 1;
            bicycle.StationId = null;
            context.Rides.Add(new Ride
            {
                UserId = currentUser.Id,
                BicycleId = bicycle.Id,
                BeginingOfRide = DateTime.Now,
                TotalRideTime = null,
                MoneyPaid = 0,
                IsRideFinished = false
            });
            currentUser.Balance -= 60;
            context.SaveChanges();
            MessageBox.Show(" Операция успешно проведена");
            var stAppEnter = new StAppEnter();
            stAppEnter.Show();
            this.Close();
        }

        private void ButtonCancel_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }
    }
}
