using System;
using System.Collections.Generic;
using System.Text;

namespace Kalkulator_Wynagrodzeń_ConsoleApp
{
    public class Umowa_o_Dzielo : UmowaBuilder
    {
        public Umowa_o_Dzielo()
        {
            Umowa = new Umowa("Umowa o Pracę");
        }
        public override void BuildUbEmerytalne()
        {
            Umowa.UbEmerytalne = 0;
           
        }

        public override void BuildUbRentowe()
        {
            Umowa.UbRentowe = 0;
        }

        public override void BuildUbChorobowe()
        {
            Umowa.UbChorobowe = 0;

        }

        public override void BuildUbZdrowotne()
        {
            Umowa.UbZdrowotne = 0;
        }

        public override void BuildPoDochodowy()
        {
            Umowa.PoDochodowy = Umowa.WyBrutto - Umowa.WyBrutto * 0.2;

            Umowa.PoDochodowy *= 0.17;
            Umowa.Wynagrodzenie -= Umowa.PoDochodowy;
        }
    }
}
