namespace TreeOperations
{
    using System;
    using System.Collections.Generic;

    public class Demo
    {
        private static TreeNode<int>[] SaveNodes(int n)
        {
            TreeNode<int>[] nodes = new TreeNode<int>[n];
            for (int i = 0; i < n; i++)
            {
                nodes[i] = new TreeNode<int>(i);
            }

            return nodes;
        }

        private static void GenNodesConnections(int n, TreeNode<int>[] nodes)
        {
            for (int i = 0; i < n - 1; i++)
            {
                string line = Console.ReadLine();
                string[] parentAndChildValue = line.Split(' ');

                TreeNode<int> parent = nodes[int.Parse(parentAndChildValue[0])];
                TreeNode<int> child = nodes[int.Parse(parentAndChildValue[1])];
                parent.AddChild(child);
            }
        }

        private static void Print(List<TreeNode<int>> list, string message)
        {
            Console.WriteLine(message);

            for (int i = 0; i < list.Count; i++)
            {
                if (i == list.Count - 1)
                {
                    Console.WriteLine(list[i].Value);
                }
                else
                {
                    Console.Write(list[i].Value + ", ");
                }
            }
        }

        public static void Main()
        {
            int N = int.Parse(Console.ReadLine());
            TreeNode<int>[] nodes = SaveNodes(N);
            GenNodesConnections(N, nodes);

            Tree<int> tree = new Tree<int>(nodes);

            // Task 1
            TreeNode<int> root = tree.Root;
            Console.WriteLine("Root : {0}", root.Value);
            Console.WriteLine(new string('-', 40));

            // Task 2
            List<TreeNode<int>> leafs = tree.FindAllLeafs();
            Print(leafs, "All leafs : ");
            Console.WriteLine(new string('-', 40));

            // Task 3
            List<TreeNode<int>> middleNodes = tree.FindAllMiddleNodes();
            Print(middleNodes, "All middle nodes : ");
            Console.WriteLine(new string('-', 40));

            // Task 4
            int longestPath = tree.FindLongestPath(root);
            Console.WriteLine("The longest path : {0}", longestPath);
            Console.WriteLine(new string('-', 40));

            int S = 10;

            // Task 5
            tree.PrintAllPathsWithSumS(S);
            
            // Task 6
            tree.PrintAllSubTreesWithSumS(S);
        }
    }
}
