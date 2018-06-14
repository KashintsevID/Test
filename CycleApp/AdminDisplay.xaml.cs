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
    /// Логика взаимодействия для AdminDisplay.xaml
    /// </summary>
    public partial class AdminDisplay : Window
    {
        private Administrator administrator;
        private Context context;
        public AdminDisplay(Context cont, Administrator admin)
        {
            administrator = admin;
            context = cont;
            InitializeComponent();
            Login.Text = $"Текущий администратор: {administrator.Login}";
            List<Ride> oldRides = new List<Ride>();
            foreach (Ride ride in context.Rides)
            {
                TimeSpan totalTime = DateTime.Now - ride.BeginingOfRide;
                if (ride.IsRideFinished == false && totalTime.Days >= 2)
                    oldRides.Add(ride);
            }
            DataGridOldRides.ItemsSource = oldRides;
        }

        private void ButtonShowBadUser_Click(object sender, RoutedEventArgs e)
        {
            if (DataGridOldRides.SelectedItem != null)
            {
                User badUser;
                Ride selectedRide = DataGridOldRides.SelectedItem as Ride;
                foreach (User user in context.Users)
                {
                    if (user.Id == selectedRide.UserId)
                    {
                        badUser = user;
                        BadUserInfo.Text = $" Имя: {badUser.FullName}\n Почта: {badUser.Email}";
                        return;
                    }
                }
            }
            else
            {
                MessageBox.Show(" Выберите поле в таблице!"," Внимание!");
                return;
            }
        }

        private void ButtonExit_Click(object sender, RoutedEventArgs e)
        {
            var adminEnter = new AdminEnter();
            adminEnter.Show();
            Close();
        }
    }
}
