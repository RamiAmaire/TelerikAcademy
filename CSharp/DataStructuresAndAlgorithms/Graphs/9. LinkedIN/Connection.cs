//using System;

//public class Connection<T>
//{
//    public Connection(Node<T> fromNode, Node<T> toNode)
//    {
//        this.FromNode = fromNode;
//        this.ToNode = toNode;
//    }

//    public Node<T> FromNode { get; set; }
//    public Node<T> ToNode { get; set; }

//    public override int GetHashCode()
//    {
//        int prime = 17;
//        int result = 1;
//        unchecked
//        {
//            result = result * prime + this.FromNode.GetHashCode();
//            result = result * prime + this.ToNode.GetHashCode();
//        }

//        return result;
//    }

//    public override string ToString()
//    {
//        string result = this.FromNode.Symbol + " -> " + this.ToNode.Symbol;
//        return result;
//    }
//}