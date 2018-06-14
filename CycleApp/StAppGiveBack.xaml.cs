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
    /// Логика взаимодействия для StAppGiveBack.xaml
    /// </summary>
    public partial class StAppGiveBack : Window
    {
        private Context cont;
        private User currentUser;
        private Station currentStation;
        private Ride currentRide;
        private string totalRTime;
        private int hours, days, minutes;
       
        public StAppGiveBack(Context context, User curUser, Station curStation,Ride curRide)
        {
            currentRide = curRide;
            cont = context;
            currentUser = curUser;
            currentStation = curStation;
            InitializeComponent();
            Balance.Text = currentUser.Balance.ToString();
            HiddenButton.Visibility = Visibility.Hidden;
            HiddenLabel.Visibility = Visibility.Hidden;
            Surcharge.Visibility = Visibility.Hidden;
            FullName.Text = currentUser.FullName;
            TimeSpan totalTime = DateTime.Now - currentRide.BeginingOfRide;
            days = totalTime.Days;
            hours = totalTime.Hours;
            minutes = totalTime.Minutes;
            ActiveRide.Text =  (days + " дн. " + hours + " ч. " + minutes + " мин.");
            totalRTime =  ActiveRide.Text;
            if (currentRide.IsRideFinished == false && days >=2)
                Surcharge.Visibility = Visibility.Visible;
        }

        private void ButtonBackBike_Click(object sender, RoutedEventArgs e)
        {
            foreach (var b in cont.Bicycles )
            {
                if (b.StationId==currentStation.Id)
                    currentStation.BicyclesONStation.Add(b);
            }
            if (currentStation.NumberOfBikes != 0)
            {
                currentStation.BicyclesONStation.OrderBy(b => b.CurrentSlot);
                for (int i = 1; i <= currentStation.NumberOfSlots + currentStation.NumberOfBikes; i++)
                {
                    if (currentStation.BicyclesONStation.All(b => b.CurrentSlot != i))
                    {
                        NumberOfSlot.Text = i.ToString();
                        break;
                    }
                }
            }
            else
                NumberOfSlot.Text = "1";
            HiddenButton.Visibility = Visibility.Visible;
            HiddenLabel.Visibility = Visibility.Visible;
           
        }
        


        private void HiddenButton_Click(object sender, RoutedEventArgs e)
        {
            currentRide.Bicycle.CurrentSlot= int.Parse(NumberOfSlot.Text);
            currentRide.MoneyPaid = 60 + 2 * (days * 1440 + hours * 60 + minutes);
            currentRide.TotalRideTime = totalRTime;
            currentRide.IsRideFinished = true;
            currentRide.Bicycle.StationId = currentStation.Id;
            currentStation.NumberOfSlots -= 1;
            currentStation.NumberOfBikes += 1;
           
            decimal newBalance = currentUser.Balance - currentRide.MoneyPaid;
            if (days>=2)
                newBalance -=3000;
            currentUser.Balance = newBalance;
            MessageBox.Show(" Возврат совершён успешно!");
            cont.SaveChanges();
            var stAppEnter = new StAppEnter();
            stAppEnter.Show();
            this.Close();
        }
    }
}
