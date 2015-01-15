namespace _01.Tree
{
    using System;
    using System.Collections.Generic;

    class EntryPoint
    {
        static void Main()
        {
            int n = int.Parse(Console.ReadLine());

            List<Node<int>> nodes = new List<Node<int>>();

            for (int i = 0; i < n; i++)
            {
                nodes.Add(new Node<int>(i));
            }

            for (int i = 0; i < n - 1; i++)
            {
                string pairAsString = Console.ReadLine();
                string[] pair = pairAsString.Split(' ');

                int pairKey = int.Parse(pair[0]);
                int pairValue = int.Parse(pair[1]);

                nodes[pairKey].Children.Add(nodes[pairValue]);
                nodes[pairValue].IsRoot = false;
            }

            // 1. Find root node

            var rootNode = FindRootNode(nodes);
            Console.WriteLine("The root of the tree is: {0}", rootNode.Value);

            //2. Find leaf nodes

            var leafNodes = FindLeafNodes(nodes);

            Console.Write("The leafs are: ");
            foreach (var node in leafNodes)
            {
                Console.Write(node.Value + ", ");
            }
            Console.WriteLine();

            //3. Find middle nodes

            var middleNodes = FindMiddleNodes(nodes);

            Console.Write("The middle nodes are: ");
            foreach (var node in middleNodes)
            {
                Console.Write(node.Value + ", ");
            }
            Console.WriteLine();

            //4. Find longest path

            int longestPath = FindLongestPath(rootNode);

            Console.WriteLine("The longest path is: {0}", longestPath);
        }

        private static Node<int> FindRootNode(List<Node<int>> nodes)
        {
            Node<int> root = new Node<int>();

            foreach (var node in nodes)
            {
                if (node.IsRoot) 
                {
                    root = node;
                    break;
                }
            }

            return root;
        }

        private static List<Node<int>> FindLeafNodes(List<Node<int>> nodes)
        {
            List<Node<int>> leafNodes = new List<Node<int>>();

            foreach (var node in nodes)
            {
                if (node.Children.Count == 0)
                {
                    leafNodes.Add(node);
                }
            }

            return leafNodes;
        }

        private static List<Node<int>> FindMiddleNodes(List<Node<int>> nodes)
        {
            List<Node<int>> middleNodes = new List<Node<int>>();

            foreach (var node in nodes)
            {
                if (node.Children.Count > 0 && !node.IsRoot)
                {
                    middleNodes.Add(node);
                }
            }

            return middleNodes;
        }

        private static int FindLongestPath(Node<int> root)
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
    }
}
