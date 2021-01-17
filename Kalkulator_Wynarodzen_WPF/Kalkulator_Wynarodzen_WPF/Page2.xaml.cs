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
using Kalkulator_Wynagrodzeń_ConsoleApp;

namespace Wzorce_Proejkt2
{
    /// <summary>
    /// Interaction logic for Page2.xaml
    /// </summary>
    public partial class Page2 : Page
    {
        public Page2()
        {
            InitializeComponent();
        }
        private void PageKal_Loaded(object sender, RoutedEventArgs e)
        {
            podatki.Visibility = Visibility.Hidden;
            netto.Visibility = Visibility.Hidden;
            NettoLabel.Visibility = Visibility.Hidden;
            PracodawcaLabel.Visibility = Visibility.Hidden;
            pracodawca.Visibility = Visibility.Hidden;
            OplatyPracodawcy.Visibility = Visibility.Hidden;
            jobCheckBox.Visibility = Visibility.Hidden;
            upLabel.Visibility = Visibility.Hidden;
        }

        public static double kwBrutto { get; set; }
        public static string Podatki { get; set; }
        public static string Netto { get; set; }

        public static double BezDochod { get; set; }
        public static double Ubez { get; set; }
        private string umowa = "uop";
        private void oblicz_Click(object sender, RoutedEventArgs e)
        {
            kwBrutto = Double.Parse(brutto.Text);
            if (CbUmowaoPrace.IsSelected)
            {
                if (ageCheckBox.IsChecked == true)
                {
                    var wyplata = new Wyplata();
                    UmowaBuilder umowaBuilder = new Umowa_o_Prace();
                    umowaBuilder.BuildUbEmerytalne();
                    umowaBuilder.BuildUbRentowe();
                    umowaBuilder.BuildUbChorobowe();
                    umowaBuilder.BuildUbZdrowotne();
                    umowaBuilder.Umowa.DisplayConfiguration();
                    var prac = new UEmerytalne(new URentowe(new UWypadkowe(new FP(new FGSP(new Pracodawca())))));
                    pracodawca.Text = Math.Round(prac.GetKoszty(), 2).ToString();
                    OplatyPracodawcy.Content = "Zawierają: \n" + prac.GetNazwa();
                    month.Visibility = Visibility.Hidden;
                }
                else
                {
                    month.Visibility = Visibility.Visible;
                    var wyplata = new Wyplata();
                    UmowaBuilder umowaBuilder = new Umowa_o_Prace();
                    wyplata.ConstructUmowa(umowaBuilder);
                    umowaBuilder.Umowa.DisplayConfiguration();
                    var prac = new UEmerytalne(new URentowe(new UWypadkowe(new FP(new FGSP(new Pracodawca())))));
                    pracodawca.Text = Math.Round(prac.GetKoszty(), 2).ToString();
                    OplatyPracodawcy.Content = "Zawierają: \n" + prac.GetNazwa();
                }


            }
            else if (CbUmowaZlecenie.IsSelected)
            {
                if (ageCheckBox.IsChecked == true)
                {
                    var wyplata = new Wyplata();
                    UmowaBuilder umowaBuilder = new Umowa_Zlecenie();
                    umowaBuilder.Umowa.DisplayConfiguration();
                    var prac = new Pracodawca();
                    pracodawca.Text = Math.Round(prac.GetKoszty(), 2).ToString();
                    OplatyPracodawcy.Content = "Zawierają: \n" + prac.GetNazwa();
                    month.Visibility = Visibility.Hidden;
                }
                else
                {
                    month.Visibility = Visibility.Visible;
                    if (jobCheckBox.IsChecked == true)
                    {
                        var wyplata = new Wyplata();
                        UmowaBuilder umowaBuilder = new Umowa_Zlecenie();
                        wyplata.ConstructUmowa(umowaBuilder);
                        umowaBuilder.Umowa.DisplayConfiguration();
                        var prac = new UEmerytalne(new URentowe(new UWypadkowe(new FP(new FGSP(new Pracodawca())))));
                        pracodawca.Text = Math.Round(prac.GetKoszty(), 2).ToString();
                        OplatyPracodawcy.Content = "Zawierają: \n" + prac.GetNazwa();
                    }
                    else
                    {
                        var wyplata = new Wyplata();
                        UmowaBuilder umowaBuilder = new Umowa_Zlecenie();
                        umowaBuilder.BuildUbZdrowotne();
                        umowaBuilder.BuildPoDochodowy();
                        umowaBuilder.Umowa.DisplayConfiguration();
                        var prac = new Pracodawca();
                        pracodawca.Text = Math.Round(prac.GetKoszty(), 2).ToString();
                        OplatyPracodawcy.Content = "Zawierają: \n" + prac.GetNazwa();
                    }
                }

            }
            else if (CbUmowaoDzielo.IsSelected)
            {
                month.Visibility = Visibility.Visible;
                var wyplata = new Wyplata();
                UmowaBuilder umowaBuilder = new Umowa_o_Dzielo();
                wyplata.ConstructUmowa(umowaBuilder);
                umowaBuilder.Umowa.DisplayConfiguration();
                var prac = new Pracodawca();
                pracodawca.Text = Math.Round(prac.GetKoszty(), 2).ToString();
                OplatyPracodawcy.Content = prac.GetNazwa();
            }


            Visibily();
        }



        private void comboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (CbUmowaoPrace.IsSelected)
            {
                umowa = "uop";
                if (ageCheckBox != null) ageCheckBox.Visibility = Visibility.Visible;
                if (jobCheckBox != null) jobCheckBox.Visibility = Visibility.Hidden;
            }
            else if (CbUmowaZlecenie.IsSelected)
            {
                umowa = "uz";
                ageCheckBox.Visibility = Visibility.Visible;
                jobCheckBox.Visibility = Visibility.Visible;
            }
            else
            {
                umowa = "uod";
                ageCheckBox.Visibility = Visibility.Hidden;
                jobCheckBox.Visibility = Visibility.Hidden;
            }

        }

        private void Visibily()
        {
            netto.Visibility = Visibility.Visible;
            NettoLabel.Visibility = Visibility.Visible;
            podatki.Visibility = Visibility.Visible;
            netto.Text = Netto;
            podatki.Content = Podatki;
            PracodawcaLabel.Visibility = Visibility.Visible;
            pracodawca.Visibility = Visibility.Visible;
            OplatyPracodawcy.Visibility = Visibility.Visible;
            upLabel.Visibility = Visibility.Visible;
            
        }

        private void month_Click(object sender, RoutedEventArgs e)
        {
            double wynagrodzenie = BezDochod;
            this.NavigationService.Content=new Page1(wynagrodzenie, Ubez,umowa);
        }
    }
}
