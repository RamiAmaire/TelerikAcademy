using System;
using System.Collections.Generic;
using System.Text;

public class Node<T>
{
    public T Value { get; set; }
    public bool HasParent { get; set; }
    public List<Node<T>> Children { get; set; }

    public Node(T value)
    {
        this.Value = value;
        this.Children = new List<Node<T>>();
    }

    public void AddChild(Node<T> child)
    {
        child.HasParent = true;
        this.Children.Add(child);
    }

    public void RemoveChild(Node<T> child)
    {
        this.Children.Remove(child);
    }

    public override string ToString()
    {
        StringBuilder result = new StringBuilder();
        result.Append("Value: " + this.Value);

        if (this.Children.Count > 0)
        {
            result.Append("; Children{");
            int index = 0;
            foreach (var child in this.Children)
            {
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

    public override int GetHashCode()
    {
        int prime = 17;
        int result = 1;
        unchecked
        {
            result = result * prime + this.Value.GetHashCode();
        }

        return result;
    }
}

