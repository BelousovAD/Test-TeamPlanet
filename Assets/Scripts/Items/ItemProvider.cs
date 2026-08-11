using System;
using Reflex.Attributes;
using UnityEngine;

namespace Items
{
    public class ItemProvider : MonoBehaviour
    {
        [SerializeField][Min(0)] private int _indexX;
        [SerializeField][Min(0)] private int _indexY;
        
        private ItemArray _itemArray;
        private Item _item;

        public event Action ItemChanged;

        public Item Item
        {
            get => _item;
            private set
            {
                if (value != _item)
                {
                    _item = value;
                    ItemChanged?.Invoke();
                }
            }
        }

        [Inject]
        public void Initialize(ItemArray itemArray) =>
            _itemArray = itemArray;

        private void OnEnable()
        {
            _itemArray.ItemChanged += UpdateItem;
            Item = _itemArray[_indexY, _indexX];
        }

        private void OnDisable() =>
            _itemArray.ItemChanged -= UpdateItem;

        private void UpdateItem(int y = 0, int x = 0)
        {
            if (y == _indexY && x == _indexX)
            {
                Item = _itemArray[y, x];
            }
        }
    }
}