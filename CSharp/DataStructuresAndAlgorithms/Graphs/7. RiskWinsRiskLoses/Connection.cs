using System;

public class Connection<T> : IComparable
{
    public Connection(Node<T> fromNode, Node<T> toNode, long distance)
    {
        this.FromNode = fromNode;
        this.ToNode = toNode;
        this.Distance = distance;
    }

    public Node<T> FromNode { get; set; }
    public Node<T> ToNode { get; set; }
    public long Distance { get; set; }

    public int CompareTo(object obj)
    {
        Connection<T> other = obj as Connection<T>;
        if (this.Distance == other.Distance)
        {
            if (this.FromNode == other.FromNode)
            {
                if (this.ToNode == other.ToNode)
                {
                    return 0;
                }
                else
                {
                    return this.ToNode.Value.ToString().CompareTo(other.ToNode.Value.ToString());
                }
            }
            else
            {
                return this.FromNode.Value.ToString().CompareTo(other.FromNode.Value.ToString());
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
            result = result * prime + this.FromNode.GetHashCode();
            result = result * prime + this.ToNode.GetHashCode();
            result = result * prime + this.Distance.GetHashCode();
        }

        return result;
    }

    public override string ToString()
    {
        string result = this.FromNode.Value + " -> " + this.ToNode.Value + "; " + this.Distance;
        return result;
    }
}