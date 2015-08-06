using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Singleton
{
    class Program
    {
        static void Main(string[] args)
        {
            Singleton s1 = Singleton.Instance();
            Singleton s2 = Singleton.Instance();            

            if(s1 == s2)
            {
                Console.WriteLine("They are the same");
            }
            else
            {
                Console.WriteLine("They are different");
            }

            Console.ReadKey();

            Singleton s3 = new Singleton();
            Singleton s4 = new Singleton();  

            if(s3 == s4)
            {
                Console.WriteLine("They are the same");
            }
            else
            {
                Console.WriteLine("They are different");
            }

            Console.ReadKey();
        }
    }

    class Singleton
    {
        private static Singleton _instance;
        
        public Singleton()
        {

        }

        public static Singleton Instance()
        {
            if(_instance == null)
            {
                _instance = new Singleton();
            }

            return _instance;
        }
    }
}
