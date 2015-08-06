using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StrategyPatternPractice
{
    class Program
    {
        static void Main(string[] args)
        {

            PorscheCar car1 = new PorscheCar();
            car1.Iam = new iamPorscheCar();
            car1.speedupAct = new speedup1();
            car1.speeddownAct = new speeddown1();
            car1.nosAct = new NOS1();
            car1.iam();    

            Console.ReadKey();

            AmbulanceCar car2 = new AmbulanceCar();
            car2.Iam = new iamAmbulanceCar();
            car2.speedupAct = new speedup1();
            car2.speeddownAct = new speeddown1();
            car2.iam();

            Console.ReadKey();

        }
    }

    abstract class car : Iiam, Ispeedup, Ispeeddown
    {
        public Iiam Iam { get; set; }
        public Ispeedup speedupAct { get; set; }
        public Ispeeddown speeddownAct { get; set; }

        public void iam()
        {
            Iam.iam();
        }

        public void speedup()
        {
            speedupAct.speedup();
        }

        public void speeddown()
        {
            speeddownAct.speeddown();
        }      
    }

    class PorscheCar : car, INOS
    {        
        public INOS nosAct { get; set; }                 

        public void NOS()
        {
            nosAct.NOS();
        }

    }

    class AmbulanceCar : car
    {             

    }

    class OtherCar : car
    {
        
    }


    interface Iiam
    {
        void iam();      
    }

    interface Ispeedup
    {
        void speedup();
    }

    interface Ispeeddown
    {
        void speeddown();
    }

    interface INOS
    {
        void NOS();
    }

    class speedup1 : Ispeedup
    {
        public void speedup()
        {
            Console.WriteLine("加速");
        }
    }

    class speeddown1 : Ispeeddown
    {
        public void speeddown()
        {
            Console.WriteLine("減速");
        }
    }

    class NOS1 : INOS

    {    
        public void NOS()
        {
            Console.WriteLine("氮氣加速");
        }
    }

    class iamPorscheCar : Iiam
    {    
        public void iam()
        {
            Console.WriteLine("I am PorscheCar");
        }
    }

    class iamAmbulanceCar : Iiam
    {    
        public void iam()
        {
            Console.WriteLine("I am AmbulanceCar");
        }
    }

    class iamOtherCar : Iiam
    {         
        public void iam()
        {
            Console.WriteLine("I Dont't know who I am");
        }
    }    
}
