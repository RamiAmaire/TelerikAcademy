using System;
using System.Collections.Generic;
using System.Text;

public class Node<T>
{
    public Node(T symbol)
    {
        this.Symbol = symbol;
        this.Children = new List<Node<T>>();
    }

    public long Salary { get; set; }
    public T Symbol { get; set; }
    public List<Node<T>> Children { get; set; }

    public void AddChild(Node<T> child)
    {
        this.Children.Add(child);
    }

    public override string ToString()
    {
        StringBuilder result = new StringBuilder();
        result.Append(this.Symbol + "; " + this.Salary);

        if (this.Children.Count > 0)
        {
            result.Append("; {");
            int index = 0;
            foreach (var child in this.Children)
            {
                if (index == this.Children.Count - 1)
                {
                    result.Append(child.Symbol + "}");
                }
                else
                {
                    result.Append(child.Symbol + ", ");
                }

                index++;
            }
        }

        return result.ToString();
    }
}

public class Demo
{
    private static Dictionary<int, Node<int>> SaveNodes()
    {
        int numberOfNodes = int.Parse(Console.ReadLine());
        Dictionary<int, Node<int>> tree = new Dictionary<int, Node<int>>();

        for (int i = 0; i < numberOfNodes; i++)
        {
            if (!tree.ContainsKey(i))
            {
                tree[i] = new Node<int>(i);
            }

            string line = Console.ReadLine();
            for (int j = 0; j < line.Length; j++)
            {
                if (line[j] == 'Y')
                {
                    if (tree.ContainsKey(j))
                    {
                        tree[i].AddChild(tree[j]);
                    }
                    else
                    {
                        tree[j] = new Node<int>(j);
                        tree[i].AddChild(tree[j]);
                    }
                }
            }
        }

        return tree;
    }

    private static long GetSumOfSalaries(Node<int> currentNode, Dictionary<int, long> savedSalaries) 
    {
        if (currentNode.Children.Count == 0)
        {
            savedSalaries.Add(currentNode.Symbol, 1);
            return currentNode.Salary = 1;
        }
        else
        {
            foreach (var child in currentNode.Children)
            {
                if (savedSalaries.ContainsKey(child.Symbol))
                {
                    currentNode.Salary += savedSalaries[child.Symbol];
                }
                else
                {
                    currentNode.Salary += GetSumOfSalaries(child, savedSalaries);
                }
            }

            savedSalaries.Add(currentNode.Symbol, currentNode.Salary);
            return currentNode.Salary;
        }
    }

    public static void Main()
    {
        Dictionary<int, Node<int>> tree = SaveNodes();
        Dictionary<int, long> savedSalaries = new Dictionary<int, long>();
        long sum = 0;

        foreach (var node in tree.Values)
        {
            if (savedSalaries.ContainsKey(node.Symbol))
            {
                sum += savedSalaries[node.Symbol];
            }
            else
            {
                sum += GetSumOfSalaries(node, savedSalaries);
            }
        }

        Console.WriteLine(sum);
    }
}
