using System;
using System.Collections.Generic;
using System.Linq;

public class SolvingNTasks
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

    private static Dictionary<int, Node<int>> SaveNodes(List<string> lines)
    {
        Dictionary<int, Node<int>> nodes = new Dictionary<int, Node<int>>();
        foreach (var line in lines)
        {
            string[] attributes = line.Split(new string[] {" ", ", ", "{", "}" },
                StringSplitOptions.RemoveEmptyEntries);

            int parentValue = int.Parse(attributes[0]);
            if (!nodes.ContainsKey(parentValue))
            {
                nodes[parentValue] = new Node<int>(parentValue);
            }

            for (int i = 1; i < attributes.Length; i++)
            {
                int childValue = int.Parse(attributes[i]);
                if (nodes.ContainsKey(childValue))
                {
                    nodes[parentValue].AddChild(nodes[childValue]);
                }
                else
                {
                    Node<int> childNode = new Node<int>(childValue);
                    nodes[parentValue].AddChild(childNode);
                    nodes[childValue] = childNode;
                }
            }
        }

        return nodes;
    }

    private static Node<int> GetRoot(List<Node<int>> nodes)
    {
        foreach (var child in nodes)
        {
            if (child.Children.Count > 0 && !child.HasParent)
            {
                return child;
            }
        }

        throw new ArgumentException("No root found.");
    }

    private static void SavePath(Node<int> currentNode, HashSet<Node<int>> visitedNodes, List<int> path)
    {
        if (visitedNodes.Contains(currentNode))
        {
            return;
        }

        path.Add(currentNode.Value);
        visitedNodes.Add(currentNode);
        foreach (var child in currentNode.Children)
        {
            if (!visitedNodes.Contains(child))
            {
                SavePath(child, visitedNodes, path);
            }
        }
    }

    private static void PrintPath(List<int> path)
    {
        int index = 0;
        foreach (var node in path)
        {
            if (index == path.Count - 1)
            {
                Console.WriteLine(node);
            }
            else
            {
                Console.Write(node + " -> ");
            }

            index++;
        }
    }

    public static void Main()
    {
        List<string> lines = SaveLines();
        Dictionary<int, Node<int>> valueNodes = SaveNodes(lines);
        List<Node<int>> nodes = valueNodes.Values.ToList();
        Node<int> root = GetRoot(nodes);
        List<int> path = new List<int>();
        SavePath(root, new HashSet<Node<int>>(), path);
        PrintPath(path);
    }
}

