using System;
using System.Collections.Generic;
using System.Linq;
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

    private static Dictionary<char, string> DijkstraAlgorithm(Node<char> startingNode, HashSet<char> visitedNodes)
    {
        Dictionary<char, string> paths = new Dictionary<char, string>();
        paths[startingNode.Symbol] = startingNode.Symbol.ToString();

        PriorityQueue<Node<char>> queue = new PriorityQueue<Node<char>>();
        startingNode.Weight = 0;
        queue.Enqueue(startingNode);

        while (queue.Count > 0)
        {
            Node<char> currentNode = queue.Dequeue();
            visitedNodes.Add(currentNode.Symbol);
            foreach (var connection in currentNode.Connections)
            {
                Node<char> toNode = connection.ToNode;
                if (!visitedNodes.Contains(toNode.Symbol))
                {
                    long temporaryWeight = currentNode.Weight + connection.Distance;
                    if (temporaryWeight < toNode.Weight)
                    {
                        toNode.Weight = temporaryWeight;
                        queue.Enqueue(toNode);

                        paths[toNode.Symbol] = paths[currentNode.Symbol] + " -> " +
                            toNode.Symbol + "(" + toNode.Weight + ")";
                    }
                }
            }
        }

        return paths;
    }

    private static void ResetWeights(List<Node<char>> nodes)
    {
        foreach (var node in nodes)
        {
            node.Weight = long.MaxValue;
        }
    }

    public static void Main()
    {
        List<string> lines = SaveLines();
        Dictionary<char, Node<char>> nodes = SaveNodes(lines);
        
        ResetWeights(nodes.Values.ToList());
        Dictionary<char, string> paths = DijkstraAlgorithm(nodes['A'], new HashSet<char>());
        Console.WriteLine(paths['V']);
    }
}

