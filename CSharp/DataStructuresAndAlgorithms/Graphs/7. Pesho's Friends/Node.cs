//using System;
//using System.Collections.Generic;

//public class Node : IComparable
//{
//    public int Symbol { get; private set; }
//    public double Weight { get; set; }
//    public List<Connection> Connections { get; set; }

//    public Node(int symbol)
//    {
//        this.Symbol = symbol;
//        this.Connections = new List<Connection>();
//    }

//    public void AddConnection(Node node, double distance)
//    {
//        this.Connections.Add(new Connection(node, distance));
//    }

//    public int CompareTo(object obj)
//    {
//        return this.Weight.CompareTo((obj as Node).Weight);
//    }
//}

