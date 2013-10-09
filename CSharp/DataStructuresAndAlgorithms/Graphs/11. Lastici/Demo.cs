using System;
using System.Collections.Generic;
using System.Text;

public class Demo
{
    private static Dictionary<int, Node<int>> SaveNodes()
    {
        Dictionary<int, Node<int>> nodes = new Dictionary<int, Node<int>>();
        int numberOfNodes = int.Parse(Console.ReadLine());
        for (int parent = 0; parent < numberOfNodes; parent++)
        {
            if (!nodes.ContainsKey(parent))
            {
                nodes[parent] = new Node<int>(parent);
            }

            string line = Console.ReadLine();
            for (int child = 0; child < line.Length; child++)
            {
                if (line[child] == '1')
                {
                    if (nodes.ContainsKey(child))
                    {
                        nodes[parent].AddChild(child, nodes[child]);
                    }
                    else
                    {
                        nodes[child] = new Node<int>(child);
                        nodes[parent].AddChild(child, nodes[child]);
                    }
                }
            }
        }

        return nodes;
    }

    public static void Main()
    {
        int numberOfTests = int.Parse(Console.ReadLine());
        List<int> result = new List<int>();
        for (int i = 0; i < numberOfTests; i++)
        {
            Dictionary<int, Node<int>> nodes = SaveNodes();
        }
    }
}

public class Node<T>
{
    public T Value { get; set; }
    public Dictionary<int, Node<T>> Children { get; set; }

    public Node(T value)
    {
        this.Value = value;
        this.Children = new Dictionary<int, Node<T>>();
    }

    public void AddChild(int childValue, Node<T> child)
    {
        this.Children.Add(childValue, child);
    }

    public override string ToString()
    {
        StringBuilder result = new StringBuilder();
        result.Append("Value: " + this.Value);
        if (this.Children.Count > 0)
        {
            result.Append("; Children{");
            int index = 0;
            foreach (var keyValue in this.Children)
            {
                Node<T> child = keyValue.Value;
                if (index == this.Children.Count - 1)
                {
                    result.Append(child.Value + "}");
                }
                else
                {
                    result.Append(child.Value + ", ");
                }

                index++;
            }
        }

        return result.ToString();
    }
}
