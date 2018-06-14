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
       
       
        public StAppGiveBack(Context context, User curUser, Station curStation,Ride curRide)
        {
            currentRide = curRide;
            cont = context;
            currentUser = curUser;
            currentStation = curStation;
            InitializeComponent();
            HiddenButton.Visibility = Visibility.Hidden;
            HiddenLabel.Visibility = Visibility.Hidden;
            NumberOfSlot.Visibility = Visibility.Hidden;
            Surcharge.Visibility = Visibility.Hidden;
            if (currentRide.IsRideFinished==false)
            {
                Surcharge.Visibility = Visibility.Visible;
            }


        }

        private void ButtonBackBike_Click(object sender, RoutedEventArgs e)
        {
            for (int i = 0; i < currentStation.NumberOfSlots; i++)
            {
                if (currentStation.BicyclesONStation.All(b=>b.CurrentSlot!=i))
                {
                    NumberOfSlot.Text = i.ToString();
                    break ;
                }
            }
            HiddenButton.Visibility = Visibility.Visible;
            HiddenLabel.Visibility = Visibility.Visible;
            NumberOfSlot.Visibility = Visibility.Visible;
        }

        private void HiddenButton_Click(object sender, RoutedEventArgs e)
        {
             TimeSpan totalTime = DateTime.Now - currentRide.BeginingOfRide;
            int days = totalTime.Days;
            int hours = totalTime.Hours;
            int minutes = totalTime.Minutes;
            int currentSlot = int.Parse(NumberOfSlot.Text);
           
            currentRide.MoneyPaid = 2 * (days * 1440 + hours * 60 + minutes);
            currentRide.TotalRideTime = (days + " дн " + hours + " ч " + minutes + " мин");
            currentRide.IsRideFinished = true;
            currentRide.Bicycle.StationId = currentStation.Id;
            currentRide.Bicycle.CurrentSlot = currentSlot;
            currentStation.NumberOfBikes += 1;
           
            decimal newBalance = currentUser.Balance - currentRide.MoneyPaid;
            if (days>=2)
                currentUser.Balance = currentUser.Balance - currentRide.MoneyPaid-3000;
            if (newBalance >= 0)
            {
                currentUser.Balance = currentUser.Balance - currentRide.MoneyPaid;
            }
            else
            {
                currentUser.Balance = currentUser.Balance - currentRide.MoneyPaid;
                MessageBox.Show("На вашем счете недостаточно средств, пополните баланс через мобильное приложение.Вы не сможете совершить следующую поездку, пока Ваш баланс отрицателен.");
            }
            cont.SaveChanges();
            var stAppEnter = new StAppEnter();
            stAppEnter.Show();
            this.Close();
        }
    }
}
