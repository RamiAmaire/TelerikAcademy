using System;
using System.Collections.Generic;
using System.Linq;

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
            string[] attribs = line.Split(new string[] {" ", ",", "{", "}", "->" },
                StringSplitOptions.RemoveEmptyEntries);

            char parentValue = char.Parse(attribs[0]);
            if (!nodes.ContainsKey(parentValue))
            {
                nodes[parentValue] = new Node<char>(parentValue);
            }

            for (int i = 1; i < attribs.Length; i++)
            {
                char childValue = char.Parse(attribs[i]);
                if (nodes.ContainsKey(childValue))
                {
                    nodes[parentValue].AddChild(nodes[childValue]);
                }
                else
                {
                    Node<char> childNode = new Node<char>(childValue);
                    nodes[parentValue].AddChild(childNode);
                    nodes[childValue] = childNode;
                }
            }
        }

        return nodes;
    }

    private static bool CheckIfEulerCircuitIsPossible(List<Node<char>> nodes)
    {
        foreach (var node in nodes)
        {
            if (node.Children.Count % 2 == 1)
            {
                return false;
            }
        }

        return true;
    }

    private static void SaveEulerCircuitPath(Node<char> currentNode,
        HashSet<char> visitedNodes, string path)
    {

    }

    public static void Main()
    {
        List<string> lines = SaveLines();
        Dictionary<char, Node<char>> nodes = SaveNodes(lines);
        bool isEulerCircuitPossible = CheckIfEulerCircuitIsPossible(nodes.Values.ToList());

        if (isEulerCircuitPossible)
        {
            
        }
    }
}

