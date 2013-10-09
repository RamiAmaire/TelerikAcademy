using System;
using System.Collections.Generic;
using System.Text;

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
