using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

public class Demo
{
    private static void SaveWantedNodes()
    {
        int wantedNodesNumber = int.Parse(Console.ReadLine());
        for (int i = 0; i < wantedNodesNumber; i++)
        {
            wantedNodes.Add(Console.ReadLine());
        }
    }

    private static void SaveNodes(Dictionary<string, Node> nodes)
    {
        int numberOfConnections = int.Parse(Console.ReadLine());
        for (int i = 0; i < numberOfConnections; i++)
        {
            string[] connectionAttribs = Console.ReadLine().Split(' ');
            string from = connectionAttribs[0];
            if (!nodes.ContainsKey(from))
            {
                nodes[from] = new Node(from);
            }

            string to = connectionAttribs[1];
            if (nodes.ContainsKey(to))
            {
                nodes[from].AddConnection(nodes[to]);
                nodes[to].AddConnection(nodes[from]);
            }
            else
            {
                nodes[to] = new Node(to);
                nodes[from].AddConnection(nodes[to]);
                nodes[to].AddConnection(nodes[from]);
            }
        }
    }

    private static void BFS(Node startingNode)
    {
        Queue<Node> outerQue = new Queue<Node>();
        HashSet<string> visitedNodes = new HashSet<string>();
        outerQue.Enqueue(startingNode);
        int level = 0;

        while (outerQue.Count > 0)
        {
            Queue<Node> innerQue = new Queue<Node>();
            level++;
            if (level == 4)
            {
                break;
            }

            while (outerQue.Count > 0)
            {
                Node currentNode = outerQue.Dequeue();
                visitedNodes.Add(currentNode.Symbol);

                foreach (var connection in currentNode.Connections)
                {
                    Node node = connection.Value.ToNode;
                    if (!visitedNodes.Contains(node.Symbol))
                    {
                        node.Value = level;
                        visitedNodes.Add(node.Symbol);
                        innerQue.Enqueue(node);
                    }
                }
            }

            outerQue = innerQue;
        }
    }

    static Dictionary<string, Node> nodes = new Dictionary<string, Node>();
    static HashSet<string> wantedNodes = new HashSet<string>();

    public static void Main()
    {
        Node startingNode = new Node(Console.ReadLine());
        nodes[startingNode.Symbol] = startingNode;
        SaveNodes(nodes);
        SaveWantedNodes();
        BFS(startingNode);

        foreach (var wantedNode in wantedNodes)
        {
            if (nodes.ContainsKey(wantedNode))
            {
                Console.WriteLine(nodes[wantedNode].Value);
            }
            else
            {
                Console.WriteLine(-1);
            }
        }
    }
}

class Node
{
    public string Symbol { get; set; }
    public int Value { get; set; }
    public Dictionary<string, Connection> Connections { get; set; }

    public Node(string symbol)
    {
        this.Symbol = symbol;
        this.Connections = new Dictionary<string, Connection>();
        this.Value = -1;
    }

    public void AddConnection(Node toNode)
    {
        this.Connections.Add(toNode.Symbol, new Connection(this, toNode));
    }

    public override int GetHashCode()
    {
        int prime = 17;
        int result = 1;
        unchecked
        {
            result = result * prime + this.Symbol.GetHashCode();
            result = result * prime + this.Connections.GetHashCode();
        }

        return result;
    }

    public override string ToString()
    {
        StringBuilder result = new StringBuilder();
        result.Append(this.Symbol + "; " + this.Value);

        if (this.Connections.Count > 0)
        {
            result.Append("; {");
            int index = 0;
            foreach (var connection in this.Connections)
            {
                if (index == this.Connections.Count - 1)
                {
                    result.Append(connection.ToString() + "}");
                }
                else
                {
                    result.Append(connection.ToString() + ", ");
                }

                index++;
            }
        }

        return result.ToString();
    }
}

struct Connection
{
    public Node FromNode { get; set; }
    public Node ToNode { get; set; }

    public Connection(Node fromNode, Node toNode)
        :this()
    {
        this.FromNode = fromNode;
        this.ToNode = toNode;
    }

    public override int GetHashCode()
    {
        int prime = 17;
        int result = 1;
        unchecked
        {
            result = result * prime + this.FromNode.GetHashCode();
            result = result * prime + this.ToNode.GetHashCode();
        }

        return result;
    }

    public override string ToString()
    {
        string result = this.FromNode.Symbol + " -> " + this.ToNode.Symbol;
        return result;
    }
}


