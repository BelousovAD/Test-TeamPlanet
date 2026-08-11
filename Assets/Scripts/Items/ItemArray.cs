using System;

namespace Items
{
    public class ItemArray
    {
        private readonly Item[,] _items;

        public ItemArray(Item[,] items)
        {
            _items = items;
        }

        public event Action<int, int> ItemChanged;

        public Item this[int y, int x] => _items[y, x];

        public void Merge(Item first, Item second)
        {
            throw new NotImplementedException();
        }
    }
}