using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StrategyPattern
{
    class Strategy //定義：定義一組演算法，將其各個分裝，並且使他們有替換性。演算法變動時不影響使用到的程式。
    {
        static void Main(string[] args)
        {
            SortedList studentRecords = new SortedList();

            studentRecords.Add("Samual");
            studentRecords.Add("Jimmy");
            studentRecords.Add("Sandra");
            studentRecords.Add("Vivek");
            studentRecords.Add("Anna");


            #region 可隨意替換

            studentRecords.SetSortStrategy(new QuickSort());
            studentRecords.Sort();

            studentRecords.SetSortStrategy(new ShellSort());
            studentRecords.Sort();

            studentRecords.SetSortStrategy(new MergeSort());
            studentRecords.Sort();

            #endregion

            // Wait for user
            Console.ReadKey();
        }
    }


    #region 定義一組演算法並分裝
    abstract class SortStrategy
    {
        public abstract void Sort(List<string> list);
    }

    class QuickSort : SortStrategy
    {
        public override void Sort(List<string> list)
        {
            list.Sort();
            Console.WriteLine("QuickSorted list");
        }
    }
    class ShellSort : SortStrategy
    {
        public override void Sort(List<string> list)
        {
            Console.WriteLine("ShellSorted list");
        }
    }
    class MergeSort : SortStrategy
    {
        public override void Sort(List<string> list)
        {
            //list.MergeSort(); not-implemented
            Console.WriteLine("MergeSorted list ");
        }
    }    

    #endregion

    class SortedList
    {
        private List<string> _list = new List<string>();
        private SortStrategy _sortstrategy;
 
        public void SetSortStrategy(SortStrategy sortstrategy)
        {
            this._sortstrategy = sortstrategy;
        }
 
        public void Add(string name)
        {
            _list.Add(name);
        }
 
        public void Sort()
        {
            _sortstrategy.Sort(_list);
 
            // Iterate over list and display results
            foreach (string name in _list)
            {
                Console.WriteLine(" " + name);
            }

            Console.WriteLine();
        }
    }
}

