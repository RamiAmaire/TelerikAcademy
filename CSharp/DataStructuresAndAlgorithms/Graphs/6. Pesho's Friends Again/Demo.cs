using System;
using System.Collections.Generic;
using System.Numerics;
using System.Text;
using System.Linq;
using Wintellect.PowerCollections;

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

public class Connection<T> : IComparable
{
    public Connection(Node<T> fromNode, Node<T> toNode, long distance)
    {
        this.FromNode = fromNode;
        this.ToNode = toNode;
        this.Distance = distance;
    }

    public Node<T> FromNode { get; set; }
    public Node<T> ToNode { get; set; }
    public long Distance { get; set; }

    public int CompareTo(object obj)
    {
        Connection<T> other = obj as Connection<T>;
        if (this.Distance == other.Distance)
        {
            if (this.FromNode == other.FromNode)
            {
                if (this.ToNode == other.ToNode)
                {
                    return 0;
                }
                else
                {
                    return this.ToNode.Symbol.ToString().CompareTo(other.ToNode.Symbol.ToString());
                }
            }
            else
            {
                return this.FromNode.Symbol.ToString().CompareTo(other.FromNode.Symbol.ToString());
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
            result = result * prime + this.FromNode.GetHashCode();
            result = result * prime + this.ToNode.GetHashCode();
            result = result * prime + this.Distance.GetHashCode();
        }

        return result;
    }

    public override string ToString()
    {
        string result = this.FromNode.Symbol + " -> " + this.ToNode.Symbol + "; " + this.Distance;
        return result;
    }
}

public class Node<T> : IComparable
{
    public Node(T symbol)
    {
        this.Symbol = symbol;
        this.Connections = new List<Connection<T>>();
    }

    public long Weight { get; set; }
    public T Symbol { get; set; }
    public List<Connection<T>> Connections { get; set; }
    public bool IsHospital { get; set; }

    public void AddConnection(Node<T> toNode, long distance)
    {
        this.Connections.Add(new Connection<T>(this, toNode, distance));
    }

    public int CompareTo(object obj)
    {
        Node<T> other = obj as Node<T>;
        if (this.Weight == other.Weight)
        {
            return 0;
        }
        else
        {
            return this.Weight.CompareTo(other.Weight);
        }
    }

    public override int GetHashCode()
    {
        int prime = 17;
        int result = 1;
        unchecked
        {
            result = result * prime + this.Weight.GetHashCode();
            result = result * prime + this.Symbol.GetHashCode();
            result = result * prime + this.Connections.GetHashCode();
        }

        return result;
    }

    public override string ToString()
    {
        StringBuilder result = new StringBuilder();
        result.Append(this.Symbol + "; " + this.Weight);

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

public class Demo
{
    private static void DijkstraAlgorithm(Node<int> startingNode, HashSet<int> visitedNodes)
    {
        PriorityQueue<Node<int>> queue = new PriorityQueue<Node<int>>();
        queue.Enqueue(startingNode);

        while (queue.Count > 0)
        {
            Node<int> currentNode = queue.Dequeue();
            visitedNodes.Add(currentNode.Symbol);
            foreach (var connection in currentNode.Connections)
            {
                Node<int> childNode = connection.ToNode;
                if (!visitedNodes.Contains(childNode.Symbol))
                {
                    long temporaryWeight = currentNode.Weight + connection.Distance;
                    if (temporaryWeight < childNode.Weight)
                    {
                        childNode.Weight = temporaryWeight;
                        queue.Enqueue(childNode);
                    }
                }
            }
        }
    }

    private static long GetSumOfAllWeights(Dictionary<int, Node<int>> graph)
    {
        long sum = 0;
        foreach (var node in graph.Values)
        {
            if (!node.IsHospital)
            {
                sum += node.Weight;
            }
        }

        return sum;
    }

    private static void ResetWeights(Dictionary<int, Node<int>> graph, Node<int> startingNode)
    {
        foreach (var node in graph.Values)
        {
            if (node.Symbol != startingNode.Symbol)
            {
                node.Weight = long.MaxValue;
            }
        }

        startingNode.Weight = 0;
    }

    private static Dictionary<int, Node<int>> SaveNodes()
    {
        Dictionary<int, Node<int>> graph = new Dictionary<int, Node<int>>();
        string[] attribs = Console.ReadLine().Split(' ');
        int numberOfLines = int.Parse(attribs[1]);

        for (int i = 0; i < numberOfLines + 1; i++)
        {
            if (i == 0)
            {
                string[] hosps = Console.ReadLine().Split(' ');
                for (int j = 0; j < hosps.Length; j++)
                {
                    int hospValue = int.Parse(hosps[j]);
                    graph[hospValue] = new Node<int>(hospValue);
                    graph[hospValue].IsHospital = true;
                }
            }
            else
            {
                string[] atr = Console.ReadLine().Split(' ');
                int parentValue = int.Parse(atr[0]);
                if (!graph.ContainsKey(parentValue))
                {
                    graph[parentValue] = new Node<int>(parentValue);
                }

                int childValue = int.Parse(atr[1]);
                int distance = int.Parse(atr[2]);
                if (graph.ContainsKey(childValue))
                {
                    graph[parentValue].AddConnection(graph[childValue], distance);
                    graph[childValue].AddConnection(graph[parentValue], distance);
                }
                else
                {
                    graph[childValue] = new Node<int>(childValue);
                    graph[parentValue].AddConnection(graph[childValue], distance);
                    graph[childValue].AddConnection(graph[parentValue], distance);
                }
            }
        }

        return graph;
    }

    public static void Main()
    {
        Dictionary<int, Node<int>> graph = SaveNodes();

        long minSum = long.MaxValue;
        foreach (var node in graph.Values)
        {
            if (node.IsHospital)
            {
                ResetWeights(graph, node);
                DijkstraAlgorithm(node, new HashSet<int>());
                long currentSum = GetSumOfAllWeights(graph);
                if (currentSum < minSum)
                {
                    minSum = currentSum;
                }
            }
        }

        Console.WriteLine(minSum);
    }
}
