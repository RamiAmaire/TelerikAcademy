//using System;
//using System.Collections.Generic;
//using System.Text;

//public class Node<T> : IComparable
//{
//    public Node(T symbol)
//    {
//        this.Symbol = symbol;
//        this.Weight = double.PositiveInfinity;
//        this.Connections = new List<Connection<T>>();
//    }

//    public T Symbol { get; set; }
//    public double Weight { get; set; }
//    public List<Connection<T>> Connections { get; set; }

//    public void AddConnection(Node<T> node, int distance)
//    {
//        this.Connections.Add(new Connection<T>(node, this, distance));
//    }

//    public int CompareTo(object obj)
//    {
//        Node<T> other = obj as Node<T>;
//        if (this.Weight == other.Weight)
//        {
//            if ((dynamic)this.Symbol == (dynamic)other.Symbol)
//            {
//                return 0;
//            }
//            else
//            {
//                return this.Symbol.ToString().CompareTo(other.Symbol.ToString());
//            }
//        }
//        else
//        {
//            return this.Weight.CompareTo(other.Weight);
//        }
//    }

//    public override int GetHashCode()
//    {
//        int prime = 17;
//        int result = 1;
//        unchecked
//        {
//            result = result * prime + this.Symbol.GetHashCode();
//            result = result * prime + this.Weight.GetHashCode();
//            result = result * prime + this.Connections.GetHashCode();
//        }

//        return result;
//    }

//    public override string ToString()
//    {
//        StringBuilder result = new StringBuilder();
//        result.Append(this.Symbol + "; " + this.Weight);

//        if (this.Connections.Count > 0)
//        {
//            result.Append("; {");
//            int index = 0;
//            foreach (var connection in this.Connections)
//            {
//                if (index == this.Connections.Count - 1)
//                {
//                    result.Append(connection.toNode.Symbol + "(" + connection.Distance + ")}");
//                }
//                else
//                {
//                    result.Append(connection.toNode.Symbol + "(" + connection.Distance + "), ");
//                }

//                index++;
//            }
//        }

//        return result.ToString();
//    }
//}

