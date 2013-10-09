using System;
using System.Collections.Generic;

public class Demo
{
    private static int[] GeneratePowerOf10Values()
    {
        int[] powerOf10 = new int[5];
        powerOf10[0] = 1;
        for (int i = 1; i < 5; i++)
        {
            powerOf10[i] = powerOf10[i - 1] * 10;
        }

        return powerOf10;
    }

    private static int BFS(int startPosition, int endPosition, HashSet<int> forbiddenPositions, int[] powerOf10)
    {
        HashSet<int> visitedPositions = new HashSet<int>();
        Queue<int> outerQue = new Queue<int>();
        outerQue.Enqueue(startPosition);
        int level = 0;

        while (outerQue.Count > 0)
        {
            Queue<int> innerQue = new Queue<int>();
            level++;
            while (outerQue.Count > 0)
            {
                int currentPosition = outerQue.Dequeue();
                if (currentPosition == endPosition)
                {
                    return level - 1;
                }
                else
                {
                    // Pressing the left button
                    for (int i = 0; i < 5; i++)
                    {
                        int newPosition = currentPosition;
                        int digit = (currentPosition / powerOf10[i]) % 10;
                        if (digit == 9)
                        {
                            newPosition -= 9 * powerOf10[i];
                        }
                        else
                        {
                            newPosition += powerOf10[i];
                        }

                        if (!visitedPositions.Contains(newPosition) && !forbiddenPositions.Contains(newPosition))
                        {
                            visitedPositions.Add(newPosition);
                            innerQue.Enqueue(newPosition);
                        }
                    }

                    // Pressing the right button
                    for (int i = 0; i < 5; i++)
                    {
                        int newPosition = currentPosition;
                        int digit = (currentPosition / powerOf10[i]) % 10;
                        if (digit == 0)
                        {
                            newPosition += 9 * powerOf10[i];
                        }
                        else
                        {
                            newPosition -= powerOf10[i];
                        }

                        if (!visitedPositions.Contains(newPosition) && !forbiddenPositions.Contains(newPosition))
                        {
                            visitedPositions.Add(newPosition);
                            innerQue.Enqueue(newPosition);
                        }
                    }
                }
            }

            outerQue = innerQue;
        }

        return -1;
    }

    public static void Main()
    {
        int startPosition = int.Parse(Console.ReadLine());
        int endPosition = int.Parse(Console.ReadLine());
        int numberOfForbiddenNodes = int.Parse(Console.ReadLine());
        HashSet<int> forbiddenPositions = new HashSet<int>();

        for (int i = 0; i < numberOfForbiddenNodes; i++)
        {
            int forbiddenPosition = int.Parse(Console.ReadLine());
            forbiddenPositions.Add(forbiddenPosition);
        }

        int[] powerOf10 = GeneratePowerOf10Values();
        int result = BFS(startPosition, endPosition, forbiddenPositions, powerOf10);
        Console.WriteLine(result);
    }
}
