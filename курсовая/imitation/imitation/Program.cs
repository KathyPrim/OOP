using System;
using System.Collections.Generic;
using System.Threading;

namespace imitation
{
   class imitation
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Задайте шаг моделирования в днях (рекомендуемое значение от 1 до 3)");
            int step = Convert.ToInt32(Console.ReadLine())*1000;
            Console.WriteLine("Введите 1 если хотите ввести параметры (4 основных значения системы) вручную " +
                "и 0 если хотите сгенерировать их случайным образом");
            int choise = Convert.ToInt32(Console.ReadLine());
            Random smol = new Random();
            Storage myStorage = new Storage();
            int l, // длина цикла моделирования
                goods_amount, // число товаров на складе, от 12 до 20
                points_amount, // число торговых точек от 3 до 9
                ships_amount; // число доставок
            if (choise == 1)
            {
                Console.WriteLine("Введите число дней для моделирования (рекомендуемое число от 10 до 30)");
                l = Convert.ToInt32(Console.ReadLine());
                Console.WriteLine("Введите число товаров на складе (рекомендуемое число от 12 до 20)");
                goods_amount = Convert.ToInt32(Console.ReadLine());
                Console.WriteLine("Введите число торговых точек (рекомендуемое число от 3 до 9)");
                points_amount = Convert.ToInt32(Console.ReadLine());
                Console.WriteLine("Введите число доставок для каждой точки (рекомендуемое число от 1 до 10)");
                ships_amount = Convert.ToInt32(Console.ReadLine());
            }
            else
            {
                l = smol.Next(10, 12);
                goods_amount = smol.Next(12, 20); // число товаров на складе, от 12 до 20
                points_amount = smol.Next(3, 9); // число торговых точек от 3 до 9
                ships_amount = smol.Next(10);
            }
            Console.WriteLine("Точек: {0}, наименований: {1}, доставок {2}", points_amount, goods_amount, ships_amount);
            Console.WriteLine("Начать моделирование системы с данными параметрами? Введите 1, если да, и 0, если нет.");
            choise = Convert.ToInt32(Console.ReadLine());
            if(choise == 1)
            {
                Console.WriteLine("Моделирование системы.");
                for (int i = 0; i < goods_amount; i++)
                { // заполнение склада случайными элементами
                    myStorage.Add_Item(smol.Next(), (uint)smol.Next(), (uint)smol.Next(), (uint)smol.Next(),
                    (uint)smol.Next(), Convert.ToString(i), (ContainerType)(smol.Next() % 3),
                    (Unit)(smol.Next() % 6), (uint)smol.Next(10, 200)); // Создание элемента со случайными значениями полей
                }
                for (int k = 1; k <= l; k++)
                {
                    for (int i = 0; i < points_amount; i++) // для каждой точки
                    {
                        for (int j = 0; j < ships_amount; j++) // своё число заказов
                        {
                            Ship s = new Ship(Convert.ToString(smol.Next(0, goods_amount)),
                                (uint)(smol.Next(10)), (uint)(smol.Next(points_amount)));
                            myStorage.order.Add(s); // заполняем очередь заказов
                        }
                    }
                    Console.WriteLine("День {0} из {1}.", k, l);
                    Console.WriteLine("Очередь заказов из {0} товаров для {1} точек", myStorage.order.Count, points_amount);
                    myStorage.Sell_all();
                    Console.WriteLine("Доставок на завтра: {0}, в листе ожидания: {1}", myStorage.ships.Count, myStorage.waiting_list.Count);
                    myStorage.ships.Clear();
                    myStorage.order.Clear();
                    //Thread.Sleep(step);
                }
            }
            else
            {
                Console.WriteLine("Вы выщли из моделирования.");
            }
            Console.WriteLine("Конец работы программы. Всего хорошего!");
        }
    }
}