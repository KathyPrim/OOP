using System;
using System.Collections.Generic;
using System.Threading;

namespace imitation
{
   class imitation
    {
        static void Main(string[] args)
        {
            Random smol = new Random();
            int l = smol.Next(10, 30);
            Storage myStorage = new Storage();
            int goods_amount = smol.Next(12, 20), // число товаров на складе, от 12 до 20
                points_amount = smol.Next(3, 9), // число торговых точек от 3 до 9
                ships_amount = smol.Next(10);
            Console.WriteLine("Точек: {0}, наименований: {1}, доставок {2}", points_amount, goods_amount, ships_amount);
            for (int i = 0; i < goods_amount; i++)
            { // заполнение склада случайными элементами
                myStorage.Add_Item(smol.Next(), (uint)smol.Next(), (uint)smol.Next(), (uint)smol.Next(),
                (uint)smol.Next(), Convert.ToString(i), (ContainerType)(smol.Next() % 3),
                (Unit)(smol.Next() % 6), (uint)smol.Next(10, 200)); // Создание элемента со случайными значениями полей
            }
            for (int k= 1; k<=l; k++)
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
                ships_amount = smol.Next(10);
                Thread.Sleep(3000);
            }
        }
    }
}