using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Last_lab.classes
{
    public class BinaryTree
    {

        private class BinaryTreeNode
        {
            public BinaryTreeNode(string value)
            {
                Value = value;
            }

            public BinaryTreeNode? Left { get; set; }

            public BinaryTreeNode? Right { get; set; }

            public string Value { get; private set; }

        }


        private BinaryTreeNode? _head;

        private int _count;

        public int Count
        {
            get
            {
                return _count;
            }
        }

        public void Clear()
        {
            _head = null;
            _count = 0;
        }

        public void ReadFromFile(string path = "input.txt")
        {
            List<string> words;
            using (StreamReader reader = new StreamReader(path, System.Text.Encoding.Default))
            {
                string text = reader.ReadToEnd();
                words = text.Split(new char[] { ' ', '\r', '\n', ',', '.', '!', '?' }, StringSplitOptions.RemoveEmptyEntries).ToList();
            }

            foreach (var word in words)
            {
                Add(word);
            }

        }

        public int FindCount(char letter)
        {
            BinaryTreeNode? current = _head;


            while (current != null)
            {
                int result = current.Value[0].CompareTo(letter);

                if (result > 0)
                {

                    current = current.Left;
                }
                else if (result < 0)
                {

                    current = current.Right;
                }
                else
                {
                    break;
                }
            }

            if (current == null)
            {
                return 0;
            }
            else
            {
                int count = 0;
                TraverseInOrderForSearch(current, ref count, letter);
                return count;
            }


        }

        public void Add(string value)
        {
            if (_head == null)
            {
                _head = new BinaryTreeNode(value);
            }

            else
            {
                AddTo(_head, value);
            }

            _count++;
        }

        private void AddTo(BinaryTreeNode node, string value)
        {

            if (value.CompareTo(node.Value) < 0)
            {

                if (node.Left == null)
                {
                    node.Left = new BinaryTreeNode(value);
                }
                else
                {
                    AddTo(node.Left, value);
                }
            }
            else
            {

                if (value.CompareTo(node.Value) == 0)
                {

                }
                else
                {

                    if (node.Right == null)
                    {
                        node.Right = new BinaryTreeNode(value);
                    }
                    else
                    {
                        AddTo(node.Right, value);
                    }
                }
            }
        }

        private void TraverseInOrderForSearch(BinaryTreeNode parent, ref int count, char letter)
        {
            if (parent != null)
            {
                TraverseInOrderForSearch(parent.Left, ref count, letter);
                if (parent.Value[0] == letter)
                {
                    Console.Write("{0})" + parent.Value + "      ", ++count);
                }

                TraverseInOrderForSearch(parent.Right, ref count, letter);
            }
        }

        private void TraverseInOrder(BinaryTreeNode parent)
        {
            if (parent != null)
            {
                TraverseInOrder(parent.Left);
                Console.Write(parent.Value + " ");
                TraverseInOrder(parent.Right);
            }
        }

        public void TraverseInOrder()
        {
            if (_head != null)
            {
                TraverseInOrder(_head);
            }
            else
            {
                throw new InvalidOperationException("Tree is empty");
            }

        }

    }
}
