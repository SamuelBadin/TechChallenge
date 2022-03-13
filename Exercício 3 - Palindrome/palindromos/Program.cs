/* Problem #3
A palindrome is a string that is the same forwards and backwards. Write a function to verify if a 
string is a permutation (rearrangement) of a  palindrome.
Function Description
Implement the function isPalindromePermutation. It should return “YES” when the string is a permutation
of a palindrome, or “NO” when it is not. This implementation should have the order of complexity O(n)

Input Format
Parameter: A valid string.

Output Format
It should return “YES” when the string is a permutation of a palindrome, or “NO” when it is not.   */

using System;

namespace palindromos
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                Console.Write("Enter the string to be checked if is a palindrome permutation: ");
                var user_entry = Console.ReadLine();
                bool isPalindrome = isPalindromePermutation(user_entry);
                if (isPalindrome)
                {
                    Console.WriteLine("YES");
                }
                else
                {
                    Console.WriteLine("NO");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Something wrong occured, we're working to fix it.");
            }
        }

        private static bool isPalindromePermutation(string user_entry)
        {
            int numberOfOdds = 0;

            //Declaration of the array with size 128 (ASCII)
            int[] charMapping = new int[128];

            //Iteration in the array to match with ASCII. If the value is 0, it will be 1 and vice-versa.   
            foreach (char c in user_entry)
            {
                var charPosition = (int)c;

                if (charMapping[charPosition] == 0)
                {
                    charMapping[charPosition] = 1;
                }
                else if (charMapping[charPosition] == 1)
                {
                    charMapping[charPosition] = 0;
                }
            }
            // this foreach loop will check that there is only one odd valuey
            foreach (var i in charMapping)
            {
                if (numberOfOdds > 1)
                {
                    return false;
                }

                if (i == 1)
                {
                    numberOfOdds++;
                }
            }
            return true;
        }
    }
}
