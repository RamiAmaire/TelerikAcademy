using System;
using System.Collections.Generic;
using System.Text;

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

public class Node<T> : IComparable
{
    public Node(T symbol)
    {
        this.Symbol = symbol;
        this.Connections = new List<Connection<T>>();
    }

    public T Symbol { get; set; }
    public long Weight { get; set; }
    public List<Connection<T>> Connections { get; set; }

    public void AddConnection(Node<T> node, int distance)
    {
        this.Connections.Add(new Connection<T>(node, distance));
    }

    public int CompareTo(object obj)
    {
        Node<T> other = obj as Node<T>;
        if (this.Weight == other.Weight)
        {
            if ((dynamic)this.Symbol == (dynamic)other.Symbol)
            {
                return 0;
            }
            else
            {
                return this.Symbol.ToString().CompareTo(other.Symbol.ToString());
            }
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
            result = result * prime + this.Symbol.GetHashCode();
            result = result * prime + this.Weight.GetHashCode();
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
    public Connection(Node<T> toNode, int distance)
    {
        this.toNode = toNode;
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
        result.Append(this.fromNode.Symbol + " -> " + this.toNode.Symbol + "; " + this.Distance);
        return result.ToString();
    }
}

public class Test
{
    public static void Main()
    {
        Dictionary<Node<int>, List<Connection<int>>> graph = new Dictionary<Node<int>, List<Connection<int>>>();
        string[] initialParams = Console.ReadLine().Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);

        int numberOfNodes = int.Parse(initialParams[0]);
        int numberOfStreets = int.Parse(initialParams[1]);
        int numberOfHospitals = int.Parse(initialParams[2]);

        string[] hostitalParams = Console.ReadLine().Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
        List<int> hospitalNumbers = new List<int>();
        for (int i = 0; i < hostitalParams.Length; i++)
        {
            hospitalNumbers[i] = int.Parse(hostitalParams[i]);
        }

        Dictionary<int, Node<int>> nodes = new Dictionary<int, Node<int>>();
        List<int[]> allParams = new List<int[]>();

        for (int i = 0; i < numberOfStreets; i++)
        {
            string[] currentParams = Console.ReadLine().Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
            int[] currentNumbers = new int[currentParams.Length];

            for (int j = 0; j < currentParams.Length; j++)
            {
                currentNumbers[j] = int.Parse(currentParams[j]);
            }

            allParams.Add(currentNumbers);

            if (!nodes.ContainsKey(currentNumbers[0]))
            {
                nodes.Add(currentNumbers[0], new Node<int>(currentNumbers[0]));
            }

            if (!nodes.ContainsKey(currentNumbers[1]))
            {
                nodes.Add(currentNumbers[1], new Node<int>(currentNumbers[1]));
            }
        }

        for (int i = 0; i < allParams.Count; i++)
        {
            int[] currentParams = allParams[i];

            if (graph.ContainsKey(nodes[currentParams[0]]))
            {
                graph[nodes[currentParams[0]]].Add(new Connection<int>(nodes[currentParams[1]], currentParams[2]));
            }
            else
            {
                graph.Add(nodes[currentParams[0]], new List<Connection<int>>() { new Connection<int>(nodes[currentParams[1]], currentParams[2]) });
            }

            if (graph.ContainsKey(nodes[currentParams[1]]))
            {
                graph[nodes[currentParams[1]]].Add(new Connection<int>(nodes[currentParams[0]], currentParams[2]));
            }
            else
            {
                graph.Add(nodes[currentParams[1]], new List<Connection<int>>() { new Connection<int>(nodes[currentParams[0]], currentParams[2]) });
            }
        }

        double bestSum = double.MaxValue;

        for (int i = 0; i < hospitalNumbers.Count; i++)
        {
            DijkstraAlgorithm(nodes[hospitalNumbers[i]], graph);

            double sum = 0;

            foreach (var item in graph)
            {
                if (!hospitalNumbers.Contains(item.Key.Symbol))
                {
                    sum += item.Key.Weight;
                }
            }

            if (sum < bestSum)
            {
                bestSum = sum;
            }
        }

        Console.WriteLine(bestSum);
    }

    public static void DijkstraAlgorithm(Node<int> source, Dictionary<Node<int>, List<Connection<int>>> graph)
    {
        PriorityQueue<Node<int>> queue = new PriorityQueue<Node<int>>();

        foreach (var node in graph)
        {
            if (source.Symbol != node.Key.Symbol)
            {
                node.Key.Weight = int.MaxValue;
                queue.Enqueue(node.Key);
            }
        }

        source.Weight = 0;
        queue.Enqueue(source);

        while (queue.Count != 0)
        {
            Node<int> currentNode = queue.Peek();

            if (currentNode.Weight == int.MaxValue)
            {
                break;
            }

            foreach (var neighbour in graph[currentNode])
            {
                long potDistance = currentNode.Weight + neighbour.Distance;

                if (potDistance < neighbour.toNode.Weight)
                {
                    neighbour.toNode.Weight = potDistance;
                    Node<int> next = new Node<int>(neighbour.toNode.Symbol);
                    queue.Enqueue(next);
                }
            }

            queue.Dequeue();
        }
    }
}

