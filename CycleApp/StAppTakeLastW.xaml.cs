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
        private Bicycle bicycle;
        public StAppTakeLastW(Bicycle bicycle)
        {
            this.bicycle = bicycle;
            InitializeComponent();
            NumserOsSlot.Text = bicycle.CurrentSlot.ToString();
        }

        private void ButtonEnd_Click(object sender, RoutedEventArgs e)
        {
            
            var stAppEnter = new StAppEnter();
            stAppEnter.Show();
            this.Close();

        }
    }
}
