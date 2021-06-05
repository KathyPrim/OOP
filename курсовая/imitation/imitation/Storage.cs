using System;
using System.Collections.Generic;
using System.Text;

namespace imitation
{
    class Storage : IBill // склад
    {
        public List<Item> cold_storage; // список товаров, хранящихся в холодильнике
        public List<Item> wet_storage; // список товаров на влажном складе
        public List<Item> dry_storage; // список товаров в сухом складе
        public uint curr_date; // текущая дата
        public List<Ship> waiting_list; // лист ожидания
        public List<Ship> order; // заказы, поступившие сегодня
        public List<Ship> ships; // заказы, которые нужно сегодня отправить

        public Storage(uint date = 0) // конструктор класса
        {
            cold_storage = new List<Item>();
            wet_storage = new List<Item>();
            dry_storage = new List<Item>();
            curr_date = date;
            waiting_list = new List<Ship>();
            order = new List<Ship>();
            ships = new List<Ship>();
            IBill.bill = 0;
        }

        public bool Find(String article, ContainerType container, ref Item item) // поиск элемента на складе типа container
        {
            switch (container) // в зависимости от типа контейнера
            {
                // просматриваем каждый элемент списка хранилища, пока не найдёт тот элемент, который нам нужен
                case ContainerType.COLD:
                    {
                        foreach (Item a in cold_storage)
                        {
                            if (a.article == article)
                            {
                                item = a;
                                return true;
                            }
                        }
                        break;
                    }
                case ContainerType.WET:
                    {
                        foreach (Item a in wet_storage)
                        {
                            if (a.article == article)
                            {
                                item = a;
                                return true;
                            }
                        }
                        break;
                    }
                case ContainerType.DRY:
                    {
                        foreach (Item a in dry_storage)
                        {
                            if (a.article == article)
                            {
                                item = a;
                                return true;
                            }
                        }
                        break;
                    }
            }
            return false; // если элемент не был найден
        }

        public bool Find(String article, ref Item item) // поиск элемента на складе всех типов
        {
            // проходим по всем хранилищам, пока не найдём элемент
            foreach (Item a in cold_storage)
            {
                if (a.article == article)
                {
                    item = a;
                    return true;
                }
            }
            foreach (Item a in wet_storage)
            {
                if (a.article == article)
                {
                    item = a;
                    return true;
                }
            }
            foreach (Item a in dry_storage)
            {
                if (a.article == article)
                {
                    item = a;
                    return true;
                }
            }
            return false; // если элемент не был найден
        }

        public bool Sell(String article, uint amount, uint where)
        {
            bool r = false;  // если элемент не был найден
            Item item = new Item(); // переменная для хранения наименования склада
            if (Find(article, ref item)) // ищем элемент
            {
                r = item.Retail_remove(amount); // если возможно, убираем нужное количество, если нет -- вернём false
                Ship ship = new Ship(article, amount, where);
                if (r)
                {
                    ships.Add(ship);
                    IBill.add_money(item.price * amount);
                }
                else
                {
                    waiting_list.Add(ship);
                }
            }
            return r;
        }

        public bool WS_Sell(Ship s)
        {
            bool r = false;  // если элемент не был найден
            Item item = new Item(); // переменная для хранения наименования склада
            if (Find(s.article, ref item)) // ищем элемент
            {
                r = item.Wholesale_remove(s.wholesale_amount); // если возможно, убираем нужное количество, если нет -- вернём false
                if (r)
                {
                    ships.Add(s);
                }
                else
                {
                    waiting_list.Add(s);
                }
            }
            return r;
        }

        public bool wholesale_sell(String article, ContainerType container, uint amount, uint where)
        {
            bool r = false;  // если элемент не был найден
            Item item = new Item(); // переменная для хранения наименования склада
            if (Find(article, container, ref item)) // ищем элемент
            {
                r = item.Wholesale_remove(amount); // если возможно, убираем нужное количество, если нет -- вернём false
                if (r)
                {
                    Ship ship = new Ship(article, amount, where);
                    ships.Add(ship);
                }
                else
                {
                    Ship ship = new Ship(article, amount*item.pack_amount, where);
                    waiting_list.Add(ship);
                }
            }
            return r;
        }

        public void Add_Item(float s = 0, uint pa = 0, uint m = 0, double price = 0.0, 
            uint due_date = 0, String article = "", ContainerType container = 0, 
            Unit unit = 0, uint amount = 0) // добавление элемента на склад
        {
            // создаём элемент и добавляем его на свой склад
            Item item = new Item(s, pa, m, price, due_date,article, container, unit, amount);
            switch (container)
            {
                case ContainerType.COLD:
                    {
                        cold_storage.Add(item);
                        break;
                    }
                case ContainerType.WET:
                    {
                        wet_storage.Add(item);
                        break;
                    }
                case ContainerType.DRY:
                    {
                        dry_storage.Add(item);
                        break;
                    }
            }
        }

        public void Add_Item(Item item) // добавление элемента на склад
        {
            // добавляем элемент на свой склад
            switch (item.container)
            {
                case ContainerType.COLD:
                    {
                        cold_storage.Add(item);
                        return;
                    }
                case ContainerType.DRY:
                    {
                        dry_storage.Add(item);
                        return;
                    }
                case ContainerType.WET:
                    {
                        wet_storage.Add(item);
                        return;
                    }
            }
        }

        public bool Delete_Item(String article, ContainerType container) // удаление наименования из списка хранения
        {
            Item item = new Item();
            if (Find(article, container, ref item)) // если элемент найден
            { // удаляем его из своего контейнера
                switch (container)
                {
                    case ContainerType.COLD:
                        {
                            cold_storage.Remove(item);
                            return true;
                        }
                    case ContainerType.WET:
                        {
                            wet_storage.Remove(item);
                            return true;
                        }
                    case ContainerType.DRY:
                        {
                            dry_storage.Remove(item);
                            return true;
                        }
                }
            }
            return false; // если элемент не был найден
        }

        public void Sell_all()
        {
            int shit = waiting_list.Count;
            for (int i = 0; i < shit; i++)
            {
                if (WS_Sell(waiting_list[i]))
                {
                    waiting_list.Remove(waiting_list[i]);
                    shit--;
                    i--;
                }
            }
            for (int i = 0; i < order.Count; i++)
            {
                WS_Sell(order[i]);
            }
            Add_all();
        }

        public void Add_all()
        {
            Random smol = new Random();
            foreach(Item i in cold_storage)
            {
                i.wholesale_amount += (uint)smol.Next(25);
            }
            foreach (Item i in wet_storage)
            {
                i.wholesale_amount += (uint)smol.Next(50);
            }
            foreach (Item i in dry_storage)
            {
                i.wholesale_amount += (uint)smol.Next(50);
            }
        }
    }
}
