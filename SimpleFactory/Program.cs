using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleFactory
{
    class Program
    {
        static void Main(string[] args)
        {

            BeverageStores stores = new BeverageStores(new TeaFactory());            
            stores.ProduceTea("GreenTea");         
            Console.ReadKey();
            stores.ProduceTea("BlackTea");
            Console.ReadKey();
        }
    }


    public interface Brew
    {
        void Brew();
    }

    public class BrewHotWater : Brew
    {
        public void Brew()
        {
            Console.WriteLine("加熱水");
        }
    }    

    public interface PouredCup
    {
        void PouredCup();
    }

    public class PouredPlasticCup : PouredCup
    {
        public void PouredCup()
        {
            Console.WriteLine("裝入塑膠杯");
        }
    }

    public class PouredStyrofoamCup : PouredCup
    {
        public void PouredCup()
        {
            Console.WriteLine("裝入保麗龍杯");
        }
    }

    public class GreenTea : IProduce
    {
        public Brew BrewAct { get; set; }
        public PouredCup PouredCupAct { get; set; }

        public void AddMaterial()
        {
            Console.WriteLine("放綠茶包");
        }

        public void Brew()
        {
            BrewAct.Brew();
        }

        public void PouredCup()
        {
            PouredCupAct.PouredCup();
        }
    }

    public class BlackTea : IProduce
    {
        public Brew BrewAct { get; set; }
        public PouredCup PouredCupAct { get; set; }

        public void AddMaterial()
        {
            Console.WriteLine("放紅茶包");
        }

        public void Brew()
        {
            BrewAct.Brew();
        }

        public void PouredCup()
        {
            PouredCupAct.PouredCup();
        }
    }

    public interface IProduce
    {
        Brew BrewAct { get; set; }
        PouredCup PouredCupAct { get; set; }

        void AddMaterial();
        void Brew();
        void PouredCup();
    }

    public class BeverageStores
    {
        private TeaFactory _factory;

        public BeverageStores(TeaFactory pfactory)
        {
            _factory = pfactory;
        }

        public IProduce ProduceTea(string pTea)
        {
            IProduce Produce;
            Produce = _factory.CreateProduce(pTea);

            Produce.AddMaterial();
            Produce.Brew();
            Produce.PouredCup();

            return Produce;
        }
    }

    public class TeaFactory
    {
        public IProduce CreateProduce(string pTea)
        {
            IProduce Produce;
            if (pTea == "GreenTea")
            {
                Produce = new GreenTea();
                Produce.BrewAct = new BrewHotWater();
                Produce.PouredCupAct = new PouredPlasticCup();
                return Produce;
            }
            else if (pTea == "BlackTea")
            {
                Produce = new GreenTea();
                Produce.BrewAct = new BrewHotWater();
                Produce.PouredCupAct = new PouredStyrofoamCup();
                return Produce;
            }
            else
                return null;            
        }
    }
}
