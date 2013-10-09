using System;
using System.Collections.Generic;
using System.Text;

class ExceptionsHomework
{
    public static T[] Subsequence<T>(T[] arr, int startIndex, int count)
    {
        #region Exceptions
        if (arr == null)
        {
            throw new ArgumentNullException("The given array cannot be null.");
        }

        if (arr.Length == 0)
        {
            throw new ArgumentException("The given array must containt atleast one value");
        }

        if (startIndex < 0 || startIndex >= arr.Length)
        {
            string message = "Start index " + startIndex + " must be between (0-" + arr.Length + ")";
            throw new ArgumentOutOfRangeException(message);
        }

        if (count < 0)
        {
            throw new ArgumentException("Count " + count + " cannot be negative.");
        }

        if (count > arr.Length)
        {
            throw new ArgumentOutOfRangeException(
                "Count " + count + " cannot be bigger than array's length : " + arr.Length);
        }

        if (count + startIndex > arr.Length)
        {
            throw new ArgumentOutOfRangeException(
                "The current count " +
                count +
                " is outside the bounds of the array, which are (0-" +
                arr.Length +
                ")");
        }
        #endregion

        List<T> result = new List<T>();
        for (int i = startIndex; i < startIndex + count; i++)
        {
            result.Add(arr[i]);
        }

        return result.ToArray();
    }

    public static string ExtractEnding(string str, int count)
    {
        #region Exceptions
        if (str == null)
        {
            throw new ArgumentNullException("The input string cannot be null.");
        }

        if (str.Length == 0)
        {
            throw new ArgumentException("The input string must contain atleast one character");
        }

        if (count < 0)
        {
            throw new ArgumentException("Count " + count + " cannot be negative.");
        }

        if (count > str.Length)
        {
            throw new ArgumentException("Count " +
                count +
                " cannot be more than the string's length : " + 
            str.Length);
        }
        #endregion

        StringBuilder result = new StringBuilder();
        for (int i = str.Length - count; i < str.Length; i++)
        {
            result.Append(str[i]);
        }

        return result.ToString();
    }

    public static void CheckPrime(int number)
    {
        if (number < 0)
        {
            throw new ArgumentException("Number " + number + " cannot be negative.");
        }

        if (number > int.MaxValue)
        {
            throw new ArgumentException("Number " + number + " cannot be bigger than " + int.MaxValue);
        }

        bool isPrime = true;
        for (int divisor = 2; divisor <= Math.Sqrt(number); divisor++)
        {
            if (number % divisor == 0)
            {
                isPrime = false;
            }
        }

        if (isPrime)
        {
            Console.WriteLine("Number {0} is prime.", number);
        }
        else
        {
            Console.WriteLine("Number {0} is not prime.", number);
        }
    }

    static void Main()
    {
        var substr = Subsequence("Hello!".ToCharArray(), 2, 3);
        Console.WriteLine(substr);

        var subarr = Subsequence(new int[] {-1, 3, 2, 1}, 0, 2);
        Console.WriteLine(String.Join(" ", subarr));

        var allarr = Subsequence(new int[] {-1, 3, 2, 1}, 0, 4);
        Console.WriteLine(String.Join(" ", allarr));

        var emptyarr = Subsequence(new int[] {-1, 3, 2, 1}, 0, 0);
        Console.WriteLine(String.Join(" ", emptyarr));

        Console.WriteLine(ExtractEnding("I love C#", 2));
        Console.WriteLine(ExtractEnding("Nakov", 4));
        Console.WriteLine(ExtractEnding("beer", 4));
        Console.WriteLine(ExtractEnding("Hi", 2));
        Console.WriteLine();

        CheckPrime(23);
        CheckPrime(33);
        Console.WriteLine();
    

        List<Exam> peterExams = new List<Exam>()
        {
            new SimpleMathExam(2),
            new CSharpExam(55),
            new CSharpExam(100),
            new SimpleMathExam(1),
            new CSharpExam(0),
        };

        Student peter = new Student("Peter", "Petrov", peterExams);
        double peterAverageResult = peter.CalcAverageExamResultInPercents();
        Console.WriteLine("Average results = {0:p0}", peterAverageResult);
    }
}
