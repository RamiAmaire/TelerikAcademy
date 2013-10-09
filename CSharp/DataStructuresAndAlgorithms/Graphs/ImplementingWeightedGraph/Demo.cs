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
            string[] attributes = line.Split(new string[] {" ", ", ", "{", "}", "->" },
                StringSplitOptions.RemoveEmptyEntries);

            char parentSymbol = char.Parse(attributes[0]);
            if (!nodes.ContainsKey(parentSymbol))
            {
                nodes[parentSymbol] = new Node<char>(parentSymbol);
            }

            for (int i = 1; i < attributes.Length; i++)
            {
                string[] childAttribs = attributes[i].Split(new string[] {")", "(" },
                    StringSplitOptions.RemoveEmptyEntries);

                char childSymbol = char.Parse(childAttribs[0]);
                int distance = int.Parse(childAttribs[1]);

                if (nodes.ContainsKey(childSymbol))
                {
                    nodes[parentSymbol].AddChild(nodes[childSymbol], distance);
                }
                else
                {
                    Node<char> childNode = new Node<char>(childSymbol);
                    nodes[parentSymbol].AddChild(childNode, distance);
                    nodes[childSymbol] = childNode;
                }
            }
        }

        return nodes;
    }

    private static void SaveShortestPaths(Node<char> currentNode, Node<char> endNode,
        HashSet<char> visitedNodes, OrderedSet<Node<char>> nextNodes, Dictionary<char, string> paths)
    {
        if (paths.Count == 0)
        {
            paths.Add(currentNode.Symbol, currentNode.Symbol.ToString());
        }

        visitedNodes.Add(currentNode.Symbol);
        foreach (var nodeDistance in currentNode.Children)
        {
            Node<char> child = nodeDistance.Key;
            if (!visitedNodes.Contains(child.Symbol))
            {
                int temporaryWeight = nodeDistance.Value + currentNode.Weight;
                if (child.Weight == 0 || child.Weight > temporaryWeight)
                {
                    if (nextNodes.Contains(child))
                    {
                        nextNodes.Remove(child);
                    }

                    child.Weight = temporaryWeight;
                    paths[child.Symbol] = paths[currentNode.Symbol] + " -> " +
                        child.Symbol.ToString() + "(" + child.Weight + ")";
                }

                nextNodes.Add(child);
            }
        }

        Node<char> nextNode = nextNodes[0];
        nextNodes.Remove(nextNode);
        if (nextNodes.Count == 0)
        {
            return;
        }

        SaveShortestPaths(nextNode, endNode, visitedNodes, nextNodes, paths);
    }

    public static void Main()
    {
        List<string> lines = SaveLines();
        Dictionary<char, Node<char>> nodes = SaveNodes(lines);
        Dictionary<char, string> paths = new Dictionary<char, string>();

        SaveShortestPaths(nodes['F'], nodes['A'], new HashSet<char>(), new OrderedSet<Node<char>>(), paths);
        Console.WriteLine(paths['A']);
    }
}

