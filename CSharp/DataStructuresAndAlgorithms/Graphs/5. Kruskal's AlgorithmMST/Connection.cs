using System;
using System.Text;

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
        result.Append(this.fromNode.Symbol + "" + this.toNode.Symbol + "; " + this.Distance);
        return result.ToString();
    }
}

