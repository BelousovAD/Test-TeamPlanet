using System.Collections.Generic;
using Items;

namespace Spawn
{
    internal class SpawnCaller
    {
        private readonly Dictionary<ItemType, Spawner> _itemSpawners = new ();
        private readonly Dictionary<ItemType, Spawner> _spawnerSpawners = new ();

        public SpawnCaller(IEnumerable<Spawner> spawners)
        {
            foreach (Spawner spawner in spawners)
            {
                if (spawner.IsSpawnerItem)
                {
                    _spawnerSpawners.Add(spawner.Type, spawner);
                }
                else
                {
                    _itemSpawners.Add(spawner.Type, spawner);
                }
            }
        }
        
        public void Spawn(ItemType type, bool isSpawner, int spawnerState)
        {
            if (isSpawner)
            {
                _spawnerSpawners[type].Spawn(spawnerState);
            }
            else
            {
                _itemSpawners[type].Spawn(spawnerState);
            }
        }
    }
}