using UnityEngine;

namespace Items
{
    public class Item
    {
        private readonly ItemData _data;
        private int _state;
        private int _stateMax;

        public Item(ItemData data)
        {
            _data = data;
            _stateMax = _data.Sprites.Count - 1;
        }

        public Sprite Sprite => _data.Sprites[_state];
    }
}