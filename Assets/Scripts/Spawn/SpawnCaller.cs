using System.Collections.Generic;
using Items;

namespace Spawn
{
    internal class SpawnCaller
    {
        private readonly Dictionary<ItemType, Spawner> _spawners = new ();

        public SpawnCaller(IEnumerable<Spawner> spawners)
        {
            foreach (Spawner spawner in spawners)
            {
                _spawners.Add(spawner.Type, spawner);
            }
        }
        
        public void Spawn(ItemType type, int spawnerState) =>
            _spawners[type].Spawn(spawnerState);
    }
}