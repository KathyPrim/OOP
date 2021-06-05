using System;
using System.Collections.Generic;

namespace lab9
{
    enum ContainerType // тип хранения
    {
        COLD, // холодильник
        WET, // сухой склад
        DRY, // влажный склад
    }

    enum Unit // единица измерения
    {
        piece, // штуки
        kg, // килограммы
        gram, // граммы 
        pack, // упаковки
        liter, // литры
        ml, // милилитры

    }

    interface IBill
    {
        private static double bill;
        protected static void add_money(double a)
        {
            bill += a;
        }
        public static double get_money()
        {
            return bill;
        }
    }

    abstract class Piece // единица
    {
        public Unit unit; // единица измерения -- в них количество товара и за 1 единицу этого стоимость
        public float amount; // количество тоара в единицах unit -- добавить ограничения на ><0
    }
    
    class Item : Piece // наименование
    {
        public double price; // цена за единицу товара
        public uint due_date; // [1;366] срок годности
        public String article; // артикул товара (строка потому что артикул может содержать буквы и знаки препинания)
        public ContainerType container; // место хранения -- сухой/влажный склад или холодильник

        public Item(double price = 0.0, uint due_date = 0, String article = "", ContainerType container = 0, Unit unit = 0, float amount = 0)
        {
            this.price = price; // инициализация поля цена
            this.due_date = due_date; // инициализация поля срок годности
            this.article = article; // инициализация поля артикул
            this.container = container; // инициализация поля место хранения
            this.unit = unit; // инициализация поля единица измерения
            this.amount = amount; // инициализация поля количество
        }
        public float How_Much() // возвращает значение поля количество
        {
            return amount;
        }
        public bool Remove(float amount) // уменьшает количество на заданное значение, если это возможно
        {
            if (this.amount < amount)
            {
                return false;
            }
            this.amount -= amount;
            return true;
        }

        public void Add(float amount) // увеличивает количество на заданное значение
        {
            this.amount += amount;
        }

    }

    class Storage : IBill // склад
    {
        public List<Item> cold_storage; // список товаров, хранящихся в холодильнике
        public List<Item> wet_storage; // список товаров на влажном складе
        public List<Item> dry_storage; // список товаров в сухом складе

        public Storage()
        {
            cold_storage = new List<Item>();
            wet_storage = new List<Item>();
            dry_storage = new List<Item>();
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

        public bool Buy(String article, ContainerType container, float amount)
        {
            Item item = new Item(); // переменная для хранения наименования склада
            bool shit = false;
            if(Find(article, container, ref item)) // ищем элемент
            {
                shit = item.Remove(amount); // если вохможно, убираем нужное количество, если нет -- вернём false
                if (shit)
                {
                    IBill.add_money(item.price * amount); // добавляем денюжки на счёт
                }
            }
            return shit; // если элемент не был найден
        }

        public bool Sell(String article, ContainerType container, float amount)
        {
            Item item = new Item();
            if (Find(article, container, ref item))
            {
                item.Add(amount); // добавляем элементы
                return true;// если элемент был найден
            }
            return false; // если элемент не был найден
        }

        public void Add_Item(double price = 0.0, uint due_date = 0, String article = "", 
            ContainerType container = 0, Unit unit = 0, float amount = 0) // добавление элемента на склад
        {
            // создаём элемент и добавляем его на свой склад
            Item item = new Item(price, due_date, article, container, unit, amount);
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
            if(Find(article, container, ref item)) // если элемент найден
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
    }

    class lab9
    {
        static void Main(string[] args)
        {
            Storage myStorage = new Storage();
            myStorage.Add_Item(10.0, 256, "мяу", ContainerType.DRY, Unit.piece, 100); // Добавляем на сухой склад 100 котиков по цене 10
            myStorage.Add_Item(100.0, 304, "гав", ContainerType.WET, Unit.pack, 100); // Добавляем на влажный склад 100 собачек по цене 100
            if(myStorage.Buy("гав", ContainerType.WET, 1))
            {
                Console.WriteLine("Вы успешно купили 1 собачку!");
            }
        }
    }
}