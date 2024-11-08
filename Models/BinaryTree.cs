namespace Models;

using System;
using System.Collections.Generic;

public class BinaryTree<T>
{
    public TreeNode<T> Root { get; private set; }

    public BinaryTree(T rootValue)
    {
        Root = new TreeNode<T>(rootValue);
    }

    public void PrintNodeCountsPerLevel()
    {
        var levels = GetNodeCountsPerLevel();
        int level = 0;
        foreach (int count in levels)
        {
            Console.WriteLine($"Уровень {level++}: {count} узлов");
        }
    }

    private List<int> GetNodeCountsPerLevel()
    {
        List<int> counts = new List<int>();
        Queue<TreeNode<T>> queue = new Queue<TreeNode<T>>();
        queue.Enqueue(Root);

        while (queue.Count > 0)
        {
            int levelCount = queue.Count;
            counts.Add(levelCount);

            for (int i = 0; i < levelCount; i++)
            {
                TreeNode<T> node = queue.Dequeue();

                if (node.Left != null) queue.Enqueue(node.Left);
                if (node.Right != null) queue.Enqueue(node.Right);
            }
        }

        return counts;
    }

    public List<T> GetNodesAtLevel(int level)
    {
        List<T> result = new List<T>();
        Queue<(TreeNode<T> node, int depth)> queue = new Queue<(TreeNode<T>, int)>();
        queue.Enqueue((Root, 0));

        while (queue.Count > 0)
        {
            var (node, depth) = queue.Dequeue();

            if (depth == level)
            {
                result.Add(node.Value);
            }

            if (depth < level)
            {
                if (node.Left != null) queue.Enqueue((node.Left, depth + 1));
                if (node.Right != null) queue.Enqueue((node.Right, depth + 1));
            }
        }

        return result;
    }
}
