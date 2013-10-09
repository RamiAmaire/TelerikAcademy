using System;
using System.Collections.Generic;

public class Demo
{
    private static void DijkstraAlgorithm(Dictionary<int, Node> graph , Node source)
    {
        PriorityQueue<Node> queue = new PriorityQueue<Node>();

        foreach (var node in graph)
        {
            if (source.Symbol != node.Value.Symbol)
            {
                node.Value.Weight = double.PositiveInfinity;
                queue.Enqueue(node.Value);
            }
        }

        source.Weight = 0.0d;
        queue.Enqueue(source);

        while (queue.Count != 0)
        {
            Node currentNode = queue.Peek();

            if (currentNode.Weight == double.PositiveInfinity)
            {
                break;
            }

            foreach (var connection in graph[currentNode.Symbol].Connections)
            {
                double potDistance = currentNode.Weight + connection.Distance;

                if (potDistance < connection.Node.Weight)
                {
                    connection.Node.Weight = potDistance;
                }
            }

            queue.Dequeue();
        }
    }

    private static double GetSumOfAllWeights(Dictionary<int, Node> graph, HashSet<int> hospitals)
    {
        double sum = 0;
        foreach (var keyValue in graph)
        {
            if (!hospitals.Contains(keyValue.Value.Symbol))
            {
                sum += keyValue.Value.Weight;
            }
        }

        return sum;
    }

    public static void Main()
    {
        string firstLine = Console.ReadLine();
        string[] attribs = firstLine.Split(' ');
        int linesNumber = int.Parse(attribs[1]);

        HashSet<int> hospitals = new HashSet<int>();
        Dictionary<int, Node> graph = new Dictionary<int, Node>();

        for (int i = 0; i < linesNumber + 1; i++)
        {
            string line = Console.ReadLine();
            if (i == 0)
            {
                string[] hosps = line.Split(' ');
                foreach (var hosp in hosps)
                {
                    hospitals.Add(int.Parse(hosp));
                }        
            }
            else
            {
                string[] houses = line.Split(' ');
                int parentValue = int.Parse(houses[0]);
                if (!graph.ContainsKey(parentValue))
                {
                    graph[parentValue] = new Node(parentValue);
                }

                int childValue = int.Parse(houses[1]);
                double distance = int.Parse(houses[2]);
                if (graph.ContainsKey(childValue))
                {
                    graph[parentValue].AddConnection(graph[childValue], distance);
                    graph[childValue].AddConnection(graph[parentValue], distance);
                }
                else
                {
                    graph[childValue] = new Node(childValue);
                    graph[parentValue].AddConnection(graph[childValue], distance);
                    graph[childValue].AddConnection(graph[parentValue], distance);
                }
            }
        }

        double minSum = double.PositiveInfinity;
        foreach (var keyValue in graph)
        {
            if (hospitals.Contains(keyValue.Value.Symbol))
            {
                DijkstraAlgorithm(graph, keyValue.Value);
                double currentSum = GetSumOfAllWeights(graph, hospitals);
                if (currentSum < minSum)
                {
                    minSum = currentSum;
                }
            }
        }

        Console.WriteLine(minSum);
    }
}

public class Connection
{
    public Node Node { get; set; }
    public double Distance { get; set; }

    public Connection(Node node, double distance)
    {
        this.Node = node;
        this.Distance = distance;
    }
}

public class Node : IComparable
{
    public int Symbol { get; private set; }
    public double Weight { get; set; }
    public List<Connection> Connections { get; set; }

    public Node(int symbol)
    {
        this.Symbol = symbol;
        this.Connections = new List<Connection>();
    }

    public void AddConnection(Node node, double distance)
    {
        this.Connections.Add(new Connection(node, distance));
    }

    public int CompareTo(object obj)
    {
        return this.Weight.CompareTo((obj as Node).Weight);
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

