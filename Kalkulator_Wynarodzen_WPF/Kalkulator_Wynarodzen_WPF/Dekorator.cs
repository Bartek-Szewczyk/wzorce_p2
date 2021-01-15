using System;
using System.Collections.Generic;
using System.Text;
using Kalkulator_Wynarodzen_WPF;

namespace Kalkulator_Wynagrodzeń_ConsoleApp
{
    public interface IUmowa
    {
        string GetNazwa();
        double GetKoszty();

    }

    public class Pracodawca : IUmowa
    {
        public string GetNazwa()
        {
            return "Wypłata Brutto pracownika";
        }

        public double GetKoszty()
        {
            return MainWindow.kwBrutto;
        }
    }


    public abstract class Decorator : IUmowa
    {
        private IUmowa _umowa;
        public string _name;
        public double _kosztCalkowity;

        public Decorator(IUmowa umowa)
        {
            _umowa = umowa;
        }
        public string GetNazwa()
        {
            return string.Format($"{_umowa.GetNazwa()}\n{_name}: {Math.Round(_kosztCalkowity,2)}");
        }

        public double GetKoszty()
        {
            return _umowa.GetKoszty() + _kosztCalkowity;
        }
    }


    public class UEmerytalne : Decorator
    {

        public UEmerytalne(IUmowa umowa) : base(umowa)
        {
            _name = "Ubezpiecznie Emerytalne";
            _kosztCalkowity = MainWindow.kwBrutto * 0.0976;
        }
    }
    public class URentowe : Decorator
    {
        public URentowe(IUmowa umowa) : base(umowa)
        {
            _name = "Ubezpiecznie Rentowe";
            _kosztCalkowity = MainWindow.kwBrutto * 0.065;
        }
    }

    public class UWypadkowe : Decorator
    {
        public UWypadkowe(IUmowa umowa) : base(umowa)
        {
            _name = "Ubezpiecznie Wypadkowe";
            _kosztCalkowity = MainWindow.kwBrutto * 0.0167;
        }
    }
    public class FP : Decorator
    {
        public FP(IUmowa umowa) : base(umowa)
        {
            _name = "FP";
            _kosztCalkowity = MainWindow.kwBrutto * 0.0245;
        }
    }
    public class FGSP : Decorator
    {
        public FGSP(IUmowa umowa) : base(umowa)
        {
            _name = "FGŚP";
            _kosztCalkowity = MainWindow.kwBrutto * 0.001;
        }
    }
}
