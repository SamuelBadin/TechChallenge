/* Problem #2
A robot walks in 2d space, like a chess board. It is instructed to perform his movements using the following commands:
    • U: up->move to one position up
    • D: down->move to one position down
    • L: left->move to one position to the left
    • R: right->move to one position to the right
Each movement has the same measure, going from one position to another on the board
Identify when the robot returns to a point where it has already been, closing a loop (circle). Print which commands the
robot executed to close the loop.
Function Description
Implement the function getLastLoop. This implementation should have the order of complexity O(n)

Input Format

Parameter: A string with the commands

Output Format
A string with the command to close the last loop.  */

using System;
using System.Collections.Generic;


namespace Robot
{
    class Program
    {
        public static string getLastLoop(String strMove)
        {
            //Declarations of all variables. The exercise is divided in two parts:
            //The walking of the robot through the commands UPLR and storing the positions of the List.
            int length = strMove.Length;
            int countUp = 0, countDown = 0, countLeft = 0, countRight = 0;
            string actualPosition;
            string concatedLoop = "";
            string valueToStop = "";
            int myIndex = 0;
            List<string> visitedPositions = new List<string>();
            //loop responsible to add the positions in final array as well as compare the movement given
            for (int i = 0; i < length; i++)
            {
                actualPosition = "";

                switch (strMove[i])
                {
                    case 'U':
                        countUp++;
                        break;

                    case 'D':
                        countDown++;
                        break;

                    case 'L':
                        countLeft++;
                        break;

                    case 'R':
                        countRight++;
                        break;

                    default:
                        Console.WriteLine("One of the values inserted is not suppported. Please rerun and type U, D, L or R");
                        break;
                }

                //I've decided to create an array with the pairs of the 2D matrix (ex 12, 11, 10, 1-1, etc...)
                actualPosition = (countRight - countLeft).ToString();
                actualPosition += (countUp - countDown).ToString();
                //Index + 1 used in order to not consider the first and last element of the cycle twice
                if (i > myIndex + 1)
                {
                    concatedLoop += strMove[i];
                }

                //If doesn't contains the actual position in visited positions, add it to array.
                if (!visitedPositions.Contains(actualPosition))
                {
                    visitedPositions.Add(actualPosition);
                }
                //When the value found is already inside array, break loop and get positions
                else
                {
                    valueToStop = actualPosition;
                    myIndex = visitedPositions.IndexOf(valueToStop);
                    break;
                }

            }
            return concatedLoop;
        }

        public static void Main()
        {
            Console.Write("Please, insert the path you want the robot to cover: ");
            String strMove = Console.ReadLine();
            Console.WriteLine("The string with the last loop is: " + getLastLoop(strMove));
        }
    }
}
