//using System;
//using System.Collections.Generic;
//using System.Text;

//public class Node<T>
//{
//    public T Value { get; set; }
//    public Dictionary<int, Node<T>> Children { get; set; }

//    public Node(T value)
//    {
//        this.Value = value;
//        this.Children = new Dictionary<int, Node<T>>();
//    }

//    public void AddChild(int childValue, Node<T> child)
//    {
//        this.Children.Add(childValue, child);
//    }

//    public override string ToString()
//    {
//        StringBuilder result = new StringBuilder();
//        result.Append("Value: " + this.Value);
//        if (this.Children.Count > 0)
//        {
//            result.Append("; Children{");
//            int index = 0;
//            foreach (var keyValue in this.Children)
//            {
//                Node<T> child = keyValue.Value;
//                if (index == this.Children.Count - 1)
//                {
//                    result.Append(child.Value + "}");
//                }
//                else
//                {
//                    result.Append(child.Value + ", ");
//                }

//                index++;
//            }
//        }

//        return result.ToString();
//    }
//}

