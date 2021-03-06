﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DecoratorPractice
{
    class Program
    {
        static void Main(string[] args)
        {
            Spaghetti Spaghetti = new NormalSpaghetti();
            Spaghetti = new Ham(Spaghetti);
            Spaghetti = new Egg(Spaghetti);

            Console.WriteLine("{1} 價錢:{0}", Spaghetti.GetPrice(), Spaghetti.Name);           
            Console.ReadKey();

            Spaghetti = new NormalSpaghetti();
            Spaghetti = new Ham(Spaghetti);
            Spaghetti = new Egg(Spaghetti);
            Spaghetti = new Cheese(Spaghetti);

            Console.WriteLine("{1} 價錢:{0}", Spaghetti.GetPrice(), Spaghetti.Name);
            Console.ReadKey();


        }
    }
    
    public abstract class Spaghetti
    {
        public string Name { get; set; }
        public string Description { get; set; }

        public abstract int GetPrice();                 
    }

    public class NormalSpaghetti : Spaghetti
    {
        public NormalSpaghetti ()
        {
            this.Name = "陽春麵";
        }

        public override int GetPrice()
        {
            return 100;
        }
    }

    public abstract class CondimentDecorator : Spaghetti
    {

    }

    public class Ham : CondimentDecorator
    {
        Spaghetti spaghetti { get; set; }
        private int price = 38;

        public Ham(Spaghetti pSpaghetti)
        {
            this.Name = $"{pSpaghetti.Name} 加火腿";
            this.spaghetti = pSpaghetti;
        }

        public override int GetPrice()
        {
            return spaghetti.GetPrice() + price;
        }
    }

    public class Egg : CondimentDecorator
    {
        Spaghetti spaghetti { get; set; }
        private int price = 10;

        public Egg(Spaghetti pSpaghetti)
        {
            this.Name = $"{pSpaghetti.Name} 加蛋";
            this.spaghetti = pSpaghetti;
        }

        public override int GetPrice()
        {
            return spaghetti.GetPrice() + price;
        }
    }

    public class Cheese : CondimentDecorator
    {
        Spaghetti spaghetti { get; set; }
        private int price = 20;

        public Cheese(Spaghetti pSpaghetti)
        {
            this.Name = $"{pSpaghetti.Name} 加起司";
            this.spaghetti = pSpaghetti;
        }

        public override int GetPrice()
        {
            return spaghetti.GetPrice() + price;
        }
    }


}
