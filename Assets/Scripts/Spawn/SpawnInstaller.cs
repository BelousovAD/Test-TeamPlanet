using System.Collections.Generic;
using System.Linq;
using Items;
using Reflex.Core;
using UnityEngine;

namespace Spawn
{
    internal class SpawnInstaller : MonoBehaviour, IInstaller
    {
        [SerializeField] private List<SpawnerData> _spawnerDatas;

        private readonly List<Spawner> _spawners = new ();
        private ContainerBuilder _builder;
        
        public void InstallBindings(ContainerBuilder builder)
        {
            _builder = builder;
            _builder.OnContainerBuilt += Initialize;
            
            _spawners.AddRange(_spawnerDatas.Select(data => new Spawner(data)));
            
            builder.RegisterValue(new SpawnCaller(_spawners));
        }

        private void Initialize(Container container)
        {
            _builder.OnContainerBuilt -= Initialize;

            ItemArray itemArray = container.Resolve<ItemArray>();

            foreach (Spawner spawner in _spawners)
            {
                spawner.Initialize(itemArray);
            }
        }
    }
}