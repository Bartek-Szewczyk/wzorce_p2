using System;
using System.Collections.Generic;
using System.Text;

namespace Kalkulator_Wynagrodzeń_ConsoleApp
{
    public class Umowa_o_Prace : UmowaBuilder
    {
        public Umowa_o_Prace()
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
            Umowa.UbChorobowe = Umowa.WyBrutto * 0.0245;

            Umowa.Wynagrodzenie -= Umowa.UbChorobowe;
        }

        public override void BuildUbZdrowotne()
        {
            Umowa.UbZdrowotne = Umowa.Wynagrodzenie * 0.09;

            Umowa.Wynagrodzenie -= Umowa.UbZdrowotne;
        }

        public override void BuildPoDochodowy()
        {
            Umowa.PoDochodowy = Umowa.WyBrutto - 250 - Umowa.UbEmerytalne - Umowa.UbChorobowe - Umowa.UbRentowe;
            if (Umowa.WyBrutto  < 85528)
            {
                Umowa.PoDochodowy *= 0.17;
            }
            else
            {
                Umowa.PoDochodowy *= 0.32;
            }
            Umowa.PoDochodowy -= 43.76;
            Umowa.PoDochodowy -= (Umowa.Wynagrodzenie + Umowa.UbZdrowotne) * 0.0775;
            Math.Round(Umowa.Wynagrodzenie -= Umowa.PoDochodowy,2);
        }
    }
}
