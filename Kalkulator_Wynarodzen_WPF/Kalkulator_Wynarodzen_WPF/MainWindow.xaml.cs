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
using Kalkulator_Wynagrodzeń_ConsoleApp;


namespace Kalkulator_Wynarodzen_WPF
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }
       
        private void Window_Loaded(object sender, RoutedEventArgs e)
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
                }
                else
                {
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
                }
                else
                {
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
                var wyplata = new Wyplata();
                UmowaBuilder umowaBuilder = new Umowa_o_Dzielo();
                wyplata.ConstructUmowa(umowaBuilder);
                umowaBuilder.Umowa.DisplayConfiguration();
                var prac = new Pracodawca();
                pracodawca.Text = Math.Round(prac.GetKoszty(), 2).ToString();
                OplatyPracodawcy.Content =  prac.GetNazwa();
            }


            Visibily();
        }



        private void comboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (CbUmowaoPrace.IsSelected)
            {
                if (ageCheckBox != null) ageCheckBox.Visibility = Visibility.Visible;
                if (jobCheckBox != null) jobCheckBox.Visibility = Visibility.Hidden;
            }
            else if (CbUmowaZlecenie.IsSelected)
            {
                ageCheckBox.Visibility = Visibility.Visible;
                jobCheckBox.Visibility = Visibility.Visible;
            }
            else
            {
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


    }
}
