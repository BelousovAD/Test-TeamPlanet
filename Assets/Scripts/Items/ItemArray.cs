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

        public void Merge((int, int) sourceIndex, (int, int) targetIndex)
        {
            Item first = _items[sourceIndex.Item1, sourceIndex.Item2];
            Item second = _items[targetIndex.Item1, targetIndex.Item2];
            
            if (first is null && second is null)
            {
                throw new InvalidOperationException("Both items are null");
            }

            if (first is null)
            {
                throw new InvalidOperationException("Source item is null");
            }

            if (second is null)
            {
                _items[targetIndex.Item1, targetIndex.Item2] = first;
                _items[sourceIndex.Item1, sourceIndex.Item2] = null;
                ItemChanged?.Invoke(targetIndex.Item1, targetIndex.Item2);
                ItemChanged?.Invoke(sourceIndex.Item1, sourceIndex.Item2);
                
                return;
            }

            if (first != second && first.Type == second.Type && first.State == second.State && second.Upgrade())
            {
                _items[sourceIndex.Item1, sourceIndex.Item2] = null;
                ItemChanged?.Invoke(sourceIndex.Item1, sourceIndex.Item2);
            }
        }
    }
}