using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GA_BinarySearch_DanielMinty
{
    internal static class BinarySearch
    {
        //public RBS method with minimal parameters to begin the recursion
        public static int RecursiveBinarySearch(int[] array, int target)
        {
            return RecursiveBinarySearch(array, target, 0, array.Length - 1);
        }

        //private RBS method with all parameters to perform the recursion
        private static int RecursiveBinarySearch(int[] array, int target, int left, int right)
        {
            //Base case: Left > Right
            if (left > right)
            {
                return -1;
            }

            //Calculate Middle Index
            int middleIndex = (right - left) / 2 + left;

            //Compare Middle value to target value
            //If the middle element matches the target element, return the middle Index
            if (target == array[middleIndex])
            {
                return middleIndex;
            }
            //If the target element is less than the middle element,
            if (target < array[middleIndex])
            {//call RecursiveBinarySearch restricting the search to between left and middle(excluded)
                return RecursiveBinarySearch(array, target, left, middleIndex - 1);
            }
            //If the target element is greater than the middle element,
            if (target > array[middleIndex])
            {//call RecursiveBinarySearch restricting the search to between middle(excluded) and right
                return RecursiveBinarySearch(array, target, middleIndex + 1, right);
            }

            //Make all code paths return a value
            return -1;
        }

        public static int IterativeBinarySearch(int[] array, int target)
        {
            //Left and right pointers restrict the area of the search each iteration
            int left = 0;
            int right = array.Length - 1;

            //while the left and right pointers haven't passed eachother, there is still more array to search
            while (left <= right)
            {
                //calculate the index in the middle of the l/r pointers
                int middleIndex = (right - left) / 2 + left;

                //Compare the target to the middle value
                //if the middle value matches the target element, return the middle index
                if (target == array[middleIndex])
                {
                    return middleIndex;
                }
                //if the target is less than the middle value, exclude the right half of the array from the search
                if (target < array[middleIndex])
                {
                    right = middleIndex - 1;
                }
                else//the target is greater than the middle value, exclude the left half of the array from the search
                {
                    left = middleIndex + 1;
                }
            }//when the left and right pointers pass eachother,
            //the array has been searched and the target was not found
            return -1;

        }// method IterativeBinarySearch

    }//class BinarySearch
}
