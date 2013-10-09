using System;

public class Demo
{
    static void GenerateCombinationsNoRepetitions(char[]balls, char[]holder, int currentIndex, int start, ref int counter)
    {
        if (currentIndex == holder.Length)
        {
            counter++;
        }
        else
        {
            for (int i = start; i < balls.Length; i++)
            {
                holder[currentIndex] = balls[i];
                GenerateCombinationsNoRepetitions(balls, holder, currentIndex + 1, i, ref counter);
            }
        }
    }


    private static char[] SaveBalls(string ballsInput)
    {
        char[] balls = new char[ballsInput.Length];
        for (int i = 0; i < ballsInput.Length; i++)
        {
            balls[i] = ballsInput[i];
        }

        return balls;
    }

    public static void Main()
    {
        string ballsInput = Console.ReadLine();

        char[] balls = SaveBalls(ballsInput);
        bool[] usedBalls = new bool[balls.Length];
        char[] holder = new char[balls.Length];
        int counter = 0;

        GenerateCombinationsNoRepetitions(balls, holder, 0, 0, ref counter);
    }
}
