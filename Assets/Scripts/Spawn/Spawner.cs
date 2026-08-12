using System;
using Items;
using UnityEngine;

namespace Spawn
{
    internal class Spawner
    {
        private readonly SpawnerData _data;
        private ItemArray _itemArray;

        public Spawner(SpawnerData data) =>
            _data = data;

        public ItemType Type => _data.Type;

        public bool IsSpawnerItem => _data.ItemData.IsSpawner;

        public void Initialize(ItemArray itemArray) =>
            _itemArray = itemArray;

        public void Spawn(int spawnerState)
        {
            if (spawnerState < 0)
            {
                throw new ArgumentOutOfRangeException(nameof(spawnerState), "Must be non-negative");
            }

            ChanceData chance = _data.Chances[spawnerState];
            int state = UnityEngine.Random.value > chance.Value ? chance.RightState : chance.LeftState;

            if (_itemArray.TryAddItem(new Item(_data.ItemData, state)) == false)
            {
                Debug.Log("Area is full");
            }
        }
    }
}