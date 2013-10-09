using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

public class Demo
{
    private static Dictionary<long, Node<long>> SaveNodes()
    {
        Dictionary<long, Node<long>> nodes = new Dictionary<long, Node<long>>();
        int numberOfLines = int.Parse(Console.ReadLine());
        for (int i = 0; i < numberOfLines - 1; i++)
        {
            string[] attribs = Console.ReadLine().Split(new string[] { "(", ")", "<-", " " },
                StringSplitOptions.RemoveEmptyEntries);

            long parentValue = long.Parse(attribs[0]);
            if (!nodes.ContainsKey(parentValue))
            {
                nodes[parentValue] = new Node<long>(parentValue);
            }

            long childValue = long.Parse(attribs[1]);
            if (nodes.ContainsKey(childValue))
            {
                nodes[parentValue].AddConnection(nodes[childValue]);
            }
            else
            {
                nodes[childValue] = new Node<long>(childValue);
                nodes[parentValue].AddConnection(nodes[childValue]);
            }
        }

        return nodes;
    }

    private static void DFS(Node<long> currentNode, HashSet<long> visitedNodes, long currentSum)
    {
        visitedNodes.Add(currentNode.Value);
        currentSum += currentNode.Value;
        if (currentNode.Connections.Count == 0 && currentSum > maxSum)
        {
            maxSum = currentSum;   
        }

        foreach (var connection in currentNode.Connections)
        {
            Node<long> toNode = connection.ToNode;
            if (!visitedNodes.Contains(toNode.Value))
            {
                visitedNodes.Add(toNode.Value);
                DFS(toNode, visitedNodes, currentSum);
            }
        }

        if (currentNode.Parent != null)
        {
            if (!visitedNodes.Contains(currentNode.Parent.Value))
            {
                visitedNodes.Add(currentNode.Parent.Value);
                DFS(currentNode.Parent, visitedNodes, currentSum);
            }
        }
    }

    static long maxSum = 0;

    public static void Main()
    {
        Dictionary<long, Node<long>> nodes = SaveNodes();
        foreach (var keyValue in nodes)
        {
            if (keyValue.Value.Connections.Count == 0)
            {
                DFS(keyValue.Value, new HashSet<long>(), 0);
            }
        }

        Console.WriteLine(maxSum);
    }
}

public class Node<T> : IComparable
{
    public Node(long value)
    {
        this.Value = value;
        this.Connections = new List<Connection<T>>();
    }

    public long Value { get; set; }
    public List<Connection<T>> Connections { get; set; }
    public Node<T> Parent { get; set; }

    public void AddConnection(Node<T> toNode)
    {
        this.Connections.Add(new Connection<T>(this, toNode));
        toNode.Parent = this;
    }

    public int CompareTo(object obj)
    {
        Node<T> other = obj as Node<T>;
        if (this.Value == other.Value)
        {
            return 0;
        }
        else
        {
            return this.Value.CompareTo(other.Value);
        }
    }

    public override int GetHashCode()
    {
        int prime = 17;
        int result = 1;
        unchecked
        {
            result = result * prime + this.Value.GetHashCode();
            result = result * prime + this.Connections.GetHashCode();
        }

        return result;
    }

    public override string ToString()
    {
        StringBuilder result = new StringBuilder();
        result.Append(this.Value);

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

public class Connection<T>
{
    public Connection(Node<T> fromNode, Node<T> toNode)
    {
        this.FromNode = fromNode;
        this.ToNode = toNode;
    }

    public Node<T> FromNode { get; set; }
    public Node<T> ToNode { get; set; }

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
        string result = this.FromNode.Value + " -> " + this.ToNode.Value;
        return result;
    }
}

