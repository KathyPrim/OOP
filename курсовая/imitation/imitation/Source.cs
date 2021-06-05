using System;
using System.Collections.Generic;
using System.Text;

namespace imitation
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

    abstract class Piece // единица -- оптовая упаковка
    {
        public Unit unit; // единица измерения -- в них количество товара в 1 розничной упаковке
        public float size; // количество тоара в единицах unit в 1 розничной упаковке
        public uint pack_amount; // количество розничных упаковок
    }

    class Item : Piece // наименование
    {
        public uint wholesale_amount; // количество оптовых упаковок
        public uint max_ws_amount; // максимальное число упаковок на складе
        public double price; // цена за единицу товара
        public uint due_date; // [1;366] срок годности
        public String article; // артикул товара (строка потому что артикул может содержать буквы и знаки препинания)
        public ContainerType container; // место хранения -- сухой/влажный склад или холодильник

        public Item(float s = 0, uint pa = 0, uint m = 0, double price = 0.0, uint due_date = 0, String article = "", 
            ContainerType container = 0, Unit unit = 0, uint amount = 0)
        {
            this.unit = unit; // инициализация поля единица измерения
            this.size = s;
            this.pack_amount = pa;
            this.wholesale_amount = amount; // инициализация поля количество
            this.max_ws_amount = m;
            this.price = price; // инициализация поля цена
            this.due_date = due_date; // инициализация поля срок годности
            this.article = article; // инициализация поля артикул
            this.container = container; // инициализация поля место хранения
            
        }
        
        public bool Retail_remove(uint a) // уменьшает количество на заданное значение, если это возможно
        {
            if (this.wholesale_amount*pack_amount < a)
            {
                return false;
            }
            if(a%pack_amount == 0)
            {
                this.wholesale_amount -= (a/pack_amount);
            }
            else if (a % pack_amount < pack_amount/2)
            {
                this.wholesale_amount -= (a / pack_amount);
            }
            else
            {
                this.wholesale_amount -= (a / pack_amount + 1);
            }
            return true;
        }

        public bool Wholesale_remove(uint a)
        {
            if(a > wholesale_amount)
            {
                return false;
            }
            wholesale_amount -= a;
            return true;
        }

        public void Add(uint a) // увеличивает количество на заданное значение
        {
            this.wholesale_amount += a;
        }

    }

    class Ship
    {
        public String article;
        public uint wholesale_amount;
        public uint where;

        public Ship(string s = "", uint a = 0, uint w = 0)
        {
            this.article = s;
            this.wholesale_amount = a;
            this.where = w;
        }
    }

    interface IBill
    {
        protected static double bill;

        protected static void add_money(double a)
        {
            bill += a;
        }
        public static double get_money()
        {
            return bill;
        }
    }
}
