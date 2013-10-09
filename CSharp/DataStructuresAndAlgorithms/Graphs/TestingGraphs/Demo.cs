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
                int child = int.Parse(attributes[i]);
                if (nodes.ContainsKey(child))
                {
                    nodes[parentValue].AddChild(nodes[child]);
                }
                else
                {
                    Node<int> childNode = new Node<int>(child);
                    nodes[parentValue].AddChild(childNode);
                    nodes[child] = childNode;
                }
            }
        }

        return nodes;
    }

    private static void TraverseNodesDFS(Node<int> node, HashSet<int> visitedNodes)
    {
        Queue<Node<int>> nodesQueue = new Queue<Node<int>>();
        nodesQueue.Enqueue(node);
        string nodesPath = string.Empty;

        while (nodesQueue.Count > 0)
        {
            Node<int> currentNode = nodesQueue.Dequeue();
            visitedNodes.Add(currentNode.Value);
            nodesPath +=  ", " + currentNode.Value;

            foreach (var child in currentNode.Children)
            {
                if (!visitedNodes.Contains(child.Value))
                {
                    nodesQueue.Enqueue(child);
                    visitedNodes.Add(child.Value);
                }
            }
        }

        Console.WriteLine(nodesPath.Substring(2));
    }

    public static void Main()
    {
        List<string> lines = SaveLines();
        Dictionary<int, Node<int>> nodes = SaveNodes(lines);

        HashSet<int> visitedNodes = new HashSet<int>();

        foreach (var node in nodes)
        {
            if (!visitedNodes.Contains(node.Key))
            {
                TraverseNodesDFS(node.Value, visitedNodes);
            }
        }
    }
}
