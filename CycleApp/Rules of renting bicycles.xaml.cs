﻿using Cycle.Info;
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
    /// Логика взаимодействия для Rules_of_renting_bicycles.xaml
    /// </summary>
    public partial class Rules_of_renting_bicycles : Window
    {
        public Rules_of_renting_bicycles()
        {
            InitializeComponent();
        }
        private void Back_Click (object sender, RoutedEventArgs e)
        {
            DialogResult = true;
            Close();
        }
    }
}
