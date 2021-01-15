using System;
using System.Collections.Generic;
using System.Text;

namespace Wzorce_Proejkt2
{
    interface Stan
    {

        double wysokosc();

    }

    class Powiadomienia
    {

        private Stan aktualnyStan;

        public Powiadomienia()
        {
            aktualnyStan = new Podatek();
        }

        public Stan ustawStan(Stan stan)
        {
            this.aktualnyStan = stan;
            return aktualnyStan;
        }
        
        public double wysokosc()
        {
           return aktualnyStan.wysokosc();
            
        }
        
    }

    class Podatek : Stan
    {
        public double wysokosc()
        {
            return 0;
        }

    }
    class p18 : Stan
    {
        public double wysokosc()
        {
            return 0.18;
        }

    }

    class p32 : Stan
    {
        public double wysokosc()
        {
           return 0.32;
        }

    }


    //class Program
    //{
    //    public static void Main(string[] args)
    //    {
    //        //
    //        //
    //        //
    //        //
    //        //
    //        //
    //        Powiadomienia powiadomienia = new Powiadomienia();
    //        powiadomienia.ustawStan(new Wibracja());
    //        powiadomienia.alert();
    //        powiadomienia.ustawStan(new Dzwonek());
    //        powiadomienia.alert();
    //        powiadomienia.ustawStan(new Wyciszenie());
    //        powiadomienia.alert();
    //        powiadomienia.alert();
    //        powiadomienia.ustawStan(new Wibracja());
    //        powiadomienia.alert();
    //    }
    //}
}
