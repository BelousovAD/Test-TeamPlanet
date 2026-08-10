using System;

namespace Items
{
    internal class ItemArray
    {
        private readonly Item[,] _items;

        public ItemArray(Item[,] items)
        {
            _items = items;
        }

        public event Action<int, int> ItemChanged;

        public Item this[int y, int x] => _items[y, x];
    }
}