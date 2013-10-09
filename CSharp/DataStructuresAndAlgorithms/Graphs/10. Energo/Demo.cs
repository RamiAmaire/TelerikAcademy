using System;
using System.Collections.Generic;
using System.Text;
using Wintellect.PowerCollections;

public class Demo
{
    private static Dictionary<int, Node<int>> SaveNodes()
    {
        Dictionary<int, Node<int>> nodes = new Dictionary<int, Node<int>>();
        int NodesCount = int.Parse(Console.ReadLine());
        for (int i = 0; i < NodesCount; i++)
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
            }
            else
            {
                nodes[to] = new Node<int>(to);
                nodes[from].AddConnection(nodes[to], distance);
            }
        }

        return nodes;
    }

    private static long FindMinimumSpanningTree(Node<int> startingNode, int nodesCount)
    {
        PriorityQueue<Connection<int>> que = new PriorityQueue<Connection<int>>();
        foreach (var connection in startingNode.Connections)
        {
            que.Enqueue(connection);
        }

        HashSet<int> visitedNodes = new HashSet<int>();
        visitedNodes.Add(startingNode.Symbol);
        long sum = 0;
        while (que.Count > 0)
        {
            Connection<int> currentConnection = que.Dequeue();
            Node<int> currentNode = currentConnection.toNode;
            if (!visitedNodes.Contains(currentNode.Symbol))
            {
                sum += currentConnection.Distance;
                visitedNodes.Add(currentNode.Symbol);
                if (visitedNodes.Count == nodesCount)
                {
                    break;
                }

                foreach (var connection in currentNode.Connections)
                {
                    if (!visitedNodes.Contains(connection.toNode.Symbol))
                    {
                        que.Enqueue(connection);
                    }
                }
            }
        }

        return sum;
    }

    public static void Main()
    {
        Dictionary<int, Node<int>> nodes = SaveNodes();
        foreach (var node in nodes.Values)
        {
            long sum = FindMinimumSpanningTree(node, nodes.Values.Count);
            Console.WriteLine(sum);
            break;
        }
    }
}

public class Node<T> : IComparable
{
    public Node(T symbol)
    {
        this.Symbol = symbol;
        this.Connections = new OrderedBag<Connection<T>>();
    }

    public T Symbol { get; set; }
    public OrderedBag<Connection<T>> Connections { get; set; }

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
                    result.Append(connection.toNode.Symbol + "(" + connection.Distance + ")}");
                }
                else
                {
                    result.Append(connection.toNode.Symbol + "(" + connection.Distance + "), ");
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
        result.Append(this.fromNode.Symbol + "" + this.toNode.Symbol + "; " + this.Distance);
        return result.ToString();
    }
}

public class PriorityQueue<T> where T : IComparable
{
    private T[] heap;
    private int index;

    public int Count
    {
        get
        {
            return this.index - 1;
        }
    }

    public PriorityQueue()
    {
        this.heap = new T[16];
        this.index = 1;
    }

    public void Enqueue(T element)
    {
        if (this.index >= this.heap.Length)
        {
            IncreaseArray();
        }

        this.heap[this.index] = element;

        int childIndex = this.index;
        int parentIndex = childIndex / 2;
        this.index++;

        while (parentIndex >= 1 && this.heap[childIndex].CompareTo(this.heap[parentIndex]) < 0)
        {
            T swapValue = this.heap[parentIndex];
            this.heap[parentIndex] = this.heap[childIndex];
            this.heap[childIndex] = swapValue;

            childIndex = parentIndex;
            parentIndex = childIndex / 2;
        }
    }

    public T Dequeue()
    {
        T result = this.heap[1];

        this.heap[1] = this.heap[this.Count];
        this.index--;

        int rootIndex = 1;

        int minChild;

        while (true)
        {
            int leftChildIndex = rootIndex * 2;
            int rightChildIndex = rootIndex * 2 + 1;

            if (leftChildIndex > this.index)
            {
                break;
            }
            else if (rightChildIndex > this.index)
            {
                minChild = leftChildIndex;
            }
            else
            {
                if (this.heap[leftChildIndex].CompareTo(this.heap[rightChildIndex]) < 0)
                {
                    minChild = leftChildIndex;
                }
                else
                {
                    minChild = rightChildIndex;
                }
            }

            if (this.heap[minChild].CompareTo(this.heap[rootIndex]) < 0)
            {
                T swapValue = this.heap[rootIndex];
                this.heap[rootIndex] = this.heap[minChild];
                this.heap[minChild] = swapValue;

                rootIndex = minChild;
            }
            else
            {
                break;
            }
        }

        return result;
    }

    public T Peek()
    {
        return this.heap[1];
    }

    private void IncreaseArray()
    {
        T[] copiedHeap = new T[this.heap.Length * 2];

        for (int i = 0; i < this.heap.Length; i++)
        {
            copiedHeap[i] = this.heap[i];
        }

        this.heap = copiedHeap;
    }
}

