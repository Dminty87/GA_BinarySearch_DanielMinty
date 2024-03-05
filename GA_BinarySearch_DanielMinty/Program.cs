using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace GA_BinarySearch_DanielMinty
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //Maximum and minimum values for randomly generating the size of the array
            //Program will crash if the array has length 0
            int arraySizeMin = 10;
            int arraySizeMax = 10;

            //Maximum and minimum values for randomly generating the values stored in the array and the target value of the binary search
            int arrayValueMin = 0;
            int arrayValueMax = 10;

            //Determines whether the target element should be guaranteed to exist in the array
            bool guaranteeTarget = false;

            //Timers for the recursive and iterative searches
            Stopwatch recursiveTimer = new Stopwatch();
            Stopwatch iterativeTimer = new Stopwatch();

            //Create an instance of the Random class
            Random rand = new Random();

            //Create an array with a random size restricted by arraySizeMin/Max
            int[] array = new int[rand.Next(arraySizeMin, arraySizeMax)];

            //Populate the array with random values restricted by arrayValueMin/Max
            for (int i = 0; i < array.Length; i++)
            {
                array[i] = rand.Next(arrayValueMin, arrayValueMax);
            }

            //Randomize the target value for the binary search with the same restrictions as the array values
            int target = rand.Next(arrayValueMin, arrayValueMax);

            //If the target shold be guaranteed in the array, override it into a random position
            if (guaranteeTarget)
            {
                array[rand.Next(0, array.Length - 1)] = target;
            }

            //Sort the array
            Array.Sort(array);

            //Display the sorted array
            Console.Write("Sorted Array: ");
            for (int i = 0; i < array.Length - 1; i++)
            {
                Console.Write(array[i] + ", ");
            }
            Console.WriteLine(array[array.Length - 1] + ".");

            //Display the target value
            Console.WriteLine($"Target Value: {target}");

            //Time the recursive binary search
            recursiveTimer.Start();
            int targetIndexR = BinarySearch.RecursiveBinarySearch(array, target);
            recursiveTimer.Stop();

            //Time the iterative binary search
            iterativeTimer.Start();
            int targetIndexI = BinarySearch.IterativeBinarySearch(array, target);
            iterativeTimer.Stop();

            //Display the result of the recursive binary search
            if (targetIndexR < 0)
            {
                Console.WriteLine($"Recursive: The target value was not found in {recursiveTimer.ElapsedMilliseconds} miliseconds.");
            }
            else
            {
                Console.WriteLine($"Recursive: The target value was found at index {targetIndexR} in {recursiveTimer.ElapsedMilliseconds} miliseconds.");
            }

            //Display the result of the iterative binary search
            if (targetIndexR < 0)
            {
                Console.WriteLine($"Iterative: The target value was not found in {iterativeTimer.ElapsedMilliseconds} miliseconds.");
            }
            else
            {
                Console.WriteLine($"Iterative: The target value was found at index {targetIndexI} in {iterativeTimer.ElapsedMilliseconds} miliseconds.");
            }

            //Keep the window open
            Console.ReadLine();
        }
    }
}
