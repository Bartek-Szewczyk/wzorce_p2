using System;
using System.Collections.Generic;
using System.Security.Cryptography.Xml;
using System.Text;
using System.Windows;

namespace Wzorce_Proejkt2
{
    interface Stan
    {

        double wysokosc(double kw);
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

        public double wysokosc(double kwota)
        {
            return aktualnyStan.wysokosc(kwota);

        }

        public string prog()
        {
            return aktualnyStan.prog();
        }
    }

    class Podatek : Stan
    {
        public double wysokosc(double kw)
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
        public double wysokosc(double kw)
        {
            double wyp = kw - kw * 0.18;
            return wyp;
        }

        public string prog()
        {
            string message = "Płacisz 18% podatku dochodowego";
            return message;
        }
    }

    class p32 : Stan
    {
        public double wysokosc(double kw)
        {
            double wyp = kw - kw * 0.32;
            return wyp;
        }

        public string prog()
        {
            string message = "Wpadasz już w drugi próg podatkowy 32%";
            return message;
        }

       

    }


}
