﻿using System;
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
using WpfApp1Tema2___Checkers__New_.View_Models;

namespace WpfApp1Tema2___Checkers__New_.Views
{
    /// <summary>
    /// Interaction logic for GameWindowView.xaml
    /// </summary>
    public partial class GameWindowView : Window
    {
        public GameWindowView()
        {
            InitializeComponent();
            DataContext = new GameWindowViewModel(new FileWindowViewModel());
        }
    }
}
