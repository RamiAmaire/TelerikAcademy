namespace Methods
{
    using System;

    public class Methods
    {
        /// <summary>Calculates the triangle area.</summary>
        /// <exception cref="ArgumentException">
        ///     Thrown when one or more arguments have unsupported or illegal values.
        /// </exception>
        /// <param name="sideA">The side a.</param>
        /// <param name="sideB">The side b.</param>
        /// <param name="sideC">The side c.</param>
        /// <returns>The calculated triangle area.</returns>
        public static double CalculateTriangleArea(double sideA, double sideB, double sideC)
        {
            if (sideA <= 0)
            {
                string message = 
                    "Side A must be positive number between (1 - " + double.MaxValue + ")";
                throw new ArgumentException(message);
            }

            if (sideB <= 0)
            {
                string message = 
                    "Side B must be positive number between (1 - " + double.MaxValue + ")";
                throw new ArgumentException(message);
            }

            if (sideC <= 0)
            {
                string message = 
                    "Side B must be positive number between (1 - " + double.MaxValue + ")";
                throw new ArgumentException(message);
            }

            double semiPerimeter = (sideA + sideB + sideC) / 2;
            double area = semiPerimeter *
                (semiPerimeter - sideA) *
                (semiPerimeter - sideB) *
                (semiPerimeter - sideC);
            area = Math.Sqrt(area);

            return area;
        }

        /// <summary>Convert number to digit.</summary>
        /// <exception cref="ArgumentException">
        ///     Thrown when one or more arguments have unsupported or illegal values.
        /// </exception>
        /// <param name="number">Number of.</param>
        /// <returns>The number converted to digit.</returns>
        public static string ConvertNumberToDigit(int number)
        {
            if (number < 0 || number > 9)
            {
                throw new ArgumentException(
                    "The input number must be in the range between (0-9)");
            }

            switch (number)
            {
                case 0: return "zero";
                case 1: return "one";
                case 2: return "two";
                case 3: return "three";
                case 4: return "four";
                case 5: return "five";
                case 6: return "six";
                case 7: return "seven";
                case 8: return "eight";
                case 9: return "nine";
                default: return "The input number must be in the range between 0-9";
            }
        }

        /// <summary>   
        ///     Searches for the biggest integer in an array
        /// </summary>
        /// <exception cref="ArgumentNullException">
        ///     Thrown when one or more required arguments are null.
        /// </exception>
        /// <exception cref="ArgumentException">
        ///     Thrown when one or more arguments have unsupported or illegal values.
        /// </exception>
        /// <param name="numbers">A variable-length parameters list containing numbers.</param>
        /// <returns>The found biggest number.</returns>
        public static int FindMax(params int[] numbers)
        {
            if (numbers == null)
            {
                throw new ArgumentNullException(
                    "The given array must not be null.");
            }

            if (numbers.Length == 0)
            {
                throw new ArgumentException(
                    "The given array must contain atleast one number.");
            }

            var max = numbers[0];
            for (int i = 1; i < numbers.Length; i++)
            {
                var currentNumber = numbers[i];
                if (currentNumber > max)
                {
                    max = currentNumber;
                }
            }

            return max;
        }

        /// <summary>Print decimal number in given format.</summary>
        /// <exception cref="ArgumentException">
        ///     Thrown when one or more arguments have unsupported or illegal values.
        /// </exception>
        /// <param name="number">Number of.</param>
        /// <param name="format">Describes the format to use.</param>
        public static void PrintDecimalNumberInGivenFormat(decimal number, string format)
        {
            if (number < decimal.MinValue || number > decimal.MaxValue)
            {
                throw new ArgumentException(
                    "The given number is not in the required range between (" +
                    decimal.MinValue +
                    " - " +
                    decimal.MaxValue +
                    ")");
            }

            if (format == null)
            {
                throw new ArgumentException("The given string format cannot be null");
            }

            if (format != "f" && format != "%" && format != "r")
            {
                throw new ArgumentException(
                    "The given string format is invalid. " +
                    "It must be either \"f\", \"%\" or \"r\".");
            }

            string result = string.Empty;
            if (format == "f")
            {
                result = string.Format("{0:f2}", number);
                Console.WriteLine("{0} formatted = {1}", number, result);
            }

            if (format == "%")
            {
                result = string.Format("{0:p0}", number);
                Console.WriteLine("{0} in percentage = {1}", number, result);
            }

            if (format == "r")
            {
                result = string.Format("{0,8}", number);
                Console.WriteLine("{0} formatted = {1}", number, result);
            }
        }

        /// <summary>Calculates the distance between two points.</summary>
        /// <param name="pointOne"> The point one.</param>
        /// <param name="pointTwo"> The point two. </param>
        /// <returns>The calculated distance between two points.</returns>
        public static double CalcDistanceBetweenTwoPoints(Point pointOne, Point pointTwo)
        {
            double distance = ((pointTwo.X - pointOne.X) * (pointTwo.X - pointOne.X)) +
                ((pointTwo.Y - pointOne.Y) * (pointTwo.Y - pointOne.Y));
            distance = Math.Sqrt(distance);

            return distance;
        }

        /// <summary>Check's if two points are horizontal or vertical.</summary>
        /// <param name="pointOne">The point one.</param>
        /// <param name="pointTwo">The point two.</param>
        /// <param name="isHorizontal">[out] The is horizontal.</param>
        /// <param name="isVertical">[out] The is vertical.</param>
        public static void CheckIfTwoPointsAreHorizonalOrVertical(
            Point pointOne,
            Point pointTwo,
            out bool isHorizontal,
            out bool isVertical)
        {
            isHorizontal = pointOne.Y == pointTwo.Y;
            isVertical = pointOne.X == pointTwo.X;
        }

        public static void Main()
        {
            // CalculateTriangleArea method
            double a = 5;
            double b = 4;
            double c = 5;
            double area = CalculateTriangleArea(a, b, c);
            Console.WriteLine(
                "The area of triangle with sides ({0}, {1}, {2}) = {3}", a, b, c, area);
            Console.WriteLine();

            // ConvertNumberToDigit method
            int number = 3;
            string digit = ConvertNumberToDigit(number);
            Console.WriteLine("Number {0} to digit = {1}", number, digit);
            Console.WriteLine();
            
            // FindMax method
            int max = FindMax(2, 5, 9, 11);
            Console.WriteLine("Max: {0}", max);
            Console.WriteLine();

            // PrintDecimalNumberInGivenFormat method
            PrintDecimalNumberInGivenFormat(1.3m, "f");
            PrintDecimalNumberInGivenFormat(0.75m, "%");
            PrintDecimalNumberInGivenFormat(2.30m, "r");
            Console.WriteLine();

            // CalcDistanceBetweenTwoPoints method
            Point pointOne = new Point(5, 10);
            Point pointTwo = new Point(5, 20);
            double distance = CalcDistanceBetweenTwoPoints(
                pointOne,
                pointTwo);

            Console.WriteLine(
                "The distance between point({0},{1}) and point({2},{3}) is: {4}",
                pointOne.X,
                pointOne.Y,
                pointTwo.X,
                pointTwo.Y,
                distance);
            Console.WriteLine();

            // CheckIfTwoPointsAreHorizonalOrVertical method
            bool isHorizontal, isVertical;
            CheckIfTwoPointsAreHorizonalOrVertical(
                new Point(5, 10),
                new Point(5, 20),
                out isHorizontal,
                out isVertical);

            Console.WriteLine(
                "Are point({0},{1}) and point({2},{3}) horizontal ? {4}",
                pointOne.X,
                pointOne.Y,
                pointTwo.X,
                pointTwo.Y,
                isHorizontal);
            Console.WriteLine(
                "Are point({0},{1}) and point({2},{3}) vertical ? {4}",
                pointOne.X,
                pointOne.Y,
                pointTwo.X,
                pointTwo.Y,
                isVertical);
            Console.WriteLine();

            // Comparing two students by birth date.
            Student peter = new Student();
            peter.FirstName = "Peter";
            peter.LastName = "Ivanov";
            peter.BirthDate = new DateTime(1989, 03, 17);
            peter.AdditionalInformation = "From Sofia";

            Student stella = new Student();
            stella.FirstName = "Stella";
            stella.LastName = "Markova";

            // 1991 is l337
            stella.BirthDate = new DateTime(1991, 11, 03);
            stella.AdditionalInformation = "From Vidin, gamer, high results";

            Console.WriteLine(
                "Is {0} older than {1} ? {2}",
                peter.FirstName,
                stella.FirstName,
                peter.IsOlderThan(stella));
        }
    }
}
