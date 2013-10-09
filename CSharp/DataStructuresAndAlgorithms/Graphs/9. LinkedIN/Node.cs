//using System;
//using System.Collections.Generic;
//using System.Text;

//public class Node<T>
//{
//    public Node(T symbol)
//    {
//        this.Symbol = symbol;
//        this.Connections = new Dictionary<T, Connection<T>>();
//    }

//    public T Symbol { get; set; }
//    public int Value { get; set; }
//    public Dictionary<T, Connection<T>> Connections { get; set; }

//    public void AddConnection(Node<T> toNode)
//    {
//        this.Connections.Add(toNode.Symbol, new Connection<T>(this, toNode));
//    }

//    public override int GetHashCode()
//    {
//        int prime = 17;
//        int result = 1;
//        unchecked
//        {
//            result = result * prime + this.Symbol.GetHashCode();
//            result = result * prime + this.Connections.GetHashCode();
//        }

//        return result;
//    }

//    public override string ToString()
//    {
//        StringBuilder result = new StringBuilder();
//        result.Append(this.Symbol + "; " + this.Value);

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
