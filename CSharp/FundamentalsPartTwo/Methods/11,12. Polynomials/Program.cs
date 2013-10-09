using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace _11_12.Polynomials
{
    class Program
    {
        static void SumOfPolinomials(decimal[] firstPolinomial, decimal[] secondPolinomial, decimal[] result)
        {
            int minLenght = 0;
            int smallerPolinomial = 0;

            if (firstPolinomial.Length > secondPolinomial.Length)
            {
                minLenght = secondPolinomial.Length;
                smallerPolinomial = 2;
            }
            else
            {
                minLenght = firstPolinomial.Length;
                smallerPolinomial = 1;
            }

            for (int i = 0; i < minLenght; i++)
            {
                result[i] = firstPolinomial[i] + secondPolinomial[i];
            }

            for (int i = minLenght; i < result.Length; i++)
            {
                if (smallerPolinomial == 1)
                {
                    result[i] = secondPolinomial[i];
                }
                else
                {
                    result[i] = firstPolinomial[i];
                }
            }
        }
        static void SubstractionOfPolinomials(decimal[] firstPolinomial, decimal[] secondPolinomial, decimal[] result)
        {
            int minLenght = 0;
            int smallerPolinomial = 0;

            if (firstPolinomial.Length > secondPolinomial.Length)
            {
                minLenght = secondPolinomial.Length;
                smallerPolinomial = 2;
            }
            else
            {
                minLenght = firstPolinomial.Length;
                smallerPolinomial = 1;
            }

            for (int i = 0; i < minLenght; i++)
            {
                result[i] = firstPolinomial[i] - secondPolinomial[i];
            }

            for (int i = minLenght; i < result.Length; i++)
            {
                if (smallerPolinomial == 1)
                {
                    result[i] = secondPolinomial[i];
                }
                else
                {
                    result[i] = firstPolinomial[i];
                }
            }
        }
        static void MultiplyPolinomials(decimal[] firstPolinomial, decimal[] secondPolinomial, decimal[] result)
        {
            for (int i = 0; i < result.Length; i++)
            {
                result[i] = 0;
            }

            for (int i = 0; i < firstPolinomial.Length; i++)
            {
                for (int j = 0; j < secondPolinomial.Length; j++)
                {
                    int position = i + j;
                    result[position] += (firstPolinomial[i] * secondPolinomial[j]);
                }
            }
        }
        static void PrintPolinomial(decimal[] polinomial)
        {
            for (int i = polinomial.Length - 1; i >= 0; i--)
            {
                if (polinomial[i] != 0 && i != 0)
                {
                    if (polinomial[i - 1] >= 0)
                    {
                        Console.Write("{1}x^{0} +", i, polinomial[i]);
                    }
                    else
                    {
                        Console.Write("{1}x^{0} ", i, polinomial[i]);
                    }
                }
                else if (i == 0)
                {
                    Console.Write("{0}", polinomial[i]);
                }
            }
            Console.WriteLine();
        }
        static void Main()
        {
            decimal[] firstPolinomial = { 5, -1 };
            Console.Write("First polinomial:                 ");
            PrintPolinomial(firstPolinomial);
            decimal[] secondPolinomial = { 10, -5, 6 };
            Console.Write("Second polinomial:                ");
            PrintPolinomial(secondPolinomial);

            int maxLenght = 0;
            if (firstPolinomial.Length > secondPolinomial.Length)
            {
                maxLenght = firstPolinomial.Length;
            }
            else
            {
                maxLenght = secondPolinomial.Length;
            }
            decimal[] result = new decimal[maxLenght];
            Console.WriteLine();
            SumOfPolinomials(firstPolinomial, secondPolinomial, result);
            Console.Write("Sum:                              ");
            PrintPolinomial(result);
            SubstractionOfPolinomials(firstPolinomial, secondPolinomial, result);
            Console.Write("Substraction:                     ");
            PrintPolinomial(result);

            decimal[] multiply = new decimal[firstPolinomial.Length + secondPolinomial.Length];
            MultiplyPolinomials(firstPolinomial, secondPolinomial, multiply);
            Console.Write("Multiplication:                   ");
            PrintPolinomial(multiply);
        }
    }
}
