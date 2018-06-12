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
    /// Логика взаимодействия для About_CYCLE.xaml
    /// </summary>
    public partial class About_CYCLE : Window
    {
        public About_CYCLE()
        {
            InitializeComponent();
        }
        private void Back_Click(object sender, RoutedEventArgs e)
        {
            DialogResult = true;
            Close();
        }
    }
}
