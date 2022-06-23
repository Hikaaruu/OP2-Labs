using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Last_lab.classes
{
    internal class Program
    {
        static void Main(string[] args)
        {
            BinaryTree binaryTree = new BinaryTree();
            binaryTree.ReadFromFile();
            binaryTree.TraverseInOrder();

            #region get and parse letter
            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine("Enter a letter for search : ");

            char letter;

            while (!char.TryParse(Console.ReadLine(), out letter) || char.IsDigit(letter))
            {
                Console.WriteLine();
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Incorrect format! Try again ");
                Console.WriteLine();
                Console.ForegroundColor = ConsoleColor.White;
                Console.WriteLine("Enter a letter for search : ");
            }
            Console.WriteLine();
            #endregion

            int count = binaryTree.FindCount(letter);

            #region output result
            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine("Total count : {0}", count);
            #endregion
        }
    }
}
