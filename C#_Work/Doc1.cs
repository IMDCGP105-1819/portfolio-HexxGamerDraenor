using System;
using System.Collections.Generic;

namespace Sorting
{
    class Program
    {
        static void BubbleSort(int[] array)
        {
            bool swapped = false;
            do
            {
                swapped = false;
                for(var i = 1; i < array.Length; i++)
                {
                    if (array[i - 1] > array[i])
                    {
                        int temp = array[i];
                        array[i] = array[i - 1];
                        array[i - 1] = temp;
                        swapped = true;
                    }
                }
            } while (swapped);
        }
        static void Main(string[] args)
        {
            Console.WriteLine("Hello ");
            int[] numbers = { 13, 42, 12, 6, 12, 7 };

            for (int i = 0; i < numbers.Length; i++)
            {
                Console.WriteLine(numbers[i].ToString() + "");
            }
            Console.Write("\n");

            BubbleSort(numbers);

            for (int i = 0; i < numbers.Length; i++)
            {
                Console.WriteLine(numbers[i].ToString() + "");
            }
            Console.Write("\n");

            Console.ReadLine();
        }
    }
}
