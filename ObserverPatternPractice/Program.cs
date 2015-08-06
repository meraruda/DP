using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ObserverPatternPractice
{
    class Program
    {
        static void Main(string[] args)
        {
            // 產生一間報社
            NewspaperOffice office = new NewspaperOffice(); 
            // Arvin 想要訂閱報紙
            Customer arvin = new Customer("Arvin");
            office.registerObserver(arvin);
            // Jack 想要訂閱報紙
            Customer jack = new Customer("Jack");
            office.registerObserver(jack);
            // 報社發送了第一則新聞
            office.notifyObserver("News One.......");
            // Arvin 不想看報紙了，要退訂
            office.removeObserver(arvin);
            // 報社發送了第二則新聞
            office.notifyObserver("News Two.......");
            Console.Read();
        }
    }

    interface ISubject
    {
        void registerObserver(IObserver pObserver);
        void removeObserver(IObserver pObserver);
        void notifyObserver(string pcontent);
    }

    interface IObserver
    {
        void Update(string pcontent);
    }

    class NewspaperOffice : ISubject
    {
        List<IObserver> lstObservers { get; set; }

        public NewspaperOffice()
        {
            lstObservers = new List<IObserver>();
        }


        public void registerObserver(IObserver pObserver)
        {
            lstObservers.Add(pObserver);
        }

        public void removeObserver(IObserver pObserver)
        {
            if(lstObservers.IndexOf(pObserver) > -1)
            {
                lstObservers.Remove(pObserver);
            }
        }

        public void notifyObserver(string pcontent)
        {
            foreach(IObserver obs in lstObservers)
            {
                obs.Update(pcontent);
            }
        }
    }

    class Customer : IObserver
    {
        public string Name { private get; set; }

        public Customer(string pName)
        {
            Name = pName;
        }

        public void Update(string pcontent)
        {
            Console.WriteLine("{0} 收到訊息 {1}", Name, pcontent);
        }
    }
}
