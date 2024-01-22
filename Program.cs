using AbstractFactoryExample;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AbstractFactoryExample
{
    public interface ITV
    {
        void UseInterface();
    }

    
    public interface IDisplay
    {
        void UseInterface();
    }

   
    public interface ITechnologyFactory
    {
        ITV CreateTV();
        IDisplay CreateDisplay();
    }
    public class SamsungFactory : ITechnologyFactory
    {
        public ITV CreateTV()
        {
            return new SamsungTV();
        }

        public IDisplay CreateDisplay()
        {
            return new SamsungDisplay();
        }
    }

 
    public class DellFactory : ITechnologyFactory
    {
        public ITV CreateTV()
        {
            return new DellTV();
        }

        public IDisplay CreateDisplay()
        {
            return new DellDisplay();
        }
    }

    public class DellTV : ITV
    {
        public void UseInterface()
        {
            Console.WriteLine("Using Dell TV ");
        }
    }

  
    public class SamsungTV : ITV
    {
        public void UseInterface()
        {
            Console.WriteLine("Using Samsung TV");
        }
    }

  
    public class DellDisplay : IDisplay
    {
        public void UseInterface()
        {
            Console.WriteLine("Using Dell Display ");
        }
    }

    public class SamsungDisplay : IDisplay
    {
        public void UseInterface()
        {
            Console.WriteLine("Using Samsung Display");
        }
    }

 
    public class App
    {
        private ITechnologyFactory technologyFactory;
        private ITV tv;
        private IDisplay display;

        public App(ITechnologyFactory factory)
        {
            technologyFactory = factory;
            tv = technologyFactory.CreateTV();
            display = technologyFactory.CreateDisplay();
        }

        public void SellTV()
        {
            tv.UseInterface();
        }

        public void SellDisplay()
        {
            display.UseInterface();
        }
    }
    class Program
    {
        static void Main()
        {

            ITechnologyFactory samsungFactory = new SamsungFactory();
            App samsungApp = new App(samsungFactory);
           

            ITechnologyFactory dellFactory = new DellFactory();
            App dellApp = new App(dellFactory);
           
        }
    }
}

//SRP se koristi jer svaka klasa ima odredenu odgovornost.
//OCP jer mozemo dodavati nove tvornice bez mijenjanja postojećeg koda.
//LSP jer sučelje ITV i IDisplay mogu koristit medusobno implementacije.
//ISP se vidi jer su sucelja definirana tako da nema viska metoda te odgovoaraju za navede klase.
//DIP jer klijentski kod ovisi o apstrakcijama kao što su ITV, IDisplay, ITechnologyFactory,



