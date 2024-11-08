using Models;

namespace LabFloor;

class Program
{
    static void Main(string[] args)
    {
        BinaryTree<int> tree = new BinaryTree<int>(1);
        tree.Root.Left = new TreeNode<int>(2);
        tree.Root.Right = new TreeNode<int>(3);
        tree.Root.Left.Left = new TreeNode<int>(4);
        tree.Root.Left.Right = new TreeNode<int>(5);
        tree.Root.Right.Left = new TreeNode<int>(6);
        tree.Root.Right.Right = new TreeNode<int>(7);

        // количество узлов на каждом уровне
        Console.WriteLine("Количество узлов на каждом уровне:");
        tree.PrintNodeCountsPerLevel();

        // здесь переменная - указанный узел
        int level = 2;
        Console.WriteLine($"\nУзлы на уровне {level}:");
        var nodesAtLevel = tree.GetNodesAtLevel(level);
        foreach (var node in nodesAtLevel)
        {
            Console.Write(node + " ");
        }
    }
}