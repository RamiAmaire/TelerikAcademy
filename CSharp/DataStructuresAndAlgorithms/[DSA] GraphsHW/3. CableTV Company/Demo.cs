using System;
using System.Collections.Generic;
using Wintellect.PowerCollections;

public class Demo
{
    private static List<string> SaveLines()
    {
        List<string> lines = new List<string>();
        string line = Console.ReadLine();

        while (line != string.Empty && line != null)
        {
            lines.Add(line);
            line = Console.ReadLine();
        }

        return lines;
    }

    private static Dictionary<char, Node<char>> SaveNodes(List<string> lines)
    {
        Dictionary<char, Node<char>> nodes = new Dictionary<char, Node<char>>();
        foreach (var line in lines)
        {
            string[] attribs = line.Split(new string[]{",", " ", "->", "{", "}"},
                StringSplitOptions.RemoveEmptyEntries);
            char parentValue = char.Parse(attribs[0]);
            if (!nodes.ContainsKey(parentValue))
            {
                nodes[parentValue] = new Node<char>(parentValue);
            }

            for (int i = 1; i < attribs.Length; i++)
            {
                string[] conAttribs = attribs[i].Split(new string[] {"(", ")" },
                    StringSplitOptions.RemoveEmptyEntries);
                char childValue = char.Parse(conAttribs[0]);
                int distance = int.Parse(conAttribs[1]);

                if (nodes.ContainsKey(childValue))
                {
                    nodes[parentValue].AddConnection(nodes[childValue], distance);
                }
                else
                {
                    Node<char> childNode = new Node<char>(childValue);
                    nodes[parentValue].AddConnection(childNode, distance);
                    nodes[childValue] = childNode;
                }
            }
        }

        return nodes;
    }

    private static long FindMinimumSpanningTree(Node<char> startingNode, int nodesCount)
    {
        PriorityQueue<Connection<char>> que = new PriorityQueue<Connection<char>>();
        foreach (var connection in startingNode.Connections)
        {
            que.Enqueue(connection);
        }

        HashSet<char> visitedNodes = new HashSet<char>();
        visitedNodes.Add(startingNode.Symbol);
        long sum = 0;
        while (que.Count > 0)
        {
            Connection<char> currentConnection = que.Dequeue();
            Node<char> currentNode = currentConnection.toNode;
            if (!visitedNodes.Contains(currentNode.Symbol))
            {
                sum += currentConnection.Distance;
                visitedNodes.Add(currentNode.Symbol);
                if (visitedNodes.Count == nodesCount)
                {
                    break;
                }

                foreach (var connection in currentNode.Connections)
                {
                    if (!visitedNodes.Contains(connection.toNode.Symbol))
                    {
                        que.Enqueue(connection);
                    }
                }
            }
        }

        return sum;
    }

    public static void Main()
    {
        List<string> lines = SaveLines();
        Dictionary<char, Node<char>> nodes = SaveNodes(lines);
        long sum = FindMinimumSpanningTree(nodes['A'], nodes.Values.Count);    
    }
}

