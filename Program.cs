using System.Diagnostics;

namespace Exercize
{
    class Program
    {
      static void Main(string[] args)
      {
        Stopwatch sw = new Stopwatch();
        int ItemCount = 100;
        for(int i=0; i<4; i++)
        {
          int[] Array = new int[ItemCount];
          Random rnd = new Random();
          for(int j=0; j<ItemCount; j++)
          {
            Array[j] = rnd.Next();
          }
          sw.Start();
          BubbleSort(Array);
          //  InsertionSort(Array);
          // ShellSort(Array);
          sw.Stop();
          if(IsSorted(Array))
          {
            string Elapsed = sw.ElapsedMilliseconds.ToString();
            Console.WriteLine($"ItemCount={ItemCount}, {Elapsed} ms elapsed.");

          }
          else
          {
            Console.WriteLine($"Task failed for ItemCount={ItemCount}");
          }
          ItemCount *= 10;
        }
        // tester.RunTest(6);
      }
      
      static void InsertionSort(int[] Array)
      {
        int Length = Array.Length;
        for(int i=1; i<Length; i++)
        {
          int Number = Array[i];
          for(int j=0; j<i; j++)
          {
            if(Array[j] >= Number)
            {
              Insert(Array, i, j);
              break;
            }
          }
        }

      }

      static void ShellSort(int[] Array)
      {
        int Length = Array.Length;
        for (int step = (Length / 2); step > 0; step /= 2)
        {
          for (int i = step; i < Length; i++)
          {
              for (int j = i - step; j >= 0 && Array[j] > Array[j + step] ; j -= step)
              {
                int x = Array[j];
                Array[j] = Array[j + step];
                Array[j + step] = x;
              }
          }
        }
      }

      static void Insert(int[] Array, int From, int To)
      {
        int Number = Array[From];
        for(int i=From; i>To; i--)
        {
          Array[i] = Array[i-1];
        }
        Array[To] = Number;
      }

      static bool IsSorted(int[] Array)
      {
        bool Result = true;
        int From = 0;
        int To = Array.Length - 1;

        for(int i=From; i<To; i++)
        {
          if(Array[i] > Array[i+1])
          {
            Result = false;
            break;
          }
        }
        return Result;
      }

      static void BubbleSort(int[] Array)
      {
        int Length = Array.Length;
        int Sorted = Length - 1;

        for(int i=Length-1; i>0; i--)
        {
          for(int j=0; j<i; j++)
          {
            if(Array[j] > Array[j+1])
            {
              int Temp = Array[j];
              Array[j] = Array[j+1];
              Array[j+1] = Temp;
            }
          }
        }
      }
    }
}