/*using System;
using System.IO;

namespace lab7
{
    class ex2
    {
        public static void Main()
        {
            string sFrom, sTo;
            StreamReader srFrom;
            StreamWriter swTo;
            Console.WriteLine("Введите путь до файла для чтения");
            sFrom = Console.ReadLine();
            Console.WriteLine("Введите путь до файла для записи");
            sTo = Console.ReadLine();
            try
            {
                srFrom = new StreamReader(sFrom);
                swTo = new StreamWriter(sTo);
                while (srFrom.Peek() != -1)
                {
                    string sBuffer = srFrom.ReadLine();
                    sBuffer = sBuffer.ToUpper();
                    swTo.WriteLine(sBuffer);
                }
                swTo.Close();
                srFrom.Close();
            }
            catch(FileNotFoundException)
            {
                Console.WriteLine("Несуществующий файл");
            }
            catch (Exception e)
            {
                Console.WriteLine("Что-то пошло не так");
                Console.WriteLine(e.ToString());

            }
        }
    }
}*/
