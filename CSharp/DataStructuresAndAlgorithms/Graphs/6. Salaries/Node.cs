//using System;
//using System.Collections.Generic;
//using System.Text;

//public class Node<T>
//{
//    public Node(T symbol)
//    {
//        this.Symbol = symbol;
//        this.Children = new List<Node<T>>();
//    }

//    public long Salary { get; set; }
//    public T Symbol { get; set; }
//    public List<Node<T>> Children { get; set; }

//    public void AddChild(Node<T> child)
//    {
//        this.Children.Add(child);
//    }

//    public override string ToString()
//    {
//        StringBuilder result = new StringBuilder();
//        result.Append(this.Symbol + "; " + this.Salary);

//        if (this.Children.Count > 0)
//        {
//            result.Append("; {");
//            int index = 0;
//            foreach (var child in this.Children)
//            {
//                if (index == this.Children.Count - 1)
//                {
//                    result.Append(child.Symbol + "}");
//                }
//                else
//                {
//                    result.Append(child.Symbol + ", ");
//                }

//                index++;
//            }
//        }

//        return result.ToString();
//    }
//}

