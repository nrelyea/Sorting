using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sorting_Tests
{
    class Program
    {
        static void Main(string[] args)
        {
            var lst1 = new List<int>() { 2, 3, 5, 7 };
            var lst2 = new List<int>() { 9, 4, 5, 3, 6, 1 };
            var lst3 = new List<int>() { 6, 3, 7, 9, 2, 1, 1, 7, 2};
            var lst4 = new List<int>() { 1, 7, 2};
            var lst5 = new List<int>() { 1, 2, 5, 2, 3, 70 };
            var rina = new List<int>() { 9, 12, 17, 90, 5, 2, 73, 24, 98, 3 };

            //PinchSort(rina);

            RadixSort(rina);
            //TestSorting();

            Console.Write("DONE");
            Console.ReadLine();
        }

        // ~ 85
        static Pack BubbleSort(List<int> lst)
        {
            Pack pack = new Pack(lst,0);
            int evals = 0;
            bool sorted = false;

            for(int i=0; i < lst.Count && sorted == false; i++)
            {
                sorted = true;
                for(int j=0; j < lst.Count; j++)
                {
                    if(j + 1 < lst.Count && lst[j+1] <= lst[j])
                    {
                        lst[j] = lst[j] + lst[j + 1];
                        lst[j + 1] = lst[j] - lst[j + 1];
                        lst[j] = lst[j] - lst[j + 1];
                        sorted = false;
                    }
                    evals++;
                }
            }

            pack.LST = lst; pack.EVALS = evals;
            return pack;
        }               

        // ~ 31
        static Pack InsertionSort(List<int> lst)
        {
            Pack pack = new Pack(lst, 0);
            int evals = 0;

            for (int marker = 1; marker < lst.Count; marker++)
            {
                for (int j = marker - 1; j > -1 && lst[j] > lst[j+1]; j--){
                    lst[j] = lst[j] + lst[j + 1];
                    lst[j + 1] = lst[j] - lst[j + 1];
                    lst[j] = lst[j] - lst[j + 1];
                    evals++;
                }
                evals++;
            }
            pack.LST = lst; pack.EVALS = evals;
            return pack;
        }

        // = 45 
        static Pack SelectionSort(List<int> lst)
    
    {
            Pack pack = new Pack(lst, 0);
            int evals = 0;

            for (int marker = 0; marker < lst.Count; marker++)
            {
                int min = marker;
                for (int j = marker; j < lst.Count-1; j++)
                {
                    if (lst[min] > lst[j + 1])
                    {
                        min = j+1;
                    }
                    evals++;
                }
                //Console.WriteLine("min between " + lst[marker] + " and " + lst[lst.Count-1] + " is " + lst[min]);
                if (min != marker)
                {
                    lst[marker] = lst[marker] + lst[min];
                    lst[min] = lst[marker] - lst[min];
                    lst[marker] = lst[marker] - lst[min];
                }               
            }
            pack.LST = lst; pack.EVALS = evals;
            return pack;
        }

        // ~ 23
        static Pack MergeSort(List<int> lst)
        {
            Pack pack = new Pack(lst, 0);
            int evals = 0;

            if (lst.Count > 1)
            {

                int split = lst.Count / 2;
                List<int> lst1 = lst.GetRange(0, split);
                List<int> lst2 = lst.GetRange(split, lst.Count - split);

                evals += MergeSort(lst1).EVALS + MergeSort(lst2).EVALS;
                lst1 = MergeSort(lst1).LST;
                lst2 = MergeSort(lst2).LST;

                lst.Clear();

                while (lst1.Count > 0 && lst2.Count > 0)
                {
                    if (lst1[0] <= lst2[0])
                    {
                        lst.Add(lst1[0]);
                        lst1.RemoveAt(0);
                    }
                    else
                    {
                        lst.Add(lst2[0]);
                        lst2.RemoveAt(0);
                    }
                    evals++;                    //EVALUATION
                }
                if (lst1.Count > 0){ lst.AddRange(lst1); }
                else{ lst.AddRange(lst2); }
                
            }

            pack.LST = lst; pack.EVALS = evals;
            return pack;
        }

        // ~ 35
        static Pack RinaSort(List<int> lst)

        {
            Pack pack = new Pack(lst, 0);
            int evals = 0;

            if(lst.Count < 2)
            {
                lst.Add(0);
                return pack;
            }

            List<int> minList = new List<int> { };
            int min = lst[0];

            for(int i = 0; i < lst.Count; i++)
            {
                if(lst[i] <= min)
                {
                    minList.Insert(0, lst[i]);
                    min = lst[i];
                    lst.RemoveAt(i);
                    i--;
                }
                evals++;                        // EVALUATION        
            }

            lst = RinaSort(lst).LST;

            int len = lst.Count - 1;
            evals += lst[len];

            lst.RemoveAt(len);

            List<int> lstFull = new List<int> { };

            while (minList.Count > 0 && lst.Count > 0)
            {
                if (minList[0] <= lst[0])
                {
                    lstFull.Add(minList[0]);
                    minList.RemoveAt(0);
                }
                else
                {
                    lstFull.Add(lst[0]);
                    lst.RemoveAt(0);
                }
                evals++;                    //EVALUATION
            }

            if (minList.Count > 0) { lstFull.AddRange(minList); }
            else { lstFull.AddRange(lst); }

            //PrintList(lstFull);

            lstFull.Add(evals);

            pack.LST = lstFull; pack.EVALS = evals;
            
            return pack;
        }

        // ~ 58
        static Pack PinchSort(List<int> lst)

        {
            Pack pack = new Pack(lst, 0);
            int evals = 0;

            if(lst.Count < 2)
            {
                return pack;
            }

            int min = 0; int max = 0;

            for(int i = 0; i < lst.Count; i++)
            {
                if(lst[i] < lst[min])
                {
                    min = i;                   
                }
                else
                {
                    if (lst[i] > lst[max])
                    {
                        max = i;
                    }
                    evals++;
                }
                evals++;

            }

            //Console.WriteLine("Evals during min/max finding: " + evals);

            //Console.WriteLine("Min: " + lst[min] + "\nMax: " + lst[max]);

            int minVal = lst[min]; int maxVal = lst[max];

            //Console.WriteLine("Removing indexes " + min + " and " + max + " from the list:");
            //PrintList(lst);

            lst.RemoveAt(min);

            if(min < max) { lst.RemoveAt(max - 1); }
            else { lst.RemoveAt(max); }
            

            //lst.RemoveAt(0); lst.RemoveAt(0);

            //PrintList(lst);

            List<int> lstFull = PinchSort(lst).LST;
            evals += PinchSort(lst).EVALS;

            lstFull.Insert(0, minVal); lstFull.Add(maxVal);

            //PrintList(lstFull);
            //Console.WriteLine("Evals: " + evals);

            pack.LST = lstFull; pack.EVALS = evals;
            return pack;
        }

        static Pack RadixSort(List<int> lst)
        {
            Pack pack = new Pack(lst, 0);
            int evals = 0;

            // Just in case there are values over 99 in the list //
            int max = lst[0];
            for (int i = 0; i < lst.Count; i++)
            {
                if(lst[i] > max) { max = lst[i]; }
            }
            int maxLength = (max.ToString()).Length;
            ///////////////////////////////////////////////////////
            
            List<List<int>> buckets = new List<List<int>> { };
            for (int i=0; i<10; i++)
            {
                buckets.Add(new List<int> { });
            }

            for (int i = 0; i < maxLength; i++)
            {
                while (lst.Count > 0)
                {                   
                    buckets[Digit(lst[0], i)].Add(lst[0]);
                    lst.RemoveAt(0);
                }

                for(int j = 0; j < 10; j++)
                {
                    while(buckets[j].Count > 0)
                    {
                        int temp = buckets[j][0];                        
                        lst.Add(temp);
                        buckets[j].RemoveAt(0);
                    }
                }
            }

            PrintList(lst);

            pack.LST = lst; pack.EVALS = evals;
            return pack;
        }

        static Pack DoDoSort(List<int> lst)
        {
            Pack pack = new Pack(lst, 0);
            int evals = 0;

            while (true)
            {
                break;
            }

            pack.LST = lst; pack.EVALS = evals;
            return pack;
        }

        static void TestSorting()
        {
            int testCount = 200;
            double evaluations = 0;
            for (int i = 0; i < testCount; i++)
            {
                evaluations += PinchSort(RandomList()).EVALS;          //SORT METHOD
                System.Threading.Thread.Sleep(5);

                if (i % 2 == 0)
                {
                    Console.Clear();
                    for (int j = 0; j < testCount / 2; j++)
                    {
                        if (j > i / 2) { Console.Write("."); }
                        else { Console.Write("|"); }
                    }
                }
            }
            evaluations /= testCount;

            Console.WriteLine("\n Average evaluations per sort: " + evaluations + "\n");
        }

        static List<int> RandomList()
        {
            List<int> lst = new List<int> { };
            Random rnd = new Random();
            while(lst.Count < 10)
            {
                lst.Add(rnd.Next(1, 100));
            }

            //Console.WriteLine("");
            PrintList(lst);

            return lst;
        }

        static void PrintList(List<int> lst)
        {
            for(int i=0; i<lst.Count; i++)
            {
                Console.Write(lst[i] + ", ");
            }
            Console.Write("\n");
        }

        static bool IsSorted(List<int> lst)
        {
            if(lst.Count < 2)
            {
                return true;
            }
            else if(Head(lst) <= Tail(lst)[0] && IsSorted(Tail(lst)))
            {
                return true;
            }
            else { return false; }
        }

        static int Digit(int num, int index)
        {
            int digit = (num / (int)(Math.Pow(10, index))) % 10;

            return digit;
        }

        static int Head(List<int> lst)
        {
            if(lst.Count > 0)
            {
                return lst[0];
            }
            else { return -1; }
        }

        static List<int> Tail(List<int> lst)
        {
            if (lst.Count > 1)
            {
                return new List<int>(lst.Skip(1));
            }
            else { return null; }
        }

    }

    public class Pack
    {
        public List<int> LST { get; set; }
        public int EVALS { get; set; }

        public Pack(List<int> lst, int evals)
        {
            LST = lst;
            EVALS = evals;
        }
    }
}
