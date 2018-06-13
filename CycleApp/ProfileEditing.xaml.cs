using Cycle.Info;
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
    /// Логика взаимодействия для ProfileEditing.xaml
    /// </summary>
    public partial class ProfileEditing : Window
    {
        private Context cont;
        private User currentUser;
        public ProfileEditing(Context context, User curUser)
        {
            currentUser = curUser;
            cont = context;
            InitializeComponent();
            TextBoxFullName.Text = currentUser.FullName;
        }

        private void ButtonReturn_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void ButtonSave_Click(object sender, RoutedEventArgs e)
        {
            if (TextBoxFullName.Text.Trim() != null)
            {
                currentUser.FullName = TextBoxFullName.Text.Trim();
                cont.SaveChanges();
                this.Close();
            }
        }
    }
}
