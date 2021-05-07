using System;
using System.Collections.Generic;

namespace lab9
{
    enum ContainerType
    {
        cold, // холодильник
        wet, // сухой склад
        dry, // влажный склад
    }

    enum Unit
    {
        piece, // штуки
        kg, // килограммы
        gram, // граммы 
        pack, // упаковки
        liter, // литры
        ml, // милилитры

    }
    class Item
    {
        public double price; // цена за единицу товара
        public int due_date; // [1;366] срок годности
        public String article; // артикул товара (строка потому что артикул может содержать буквы и знаки препинания)
        public ContainerType Container; // место хранения -- сухой/влажный склад или холодильник
        public Unit unit; // единица измерения -- в них количество товара и за 1 единицу этого стоимость
        public float amount; // количество тоара в единицах unit -- добавить ограничения на ><0
    }

    class Storage
    {
        public LinkedList<Item> cold_storage; // список товаров, хранящихся в холодильнике
        public LinkedList<Item> wet_storage; // список товаров на влажном складе
        public LinkedList<Item> dry_storage; // список товаров в сухом складе

    }
}
