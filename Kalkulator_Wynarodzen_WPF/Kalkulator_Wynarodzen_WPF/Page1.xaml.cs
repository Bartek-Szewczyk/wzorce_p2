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
using Wzorce_Proejkt2;

namespace Wzorce_Proejkt2
{
    /// <summary>
    /// Interaction logic for Page1.xaml
    /// </summary>
    public partial class Page1 : Page
    {
        public double kwota;
        public double suma;
        public double ubez;
        public string umowa;
        public Page1(double wynagrodzenie, double ubez, string umowa)
        {
            InitializeComponent();
            kwota = wynagrodzenie;
            this.ubez = ubez;
            this.umowa = umowa;
        }


        private void Button_Click(object sender, RoutedEventArgs e)
        {
            this.NavigationService.Content = new Page2();
        }

        private void Grid_Loaded(object sender, RoutedEventArgs e)
        {
            PoDochodowy pDochodowy = new PoDochodowy();

            Label[] labels = new Label[] { w1, w2, w3, w4, w5, w6, w7, w8, w9, w10, w11, w12 };
            if (umowa == "uop")
            {
                for (int i = 0; i < labels.Length; i++)
                {

                    if (suma < 85528)
                    {
                        pDochodowy.ustawStan(new p17());
                    }
                    else
                    {
                        pDochodowy.ustawStan(new p32());
                        labels[i].Foreground = Brushes.IndianRed;
                    }

                    double wyp = Math.Round(pDochodowy.wysokosc(kwota, ubez), 2);
                    labels[i].Content = wyp;
                    suma += wyp;

                }
            }
            else if (umowa == "uz")
            {
                for (int i = 0; i < labels.Length; i++)
                {

                    pDochodowy.ustawStan(new zp17());

                    double wyp = Math.Round(pDochodowy.wysokosc(kwota, ubez), 2);
                    labels[i].Content = wyp;
                    suma += wyp;

                }
            }
            else
            {
                for (int i = 0; i < labels.Length; i++)
                {
                    pDochodowy.ustawStan(new p18());

                    double wyp = Math.Round(pDochodowy.wysokosc(kwota, ubez), 2);
                    labels[i].Content = wyp;
                    suma += wyp;
                }
            }


            zRoczne.Content = Math.Round(suma,2);
            progpod.Content = pDochodowy.prog();
        }




    }


}

