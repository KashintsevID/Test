﻿using Cycle.Info;
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
        public StAppGiveBack(Context context, User curUser, Station curStation)
        {
            InitializeComponent();
        }

        private void ButtonBack_Click(object sender, RoutedEventArgs e)
        {
            
        }
    }
}