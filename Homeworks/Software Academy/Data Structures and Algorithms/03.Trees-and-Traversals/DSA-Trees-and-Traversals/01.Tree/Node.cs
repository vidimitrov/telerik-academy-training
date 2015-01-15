namespace _01.Tree
{
    using System;
    using System.Collections.Generic;

    public class Node<T>
    {
        public Node()
        {

        }
        public Node(T value)
        {
            this.Children = new List<Node<T>>();
            this.Value = value;
            this.IsRoot = true;
        }

        public T Value { get; set; }
        public List<Node<T>> Children { get; set; }
        public bool IsRoot { get; set; }
    }
}
