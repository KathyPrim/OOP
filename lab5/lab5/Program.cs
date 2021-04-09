using System;
using System.IO;

namespace lab5
{
    class Program
    {
        static void Main(string[] args)
        {
            /*string fname = args[0];
            FileStream fstream = new FileStream(fname, FileMode.Open);
            StreamReader fread = new StreamReader(fstream);
            long fsize = fstream.Length;
            char[] arg = new char[fsize];
            int strings = 0, vowel = 0, consonant = 0;
            for(int i = 0; i<fsize; i++)
            {
                arg[i] = (char)fread.Read();
            }
            //char[] arg = new char[] { 'a', 'b', 'c', 'd' };
            foreach(char i in arg)
            {
                Console.Write(i);
                if ("AEIOUaeiou".IndexOf(i) != -1)
                {
                    vowel++;
                }
                else {
                    if (i == '\n')
                    {
                        strings++;
                    }
                    else
                    {
                        consonant++;
                    }
                }
            }
            consonant -= strings;
            Console.WriteLine("\nСтрок {0}, \nСогласных {1}, \nГласных {2}.", ++strings, consonant, vowel);*/
            int[,] a = new int[2, 2];
            int[,] b = new int[2, 2];
            int[,] res = new int[2, 2];
            for(int i=0; i < 2; i++)
            {
                for (int j = 0; j<2; j++)
                {
                    Console.WriteLine("Enter element number [{0}, {1}]", i, j);
                    a[i, j] = Convert.ToInt32(Console.ReadLine());
                }
            }
            Console.WriteLine("Matrix a is:");
            for (int i = 0; i < 2; i++)
            {
                for (int j = 0; j < 2; j++)
                {
                    Console.Write("{0} ", a[i,j]);
                }
                Console.WriteLine();
            }
            for (int i = 0; i < 2; i++)
            {
                for (int j = 0; j < 2; j++)
                {
                    Console.WriteLine("Enter element number [{0}, {1}]", i, j);
                    b[i, j] = Convert.ToInt32(Console.ReadLine());
                }
            }
            Console.WriteLine("Matrix b is:");
            for (int i = 0; i < 2; i++)
            {
                for (int j = 0; j < 2; j++)
                {
                    Console.Write("{0} ", a[i, j]);
                }
                Console.WriteLine();
            }
            res[0, 0] = a[0, 0] * b[0, 0] + a[0, 1] * b[1, 0];
            res[0, 1] = a[0, 0] * b[0, 1] + a[0, 1] * b[1, 1];
            res[1, 0] = a[1, 0] * b[0, 0] + a[1, 1] * b[1, 0];
            res[1, 1] = a[1, 0] * b[0, 1] + a[1, 1] * b[1, 1];
            Console.WriteLine("Matrix res is:");
            for (int i = 0; i < 2; i++)
            {
                for (int j = 0; j < 2; j++)
                {
                    Console.Write("{0} ", res[i, j]);
                }
                Console.WriteLine();
            }
        }
    }
} 
