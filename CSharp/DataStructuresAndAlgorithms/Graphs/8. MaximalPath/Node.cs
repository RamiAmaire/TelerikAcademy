//using System;
//using System.Collections.Generic;
//using System.Text;

//public class Node<T> : IComparable
//{
//    public Node(long value)
//    {
//        this.Value = value;
//        this.Connections = new List<Connection<T>>();
//    }

//    public long Value { get; set; }
//    public List<Connection<T>> Connections { get; set; }
//    public Node<T> Parent { get; set; }

//    public void AddConnection(Node<T> toNode)
//    {
//        this.Connections.Add(new Connection<T>(this, toNode));
//        toNode.Parent = this;
//    }

//    public int CompareTo(object obj)
//    {
//        Node<T> other = obj as Node<T>;
//        if (this.Value == other.Value)
//        {
//            return 0;
//        }
//        else
//        {
//            return this.Value.CompareTo(other.Value);
//        }
//    }

//    public override int GetHashCode()
//    {
//        int prime = 17;
//        int result = 1;
//        unchecked
//        {
//            result = result * prime + this.Value.GetHashCode();
//            result = result * prime + this.Connections.GetHashCode();
//        }

//        return result;
//    }

//    public override string ToString()
//    {
//        StringBuilder result = new StringBuilder();
//        result.Append(this.Value);

//        if (this.Connections.Count > 0)
//        {
//            result.Append("; {");
//            int index = 0;
//            foreach (var connection in this.Connections)
//            {
//                if (index == this.Connections.Count - 1)
//                {
//                    result.Append(connection.ToString() + "}");
//                }
//                else
//                {
//                    result.Append(connection.ToString() + ", ");
//                }

//                index++;
//            }
//        }

//        return result.ToString();
//    }
//}
