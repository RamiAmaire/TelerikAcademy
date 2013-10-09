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

    private static OrderedBag<Connection<char>> SaveAllConnectionsSorted(List<Node<char>> nodes)
    {
        OrderedBag<Connection<char>> allConnections = new OrderedBag<Connection<char>>();
        foreach (var node in nodes)
        {
            foreach (var connection in node.Connections)
            {
                allConnections.Add(connection);
            }
        }

        return allConnections;
    }

    public static void Main()
    {
        List<string> lines = SaveLines();
        Dictionary<char, Node<char>> nodes = SaveNodes(lines);
        OrderedBag<Connection<char>> allConnections = SaveAllConnectionsSorted(nodes.Values.ToList());
    }
}

