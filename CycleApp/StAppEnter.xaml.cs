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
    /// Логика взаимодействия для StAppEnter.xaml
    /// </summary>
    public partial class StAppEnter : Window
    {
        private Station currentStation;
        private Context context = new Context();
        public StAppEnter()
        {
            InitializeComponent();
            TextBoxEmail.Focus();
            foreach (var station in context.Stations)
            {
                if (station.Adress=="ул. Крымский Вал, д.3")
                    currentStation = station;
            }
            StationName.Text = currentStation.Adress.ToString();
        }

        private void ButtonLogin_Click(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(TextBoxEmail.Text))
            {
                MessageBox.Show(" Введите вашу почту", "Внимание");
                TextBoxEmail.Focus();
                return;
            }

            if (string.IsNullOrWhiteSpace(PasswordBox.Password))
            {
                MessageBox.Show(" Введите ваш пароль", "Внимание");
                PasswordBox.Focus();
                return;
            }

            foreach (var user in context.Users)
            {
                if ((user.Email == TextBoxEmail.Text.Trim()) && (user.Password == User.GetHash(PasswordBox.Password.Trim())))
                {
                    User currentUser = user;
                    foreach (Ride ride in context.Rides)
                    {
                        if (ride.UserId == currentUser.Id && ride.IsRideFinished == false)
                        {
                            if (currentStation.NumberOfSlots==0)
                            {
                                MessageBox.Show("Вы не можете поставить велосипед на эту станцию. Нет свободных слотов");
                                return;
                            }
                            var currentRide = ride;
                            var stAppLeaveBike = new StAppGiveBack(context, currentUser, currentStation,currentRide);
                            stAppLeaveBike.Show();
                            this.Close();
                            return;
                        }
                    }
                    var stAppTakeBike = new StAppTakeBike(context, currentUser, currentStation);
                    stAppTakeBike.Show();
                    this.Close();
                    return;
                }
            }

            MessageBox.Show(" Почта или пароль были введены некорректно\n Повторите ввод или зарегистрируйтесь", "Пользователь не найден");
            return;
        }
    }
}
