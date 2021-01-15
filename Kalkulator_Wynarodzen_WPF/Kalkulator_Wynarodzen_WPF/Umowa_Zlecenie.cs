using System;
using System.Collections.Generic;
using System.Text;

namespace Kalkulator_Wynagrodzeń_ConsoleApp
{
    public class Umowa_Zlecenie : UmowaBuilder
    {
        public Umowa_Zlecenie()
        {
            Umowa = new Umowa("Umowa o Pracę");
        }
        public override void BuildUbEmerytalne()
        {
            Umowa.UbEmerytalne = Umowa.WyBrutto * 0.0976;

            Umowa.Wynagrodzenie -= Umowa.UbEmerytalne;
        }

        public override void BuildUbRentowe()
        {
            Umowa.UbRentowe = Umowa.WyBrutto * 0.015;

            Umowa.Wynagrodzenie -= Umowa.UbRentowe;
        }

        public override void BuildUbChorobowe()
        {
            Umowa.UbChorobowe = 0;

        }

        public override void BuildUbZdrowotne()
        {
            Umowa.UbZdrowotne = Umowa.Wynagrodzenie * 0.09;

            Umowa.Wynagrodzenie -= Umowa.UbZdrowotne;
        }

        public override void BuildPoDochodowy()
        {
            Umowa.PoDochodowy = Umowa.WyBrutto - (((Umowa.WyBrutto - Umowa.UbEmerytalne - Umowa.UbRentowe) * 0.2) + Umowa.UbRentowe + Umowa.UbEmerytalne);

            Umowa.PoDochodowy *= 0.17;

            Umowa.PoDochodowy -= (Umowa.Wynagrodzenie + Umowa.UbZdrowotne) * 0.0775;
            Umowa.Wynagrodzenie -= Umowa.PoDochodowy;
        }
    }
}
