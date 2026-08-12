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

        public void HandleCollision((int, int) sourceIndex, (int, int) targetIndex)
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
                Swap(sourceIndex, targetIndex);
                
                return;
            }

            if (first != second &&
                first.Type == second.Type &&
                first.IsSpawner == second.IsSpawner &&
                first.State == second.State &&
                second.Upgrade())
            {
                _items[sourceIndex.Item1, sourceIndex.Item2] = null;
                ItemChanged?.Invoke(sourceIndex.Item1, sourceIndex.Item2);
            }
            else
            {
                Swap(sourceIndex, targetIndex);
            }
        }

        private void Swap((int, int) sourceIndex, (int, int) targetIndex)
        {
            (_items[targetIndex.Item1, targetIndex.Item2], _items[sourceIndex.Item1, sourceIndex.Item2]) =
                (_items[sourceIndex.Item1, sourceIndex.Item2], _items[targetIndex.Item1, targetIndex.Item2]);
            ItemChanged?.Invoke(targetIndex.Item1, targetIndex.Item2);
            ItemChanged?.Invoke(sourceIndex.Item1, sourceIndex.Item2);
        }

        public bool TryAddItem(Item item)
        {
            (int y, int x) = GetIndexOfFirstEmptyPlace();

            if (y == -1 && x == -1)
            {
                return false;
            }

            _items[y, x] = item;
            ItemChanged?.Invoke(y, x);

            return true;
        }

        private (int y, int x) GetIndexOfFirstEmptyPlace()
        {
            for (int i = 0; i < _items.GetLength(0); i++)
            {
                for (int j = 0; j < _items.GetLength(1); j++)
                {
                    if (_items[i, j] is null)
                    {
                        return (i, j);
                    }
                }
            }

            return (-1, -1);
        }
    }
}