namespace TreeOperations
{
    using System;
    using System.Collections.Generic;

    public class TreeNode<T>
    {
        public TreeNode(T value)
        {
            this.Value = value;
            this.Children = new List<TreeNode<T>>();
        }

        public T Value { get; set; }

        public TreeNode<T> Parent { get; set; }

        public List<TreeNode<T>> Children { get; private set; }

        public bool HasParent { get; private set; }

        public void AddChild(TreeNode<T> child)
        {
            if (child.HasParent)
            {
                throw new ArgumentException("Child cannot have more than one parent.");
            }
            else
            {
                this.Children.Add(child);
                child.HasParent = true;
                child.Parent = this;
            }
        }
    }
}
