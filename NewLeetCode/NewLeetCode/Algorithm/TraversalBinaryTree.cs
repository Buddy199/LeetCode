using System.Collections.Generic;
using System.Linq;

namespace LeetCode
{
    public class TraversalBinaryTree
    {
        public IList<int> PreorderTraversal(TreeNode root)
        {
            var list = new List<int>();
            if (root == null)
            {
                return list;
            }
            
            var stack = new Stack<TreeNode>();
            stack.Push(root);
            while (stack.Any())
            {
                var node = stack.Pop();
                list.Add(node.Val);
                if (node.Right != null)
                {
                    stack.Push(node.Right);
                }

                if (node.Left != null)
                {
                    stack.Push(node.Left);
                }
            }

            return list;
        }

        public IList<int> InorderTraversal(TreeNode root)
        {
            var list = new List<int>();
            if (root == null)
            {
                return list;
            }
            
            var stack = new Stack<TreeNode>();
            stack.Push(root);
            var node = root;
            while (node != null || stack.Any())
            {
                while (node != null)
                {
                    stack.Push(node);
                    node = node.Left;
                }

                node = stack.Pop();
                list.Add(node.Val);
                node = node.Right;
            }

            return list;
        }

        public IList<int> PostOrderTraversal(TreeNode root)
        {
            var list = new List<int>();
            if (root == null)
            {
                return list;
            }
            
            var stack = new Stack<TreeNode>();
            stack.Push(root);
            while (stack.Any())
            {
                var node = stack.Pop();
                if (node != null)
                {
                    stack.Push(node);
                    stack.Push(null);
                    if (node.Right != null)
                    {
                        stack.Push(node.Right);
                    }

                    if (node.Left != null)
                    {
                        stack.Push(node.Left);
                    }
                }
                else
                {
                    list.Add(stack.Pop().Val);
                }
            }

            return list;
        }
    }

    public class TreeNode
    {
        public int Val;
        public TreeNode Left;
        public TreeNode Right;

        public TreeNode(int x)
        {
            Val = x;
        }
    }
}