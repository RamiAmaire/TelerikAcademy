namespace TreeOperations
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    public class Tree<T>
    {
        private TreeNode<T> root;

        public TreeNode<T>[] Nodes { get; set; }
        
        public TreeNode<T> Root
        {
            get
            {
                return this.root;
            }

            set
            {
                this.root = this.FindRoot();
            }
        }

        public Tree(TreeNode<T>[] nodes)
        {
            this.Nodes = nodes;
            this.root = this.FindRoot();
        }

        public List<TreeNode<T>> FindAllLeafs()
        {
            List<TreeNode<T>> leafs = new List<TreeNode<T>>();
            foreach (var node in this.Nodes)
            {
                if (node.Children.Count == 0)
                {
                    leafs.Add(node);
                }
            }

            return leafs;
        }

        public List<TreeNode<T>> FindAllMiddleNodes()
        {
            List<TreeNode<T>> middleNodes = new List<TreeNode<T>>();
            foreach (var node in this.Nodes)
            {
                if (node.Children.Count > 0 && node.HasParent)
                {
                    middleNodes.Add(node);
                }
            }

            return middleNodes;
        }

        public int FindLongestPath(TreeNode<int> root)
        {
            if (root.Children.Count == 0)
            {
                return 0;
            }

            int maxPath = 0;
            foreach (var node in root.Children)
            {
                maxPath = Math.Max(maxPath, FindLongestPath(node));
            }

            return maxPath + 1;
        }

        public void PrintAllPathsWithSumS(int S)
        {
            Console.WriteLine("All paths : ");
            PrintPaths(this.Root, S, Convert.ToInt32(Root.Value), this.Root.Value.ToString());
            Console.WriteLine(new string('-', 40));
        }

        public void PrintAllSubTreesWithSumS(int S)
        {
            HashSet<string> subTrees = new HashSet<string>();
            string subTree = string.Empty;
            Console.WriteLine("All sub trees : ");

            foreach (var node in this.Nodes)
            {
                SaveSubTrees(node, subTrees, subTree, 0, S);
            }

            foreach (var subtree in subTrees)
            {
                Console.WriteLine(subtree);
            }

            Console.WriteLine(new string('-', 40));
        }

        private void PrintPaths(TreeNode<T> root, int S, int sum, string path)
        {
            if (sum == S)
            {
                Console.WriteLine(path);
            }
            else
            {
                foreach (var child in root.Children)
                {
                    PrintPaths(child, S, sum + Convert.ToInt32(child.Value), path + " -> " + child.Value);
                }
            }
        }

        private TreeNode<T> FindRoot()
        {
            foreach (var node in this.Nodes)
            {
                if (!node.HasParent)
                {
                    return node;
                }
            }

            throw new ArgumentException("Invalid input");
        }

        private void SaveSubTrees(TreeNode<T> node, HashSet<string> subTrees, string subtree, long currentSum, long S)
        {
            currentSum += Convert.ToInt32(node.Value);
            subtree += " -> " + node.Value;
            
            foreach (var child in node.Children)
            {
                SaveSubTrees(child, subTrees, subtree, currentSum, S);
            }

            if (currentSum == S)
            {
                subTrees.Add(subtree.Substring(4));
            }
        }
    }
}
