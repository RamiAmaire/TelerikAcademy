using System;
using System.Collections.Generic;
using System.Text;
using Wintellect.PowerCollections;

public class Demo
{
    private static Dictionary<int, Node<int>> SaveNodes()
    {
        Dictionary<int, Node<int>> nodes = new Dictionary<int, Node<int>>();
        int nodesCount = int.Parse(Console.ReadLine());
        for (int i = 0; i < nodesCount; i++)
        {
            string[] attribs = Console.ReadLine().Split(' ');
            int from = int.Parse(attribs[0]);
            if (!nodes.ContainsKey(from))
            {
                nodes[from] = new Node<int>(from);
            }

            int to = int.Parse(attribs[1]);
            int distance = int.Parse(attribs[2]);
            if (nodes.ContainsKey(to))
            {
                nodes[from].AddConnection(nodes[to], distance);
                nodes[to].AddConnection(nodes[from], distance);
            }
            else
            {
                nodes[to] = new Node<int>(to);
                nodes[from].AddConnection(nodes[to], distance);
                nodes[to].AddConnection(nodes[from], distance);
            }
        }

        return nodes;
    }

    private static void FindMinSpanningTreeSum(Node<int> startingNode, int nodesCount)
    {
        HashSet<int> visitedNodes = new HashSet<int>();
        OrderedSet<Connection<int>> connections = new OrderedSet<Connection<int>>();
        long currentSum = 0;
        visitedNodes.Add(startingNode.Symbol);

        foreach (var connection in startingNode.Connections)
        {
            if (!visitedNodes.Contains(connection.toNode.Symbol))
            {
                connections.Add(connection);
            }
        }

        while (connections.Count > 0)
        {
            Connection<int> currentConnection = connections.GetFirst();
            connections.RemoveFirst();
            Node<int> currentNode = currentConnection.toNode;
            
            if (!visitedNodes.Contains(currentNode.Symbol))
            {
                currentSum += currentConnection.Distance;
            }

            visitedNodes.Add(currentNode.Symbol);
            if (visitedNodes.Count == nodesCount)
            {
                break;
            }

            foreach (var connection in currentNode.Connections)
            {
                if (!visitedNodes.Contains(connection.toNode.Symbol))
                {
                    connections.Add(connection);
                }
            }
        }

        Console.WriteLine(currentSum);
    }

    public static void Main()
    {
        Dictionary<int, Node<int>> nodes = SaveNodes();
        foreach (var node in nodes.Values)
        {
            FindMinSpanningTreeSum(node, nodes.Count);
            break;
        }
    }
}

public class Node<T> : IComparable
{
    public Node(T symbol)
    {
        this.Symbol = symbol;
        this.Connections = new OrderedSet<Connection<T>>();
    }

    public T Symbol { get; set; }
    public OrderedSet<Connection<T>> Connections { get; set; }

    public void AddConnection(Node<T> node, int distance)
    {
        this.Connections.Add(new Connection<T>(node, this, distance));
    }

    public int CompareTo(object obj)
    {
        Node<T> other = obj as Node<T>;

        if ((dynamic)this.Symbol == (dynamic)other.Symbol)
        {
            return 0;
        }
        else
        {
            return this.Symbol.ToString().CompareTo(other.Symbol.ToString());
        }
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
        result.Append(this.Symbol);

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

public class Connection<T> : IComparable
{
    public Connection(Node<T> toNode, Node<T> fromNode, int distance)
    {
        this.toNode = toNode;
        this.fromNode = fromNode;
        this.Distance = distance;
    }

    public Node<T> toNode { get; set; }
    public Node<T> fromNode { get; set; }
    public int Distance { get; set; }

    public int CompareTo(object obj)
    {
        Connection<T> other = obj as Connection<T>;
        if (this.Distance == other.Distance)
        {
            if ((dynamic)this.toNode.Symbol == (dynamic)other.toNode.Symbol)
            {
                if ((dynamic)this.fromNode.Symbol == (dynamic)other.fromNode.Symbol)
                {
                    return 0;
                }
                else
                {
                    return this.fromNode.Symbol.ToString().CompareTo(other.fromNode.Symbol.ToString());
                }
            }
            else
            {
                return this.toNode.Symbol.ToString().CompareTo(other.toNode.Symbol.ToString());
            }
        }
        else
        {
            return this.Distance.CompareTo(other.Distance);
        }
    }

    public override int GetHashCode()
    {
        int prime = 17;
        int result = 1;
        unchecked
        {
            result = result * prime + this.toNode.GetHashCode();
            result = result * prime + this.fromNode.GetHashCode();
            result = result * prime + this.Distance.GetHashCode();
        }

        return result;
    }

    public override string ToString()
    {
        StringBuilder result = new StringBuilder();
        result.Append("(" + this.fromNode.Symbol + " " + this.toNode.Symbol + ")" + " -> " + this.Distance);
        return result.ToString();
    }
}


