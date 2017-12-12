using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;


namespace Advent_of_Code_2017___01
{
    class Program
    {
        static void Main(string[] args)
        {
            ///////////////////////
            //       Setup       //
            ///////////////////////

            int sum = 0;

            Console.WriteLine("Grabbing input...");
            string input = File.ReadAllText(@"C:\Users\ben.rendall\Drive Documents\Visual Studio\Projects\Advent of Code 2017\Advent of Code 2017 - 01\Day1Input.txt");
            //string input = "123123";

            Console.WriteLine("Splitting input string into array..");
            char[] digits = input.ToCharArray();

            Console.Write("Setting variables...");
            int place = 0;
            int digitsMax = (digits.Count() - 1);
            Console.WriteLine("'place' set to 0; digitsMax set to " + (digitsMax + 1));

            ///////////////////////
            //     Section 1     //
            ///////////////////////

            Console.WriteLine("Section 1");
            Console.WriteLine("Running loop..");
            for(int i = 0; i <= digitsMax; i++)
            {
                try
                {
                    if (digits[place] == digits[(place + 1)])
                    {
                        int digitInt = Convert.ToInt32(char.GetNumericValue(digits[place]));
                        sum = sum + digitInt;
                    }
                }
                catch(IndexOutOfRangeException)
                {
                    if(place == digitsMax)
                    {
                        if(digits[0] == digits[(digitsMax)])
                        {
                            sum =  sum + Convert.ToInt32(char.GetNumericValue(digits[0]));
                        }
                    }
                }
                finally
                {
                    place++;
                }
            }

            Console.WriteLine("Section 1 answer: " + sum);

            ///////////////////////
            //     Section 2     //
            ///////////////////////

            Console.WriteLine("");
            Console.WriteLine("Section 2");
            sum = 0;
            place = 0;
            Console.WriteLine("Running loop..");
            for (int i = 0; i <= digitsMax; i++)
            {
                int halfPos = halfwayPosLocation(place, digitsMax);
                int digitPlaceInt = Convert.ToInt32(char.GetNumericValue(digits[place]));
                int digitHalfPlaceInt = Convert.ToInt32(char.GetNumericValue(digits[halfPos]));

                try
                {
                    if (digitPlaceInt == digitHalfPlaceInt)
                    {
                        int digitInt = Convert.ToInt32(char.GetNumericValue(digits[place]));
                        sum = sum + digitInt;
                    }
                }
                catch (IndexOutOfRangeException)
                {
                    if (place == digitsMax)
                    {
                        if (digits[0] == digits[(digitsMax)])
                        {
                            sum = sum + Convert.ToInt32(char.GetNumericValue(digits[0]));
                        }
                    }
                }
                finally
                {
                    place++;
                }
            }

            Console.WriteLine("Section 2 answer: " + sum);
            Console.ReadKey();
        }



        private static int halfwayPosLocation(int place, int digitsMax)
        {
            int halfMax = (digitsMax + 1) / 2;
            int halfPosCheck = place + halfMax;

            if (halfPosCheck <= digitsMax)
            {
                return halfPosCheck;
            }
            else
            {
                int excess = halfPosCheck - digitsMax;
                place = (excess - 1);
                return place;
            }
        }
    }
}
