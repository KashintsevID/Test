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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace CycleApp
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private Context context = new Context();
        public MainWindow()
        {
            InitializeComponent();
            //CopyDatatoDB(context);   //не успользовать без необходимости
        }

        static void CopyDatatoDB(Context context)  //метод для заполнения базы данных
        {
            DBRepository dbrepo = new DBRepository();

            context.Bicycles.AddRange(dbrepo.Bicycles);
            context.Stations.AddRange(dbrepo.Stations);
            context.SaveChanges();
        }

        private void ButtonRegister_Click(object sender, RoutedEventArgs e)
        {
            var registerWindow = new Register();
            registerWindow.Show();
            Hide();
        }
    }
}
