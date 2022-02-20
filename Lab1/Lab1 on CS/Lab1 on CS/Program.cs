using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace Lab1_on_CS
{
    class Program
    {
        private static void CopyRows(StreamReader input, StreamWriter output)
        {
            int miss;
            List<string> lines = new List<string>();
            Console.WriteLine();
            Console.WriteLine("Enter the amount of rows you want to copy:");
            int amount = Convert.ToInt32(Console.ReadLine());
            int rows = GetLines(input, lines);
            if (amount>rows || amount<0)
            {
                Console.WriteLine();
                Console.WriteLine("This number can't be negative or less than amount of all raws");
                return;
            }
            string[] newlines = DeleteDuplicated(amount, rows, lines.ToArray(), out miss);
            Console.WriteLine();
            Console.WriteLine("output.txt : ");
            foreach (string str in newlines)
            {
                output.WriteLine(str);
                Console.WriteLine(str);
            }
            Console.WriteLine();
            Console.WriteLine("The amount of deleted rows = " + miss);
        }
        private static string[] DeleteDuplicated(int amount, int rows, string[] lines, out int miss)
        {
            List<string> result = new List<string>();
             miss = 0;
            for (int i = rows-amount; i < rows; i++)
            {
                if (result.Contains(lines[i]))
                {
                    miss++;
                    continue;
                }
                result.Add(lines[i]);
            }
            return result.ToArray();
        }
        private static int GetLines(StreamReader input, List<string> lines)
        {
            string a = null;
            int rows = 0;
            while (!input.EndOfStream)
            {
                a = input.ReadLine();
                lines.Add(a);
                rows++;
            }
            return rows;
        }
        private static int InputText(StreamWriter input)
        {
            Console.WriteLine("Enter text (press home to continue):");
            string text = null;
            int raws = 1;
            ConsoleKeyInfo key;
            while (true)
            {
                key = Console.ReadKey();
                if (key.Key == ConsoleKey.Home)
                {
                    break;
                }
                if (key.Key == ConsoleKey.Enter)
                {
                    text += '\n';
                    Console.Clear();
                    Console.WriteLine("Enter text (press home to continue):");
                    Console.Write(text);
                    continue;
                }
                if ((key.Key == ConsoleKey.Backspace) && text.Length > 0)
                {
                    text = text.Remove(text.Length - 1);
                    Console.Clear();
                    Console.WriteLine("Enter text (press home to continue):");
                    Console.Write(text);
                    raws++;
                    continue;
                }
                text += key.KeyChar;
            }
            input.WriteLine(text);
            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine("input.txt : ");
            Console.WriteLine(text);
            return (raws);
        }
        static void Main(string[] args)
        {
            using (StreamWriter input = new StreamWriter(@"C:\OP-2 Labs\1 C#\Lab1 on CS\input.txt", false, System.Text.Encoding.Default))
            {
                int rows = InputText(input);
            }
            using (StreamReader input = new StreamReader(@"C:\OP-2 Labs\1 C#\Lab1 on CS\input.txt", System.Text.Encoding.Default))
            {
                using (StreamWriter output = new StreamWriter(@"C:\OP-2 Labs\1 C#\Lab1 on CS\output.txt", false, System.Text.Encoding.Default))
                {
                    CopyRows(input, output);
                }
            }



        }
    }
}
