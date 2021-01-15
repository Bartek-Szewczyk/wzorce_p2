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
        public double suma;
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
            suma = kwota;
            PoDochodowy pDochodowy = new PoDochodowy();

            Label[] labels = new Label[] { w1, w2, w3, w4, w5, w6, w7, w8, w9, w10, w11, w12 };
            for (int i = 0; i < labels.Length; i++)
            {
                if (suma < 85528)
                {
                    pDochodowy.ustawStan(new p18());
                }
                else
                {
                    pDochodowy.ustawStan(new p32());
                    labels[i].Foreground = Brushes.IndianRed;
                }

                labels[i].Content = Math.Round(pDochodowy.wysokosc(kwota), 2);
                suma += kwota;

            }

            zRoczne.Content = suma;
            progpod.Content = pDochodowy.prog();
        }




    }


}

