/*
Problem #1
Convert a currency numeric amount into words (in Portuguese), as shown below:
Function Description
Implement the convertAmount2Words function. It should convert currency numeric amount into words (in Portuguese).

Input Format

Parameters:
    • m: an integer representing the reais, 0 <= m < 109
    • n: an integer representing the cents, 0 <= n < 100
Output Format
Print the amount in words.

*/
//I splitted the code into two different functions (one for reais and another for centavos).

using System;

namespace ExercicioConversor
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                // an integer representing the "reais".
                Int32 m = Int32.Parse(Console.ReadLine());
                // an integer representing the "centavos"
                int n = int.Parse(Console.ReadLine());
                Console.Write(convertAmount2Words(m) + " reais ");
                if (n != 0)
                {
                    Console.WriteLine("e "+ getDecimal(n) + " centavos");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Value not accepted by the system!");
            }

        }

        public static string convertAmount2Words(Int32 m)
        {
            string finalWord = "";
            //if the value inserted by the user is zero, it will return zero
            if (m == 0)
                return "Zero";
            //if the user inserts a negative value, the word Menos will be printed along with the function
            if (m < 0)
                return "Menos " + convertAmount2Words(Math.Abs(m));
            //check the value inserted and keeps decreasing value
            if ((m / 1000000000) > 0)
            {
                finalWord += convertAmount2Words(m / 1000000000) + " bilhão ";
                m %= 1000000000;
            }

            if ((m / 1000000) > 0)
            {
                finalWord += convertAmount2Words(m / 1000000) + " milhão ";
                m %= 1000000;
            }

            if ((m / 1000) > 0)
            {
                finalWord += convertAmount2Words(m / 1000) + " mil ";
                m %= 1000;
            }

            if ((m / 100) > 0)
            {
                finalWord += convertAmount2Words(m / 100) + " cento ";
                m %= 100;
            }

            if (m > 0)
            {
                if (finalWord != "")
                {
                    finalWord += "e ";
                }
                //arrays with both unit values and ten values
                var unitValues = new[] { "zero", "um", "dois", "três", "quatro", "cinco", "seis", "sete", "oito", "nove", "dez", "onze", "doze", "treze", "quatorze", "quinze", "dezesseis", "dezessete", "dezoito", "dezenove" };
                var tenValues = new[] { "zero", "dez", "vinte", "trinta", "quarenta", "cinquenta", "sessenta", "setenta", "oitenta", "noventa" };

                //if value is lower than 20, we'll use directly the first array

                if (m < 20)
                    finalWord += unitValues[m];
                //else, we get the value from the array tenValues
                else
                {
                    finalWord += tenValues[m / 10];
                    if ((m % 10) > 0)
                        finalWord += " e " + unitValues[m % 10];
                }
            }
            //return of the completed string 
            return finalWord;
        }

        public static string getDecimal(int n) 
        {
            string finalWordDecimal = "";
            var unitValues = new[] { "zero", "um", "dois", "três", "quatro", "cinco", "seis", "sete", "oito", "nove", "dez", "onze", "doze", "treze", "quatorze", "quinze", "dezesseis", "dezessete", "dezoito", "dezenove" };
            var tenValues = new[] { "zero", "dez", "vinte", "trinta", "quarenta", "cinquenta", "sessenta", "setenta", "oitenta", "noventa" };

            //if value is lower than 20, we'll use directly the first array
            if (n < 20)
                finalWordDecimal += unitValues[n];

            //else, we get the value from the array tenValues
            else
            {
                finalWordDecimal += tenValues[n / 10];
                if ((n % 10) > 0)
                    finalWordDecimal +=  " e " + unitValues[n % 10];
            }
        
            //return of the completed string 
            return finalWordDecimal;
        
        }
    }
}
