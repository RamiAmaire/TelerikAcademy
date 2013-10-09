using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

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

    private static Dictionary<int, Node<int>> SaveNodes(List<string> lines)
    {
        Dictionary<int, Node<int>> nodes = new Dictionary<int, Node<int>>();
        foreach (var line in lines)
        {
            string[] attribs = line.Split(new string[] { ",", " ", "->", "{", "}" },
                StringSplitOptions.RemoveEmptyEntries);
            int parentValue = int.Parse(attribs[0]);
            if (!nodes.ContainsKey(parentValue))
            {
                nodes[parentValue] = new Node<int>(parentValue);
            }

            for (int i = 1; i < attribs.Length; i++)
            {
                int childValue = int.Parse(attribs[i]);
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

    private static List<Node<int>> FindAllRoots(List<Node<int>> nodes)
    {
        List<Node<int>> roots = new List<Node<int>>();
        foreach (var node in nodes)
        {
            if (!node.HasParent)
            {
                roots.Add(node);
            }
        }

        return roots;
    }

    private static void DFS(Node<int> currentNode, HashSet<int> visitedNodes, Stack<int> order)
    {
        visitedNodes.Add(currentNode.Value);
        foreach (var child in currentNode.Children)
        {
            if (!visitedNodes.Contains(child.Value))
            {
                DFS(child, visitedNodes, order);
            }
        }

        order.Push(currentNode.Value);
    }

    private static string SaveResult(Stack<int> order)
    {
        StringBuilder result = new StringBuilder();
        while (order.Count > 0)
        {
            result.Append(order.Pop() + " ");
        }

        return result.ToString();
    }

    private static string SortTopologically(List<Node<int>> nodes)
    {
        HashSet<int> visitedNodes = new HashSet<int>();
        Stack<int> order = new Stack<int>();

        foreach (var node in nodes)
        {
            if (!visitedNodes.Contains(node.Value))
            {
                DFS(node, visitedNodes, order);
            }
        }

        return SaveResult(order);
    }

    public static void Main()
    {
        List<string> lines = SaveLines();
        Dictionary<int, Node<int>> nodes = SaveNodes(lines);
        List<Node<int>> roots = FindAllRoots(nodes.Values.ToList());

        string order = SortTopologically(nodes.Values.ToList());
        Console.WriteLine(order);
    }
}
