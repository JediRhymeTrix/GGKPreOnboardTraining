using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BinarySearchTree
{
    class Node
    {
        private int _data;
        private int _count;

        public Node Left;
        public Node Right;

        public int Data
        {
            get
            {
                return _data;
            }
            set
            {
                _data = value;
            }
        }
    
        public int Count
        {
            get
            {
                return _count;
            }
            set
            {
                if (value > 0)
                {
                    _count = value;
                }
            }
        }

        public Node(int data)
        {
            this._data = data;
        }
    }

    class Bst
    {
        public void Insert(ref Node root, int data)
        {
            if (root == null)
            {
                root = new Node(data);
            }

            if (data < root.Data)
            {
                Insert(ref root.Left, data);
            }
            else if (data > root.Data)
            {
                Insert(ref root.Right, data);
            }
            else if (data == root.Data)
            {
                root.Count++;
            }
        }

        public void DisplayAscending(Node root)
        {
            if (root == null)
            {
                return;
            }

            DisplayAscending(root.Left);
            Console.Write(root.Data + " ");
            DisplayAscending(root.Right);
        }

        public void DisplayDescending(Node root)
        {
            if (root == null)
            {
                return;
            }

            DisplayDescending(root.Right);
            Console.Write(root.Data + " ");
            DisplayDescending(root.Left);
        }

        public bool Search(Node root, int data)
        {
            if (root == null)
            {
                return false;
            }
            else if (root.Data == data)
            {
                return true;
            }
            else if (data < root.Data)
            {
                return Search(root.Left, data);
            }
            else if (data > root.Data)
            {
                return Search(root.Right, data);
            }
            else
            {
                return false;
            }
        }

        static void Main(string[] args)
        {
            int size;
            int searchValue;
            Node root = null;
            Bst tree = new Bst();

            Console.WriteLine("Enter the size of the BST: ");
            size = int.Parse(Console.ReadLine());


            Console.WriteLine("Enter " + size + " newline-separated numbers: ");
            for (int iter = 0; iter < size; iter++)
            {
                tree.Insert(ref root, int.Parse(Console.ReadLine()));
            }

            Console.WriteLine("BST in ascending order: ");
            tree.DisplayAscending(root);
            Console.WriteLine();

            Console.WriteLine("BST in descending order: ");
            tree.DisplayDescending(root);
            Console.WriteLine();

            while (true)
            {
                try
                {
                    Console.WriteLine("Enter value to be looked up: (Enter non-numeric character to stop)");
                    searchValue = int.Parse(Console.ReadLine());

                    Console.WriteLine(tree.Search(root, searchValue));
                }
                catch(FormatException)
                {
                    Console.WriteLine("Exiting...");

                    break;
                }
            }
        }
    }
}
