﻿using System;
using System.Collections.Generic;
using System.Text;

public class Node<T>
{
    public T Value { get; set; }
    public List<Node<T>> Children { get; set; }

    public Node(T value)
    {
        this.Value = value;
        this.Children = new List<Node<T>>();
    }

    public void AddChild(Node<T> child)
    {
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
            for (int i = 0; i < this.Children.Count; i++)
            {
                Node<T> child = this.Children[i];
                if (i == this.Children.Count - 1)
                {
                    result.Append(child.Value + "}");
                }
                else
                {
                    result.Append(child.Value + ", ");
                }
            }
        }

        return result.ToString();
    }
}

