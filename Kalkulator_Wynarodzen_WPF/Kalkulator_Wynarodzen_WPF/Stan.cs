using System;
using System.Collections.Generic;
using System.Security.Cryptography.Xml;
using System.Text;
using System.Windows;
using Kalkulator_Wynagrodzeń_ConsoleApp;
using Wzorce_Proejkt2;

namespace Wzorce_Proejkt2
{
    interface Stan
    {

        double wysokosc(double kw, double ub);
        string prog();
    }

    class PoDochodowy
    {

        private Stan aktualnyStan;


        public PoDochodowy()
        {
            aktualnyStan = new Podatek();
        }

       

        public Stan ustawStan(Stan stan)
        {
            this.aktualnyStan = stan;
            return aktualnyStan;
        }

        public double wysokosc(double kwota, double ub)
        {
            return aktualnyStan.wysokosc(kwota, ub);

        }

        public string prog()
        {
            return aktualnyStan.prog();
        }
    }

    class Podatek : Stan
    {
        public double wysokosc(double kw, double ub)
        {

            return 0;
        }

        public string prog()
        {
            throw new NotImplementedException();
        }
    }
    class p18 : Stan
    {
        public double wysokosc(double kw, double ub)
        {
            double podatek = Umowa.WyBrutto - Umowa.WyBrutto * 0.2;
            
            podatek *= 0.18;
            double wyp = kw - podatek;
            return wyp;
        }

        public string prog()
        {
            string message = "Płacisz 18% podatku dochodowego";
            return message;
        }
    }
    class p17 : Stan
    {
        public double wysokosc(double kw, double ub)
        {
            double podatek = Umowa.WyBrutto - 250 - Umowa.UbEmerytalne - Umowa.UbChorobowe - Umowa.UbRentowe;
            podatek *= 0.17;
            podatek -= 43.76;
            podatek -= (kw + Umowa.UbZdrowotne) * 0.0775;
            double wyp = kw - podatek;
            return wyp;
        }

        public string prog()
        {
            string message = "Płacisz 17% podatku dochodowego";
            return message;
        }
    }
    class zp17 : Stan
    {
        public double wysokosc(double kw, double ub)
        {
            double podatek = Umowa.WyBrutto - (((Umowa.WyBrutto - Umowa.UbEmerytalne - Umowa.UbRentowe) * 0.2) + Umowa.UbRentowe + Umowa.UbEmerytalne);
            podatek *= 0.17;
            podatek -= (kw + Umowa.UbZdrowotne) * 0.0775;
            double wyp = kw - podatek;
            return wyp;
        }

        public string prog()
        {
            string message = "Płacisz 17% podatku dochodowego";
            return message;
        }
    }

    class p32 : Stan
    {
        public double wysokosc(double kw, double ub)
        {
            double podatek = Umowa.WyBrutto - 250 - Umowa.UbEmerytalne - Umowa.UbChorobowe - Umowa.UbRentowe;
            podatek *= 0.32;
            podatek -= 43.76;
            podatek -= (kw + Umowa.UbZdrowotne) * 0.0775;
            double wyp = kw - podatek;
            return wyp;
        }

        public string prog()
        {
            string message = "Wpadasz już w drugi próg podatkowy 32%";
            return message;
        }

       

    }


}
