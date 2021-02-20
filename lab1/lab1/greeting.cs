using System;

namespace lab1
{
    class greeting
    {
        static void Main(string[] args)
        {
            string name;
            int i, j;
            Console.WriteLine("Please, enter two numbers with enter as a divider");
            name = Console.ReadLine();
            i = Convert.ToInt32(name);
            name = Console.ReadLine();
            j = Convert.ToInt32(name);
            int k;
            try
            {
                k = i / j;
                Console.WriteLine("Result is {0}", k);
            }
            catch
            {
                Console.WriteLine("Exception!");
            }
        }
    }
}
