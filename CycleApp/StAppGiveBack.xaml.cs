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
            HiddenButton.Visibility = Visibility.Hidden;
            HiddenLabel.Visibility = Visibility.Hidden;
            Surcharge.Visibility = Visibility.Hidden;
            FullName.Text = currentUser.FullName;
            if (currentRide.IsRideFinished==false)
                Surcharge.Visibility = Visibility.Visible;
            TimeSpan totalTime = DateTime.Now - currentRide.BeginingOfRide;
            days = totalTime.Days;
            hours = totalTime.Hours;
            minutes = totalTime.Minutes;
            ActiveRide.Text =  (days + "дн " + hours + "ч " + minutes + "мин");
            totalRTime =  ActiveRide.Text;
        }

        private void ButtonBackBike_Click(object sender, RoutedEventArgs e)
        {
            foreach (var b in cont.Bicycles )
            {
                if (b.StationId==currentStation.Id)
                    currentStation.BicyclesONStation.Add(b);
            }
            currentStation.BicyclesONStation.OrderBy(b => b.CurrentSlot);
            for (int i = 0; i < currentStation.NumberOfSlots+currentStation.NumberOfBikes; i++)
            {
                if (currentStation.BicyclesONStation.All(b=>b.CurrentSlot!=i))
                {
                    NumberOfSlot.Text = i.ToString();
                    break ;
                }
            }
            HiddenButton.Visibility = Visibility.Visible;
            HiddenLabel.Visibility = Visibility.Visible;
           
        }
        


        private void HiddenButton_Click(object sender, RoutedEventArgs e)
        {
            currentRide.Bicycle.CurrentSlot= int.Parse(NumberOfSlot.Text);
            currentRide.MoneyPaid = 2 * (days * 1440 + hours * 60 + minutes);
            currentRide.TotalRideTime = totalRTime;
            currentRide.IsRideFinished = true;
            currentRide.Bicycle.StationId = currentStation.Id;
            currentStation.NumberOfSlots -= 1;
            currentStation.NumberOfBikes += 1;
           
            decimal newBalance = currentUser.Balance - currentRide.MoneyPaid;
            if (days>=2)
                newBalance -=3000;
            if (newBalance >= 0)
                currentUser.Balance = newBalance ;
            else
            {
                currentUser.Balance = newBalance;
                MessageBox.Show("На вашем счете недостаточно средств, пополните баланс через мобильное приложение.Вы не сможете совершить следующую поездку, пока Ваш баланс отрицателен.");
            }
            cont.SaveChanges();
            var stAppEnter = new StAppEnter();
            stAppEnter.Show();
            this.Close();
        }
    }
}
