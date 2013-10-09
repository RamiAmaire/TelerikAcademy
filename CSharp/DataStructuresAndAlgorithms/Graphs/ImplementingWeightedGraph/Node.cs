using System;
using System.Collections.Generic;
using System.Text;

public class Node<T> : IComparable
{
    public T Symbol { get; set; }
    public int Weight { get; set; }
    public Dictionary<Node<T>, int> Children { get; set; }

    public Node(T symbol)
    {
        this.Symbol = symbol;
        this.Weight = 0;
        this.Children = new Dictionary<Node<T>, int>();
    }

    public void AddChild(Node<T> child, int distance)
    {
        this.Children[child] = distance;
    }

    public void RemoveChild(Node<T> child)
    {
        this.Children.Remove(child);
    }

    public override string ToString()
    {
        StringBuilder result = new StringBuilder();
        result.Append(this.Symbol + "; " + this.Weight);

        if (this.Children.Count > 0)
        {
            result.Append("; " + "Children{");
            int index = 0;
            foreach (var child in this.Children)
            {
                if (index == this.Children.Count - 1)
                {
                    result.Append(child.Key.Symbol + "(" + child.Value + ")" + "}");
                }
                else
                {
                    result.Append(child.Key.Symbol + "(" + child.Value + ")" + ", ");
                }

                index++;
            }
        }

        return result.ToString();
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
        }

        return result;
    }
}

