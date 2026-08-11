using System;
using UnityEngine;

namespace Items
{
    public class Item
    {
        private readonly ItemData _data;
        private readonly int _stateMax;
        private int _state;

        public Item(ItemData data, int state = 0)
        {
            _data = data;
            _stateMax = _data.Sprites.Count - 1;

            if (state < 0)
            {
                throw new ArgumentOutOfRangeException(nameof(state), "Must be non-negative");
            }

            if (state > _stateMax)
            {
                throw new ArgumentOutOfRangeException(nameof(state), $"Must be less than Max:{_stateMax}");
            }

            _state = state;
        }

        public event Action StateChanged;

        public ItemType Type => _data.Type;

        public bool IsSpawner => _data.IsSpawner;

        public int State
        {
            get => _state;
            private set
            {
                if (value != _state)
                {
                    _state = value;
                    StateChanged?.Invoke();
                }
            }
        }

        public Sprite Sprite => _data.Sprites[_state];

        public bool Upgrade()
        {
            if (_state < _stateMax)
            {
                State += 1;

                return true;
            }

            return false;
        }
    }
}