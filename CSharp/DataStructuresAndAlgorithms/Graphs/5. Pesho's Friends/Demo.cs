using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Numerics;
using Wintellect.PowerCollections;

public class Demo
{
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
            result.Append(this.fromNode.Symbol + " -> " + this.toNode.Symbol + "; " + this.Distance);
            return result.ToString();
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
            this.Connections.Add(new Connection<T>(node, this, distance));
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

    private static List<string> SaveLines()
    {
        List<string> lines = new List<string>();
        string[] attribs = Console.ReadLine().Split(' ');
        for (int i = 0; i < int.Parse(attribs[1]) + 1; i++)
        {
            lines.Add(Console.ReadLine());
        }

        return lines;
    }

    private static Dictionary<int, Node<int>> SaveNodes(List<string> lines)
    {
        Dictionary<int, Node<int>> nodes = new Dictionary<int, Node<int>>();
        for (int i = 1; i < lines.Count; i++)
        {
            string line = lines[i];
            string[] attribs = line.Split(' ');
            int parentValue = int.Parse(attribs[0]);
            if (!nodes.ContainsKey(parentValue))
            {
                nodes[parentValue] = new Node<int>(parentValue);
            }

            int childValue = int.Parse(attribs[1]);
            int distance = int.Parse(attribs[2]);
            if (nodes.ContainsKey(childValue))
            {
                nodes[parentValue].AddConnection(nodes[childValue], distance);
                nodes[childValue].AddConnection(nodes[parentValue], distance);
            }
            else
            {
                Node<int> childNode = new Node<int>(childValue);
                nodes[parentValue].AddConnection(childNode, distance);
                childNode.AddConnection(nodes[parentValue], distance);
                nodes[childValue] = childNode;
            }
        }

        return nodes;
    }

    private static OrderedBag<int> SaveHospitals(string line)
    {
        OrderedBag<int> hospitals = new OrderedBag<int>();
        string[] hosp = line.Split(' ');
        for (int i = 0; i < hosp.Length; i++)
        {
            hospitals.Add(int.Parse(hosp[i]));
        }
        
        return hospitals;
    }

    static void DijkstraAlgorithm(List<Node<int>> nodes, Node<int> startingNode)
    {
        PriorityQueue<Node<int>> queue = new PriorityQueue<Node<int>>();
        foreach (var node in nodes)
        {
            if (node.Symbol != startingNode.Symbol)
            {
                node.Weight = long.MaxValue;
                queue.Enqueue(node);
            }
            else
            {
                startingNode.Weight = 0;
            }
        }

        queue.Enqueue(startingNode);
        while (queue.Count != 0)
        {
            Node<int> currentNode = queue.Peek();
            foreach (var connection in currentNode.Connections)
            {
                long potDistance = currentNode.Weight + connection.Distance;
                if (potDistance < connection.toNode.Weight)
                {
                    connection.toNode.Weight = potDistance;
                }
            }

            queue.Dequeue();
        }
    }

    private static BigInteger GetSum(List<Node<int>> nodes, OrderedBag<int> hospitals)
    {
        BigInteger sum = 0;
        foreach (var node in nodes)
        {
            if (!hospitals.Contains(node.Symbol))
            {
                sum += node.Weight;
            }
        }

        return sum;
    }

    public static void Main()
    {
        List<string> lines = SaveLines();
        OrderedBag<int> hospitals = SaveHospitals(lines[0]);
        Dictionary<int, Node<int>> graph = SaveNodes(lines);
        List<Node<int>> nodes = graph.Values.ToList();

        BigInteger minSum = long.MaxValue;
        foreach (var node in nodes)
        {
            if (hospitals.Contains(node.Symbol))
            {
                DijkstraAlgorithm(nodes, node);
                BigInteger currentSum = GetSum(nodes, hospitals);
                if (currentSum < minSum)
                {
                    minSum = currentSum;
                }
            }
        }

        Console.WriteLine(minSum);
    }
}




