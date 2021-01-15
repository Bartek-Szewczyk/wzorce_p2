using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using Kalkulator_Wynarodzen_WPF;

namespace Wzorce_Proejkt2
{
    /// <summary>
    /// Interaction logic for Page1.xaml
    /// </summary>
    public partial class Page1 : Page
    {
        public double kwota;
        public Page1(double wynagrodzenie)
        {
            InitializeComponent();
            kwota = wynagrodzenie;
        }

        
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            this.NavigationService.Content = new Page2();
        }

        private void Grid_Loaded(object sender, RoutedEventArgs e)
        {
            w1.Content = kwota;
        }
    }
}
