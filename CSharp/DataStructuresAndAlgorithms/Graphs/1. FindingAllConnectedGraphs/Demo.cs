using System;
using System.Collections.Generic;

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
            string[] attributes = line.Split(new string[] {" ", ",", "{", "}", "->" },
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

    private static void SaveAllConncectedComponents(Node<int> node,
        HashSet<int> visitedNodes, List<string> connectedComponents)
    {
        string graphs = string.Empty;
        Stack<Node<int>> nodesStack = new Stack<Node<int>>();
        nodesStack.Push(node);

        while (nodesStack.Count > 0)
        {
            Node<int> currentNode = nodesStack.Pop();
            visitedNodes.Add(currentNode.Value);
            graphs += " -> " + currentNode.Value;

            foreach (var child in currentNode.Children)
            {
                if (!visitedNodes.Contains(child.Value))
                {
                    visitedNodes.Add(child.Value);
                    nodesStack.Push(child);
                }
            }
        }

        connectedComponents.Add(graphs.Substring(4));
    }

    private static void PrintAllConnectedComponents(List<string> connectedComponents)
    {
        int index = 1;
        foreach (var component in connectedComponents)
        {
            Console.WriteLine(index + ". " + component);
            index++;
        }
    }

    public static void Main()
    {
        List<string> lines = SaveLines();
        Dictionary<int, Node<int>> nodes = SaveNodes(lines);

        HashSet<int> visitedNodes = new HashSet<int>();
        List<string> connectedComponents = new List<string>();

        foreach (var node in nodes)
        {
            if (!visitedNodes.Contains(node.Key))
            {
                SaveAllConncectedComponents(node.Value, visitedNodes, connectedComponents);
            }
        }

        PrintAllConnectedComponents(connectedComponents);
    }
}

