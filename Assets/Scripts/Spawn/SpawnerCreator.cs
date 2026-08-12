using Items;
using Reflex.Attributes;
using Timer;
using UnityEngine;

namespace Spawn
{
    internal class SpawnerCreator : MonoBehaviour
    {
        [SerializeField] private CoroutineTimer _timer;
        [SerializeField] private ItemType _type;

        private SpawnCaller _spawnCaller;

        [Inject]
        private void Initialize(SpawnCaller spawnCaller) =>
            _spawnCaller = spawnCaller;

        private void OnEnable() =>
            _timer.Finished += CreateSpawner;

        private void OnDisable() =>
            _timer.Finished -= CreateSpawner;

        private void CreateSpawner() =>
            _spawnCaller.Spawn(_type, true, 0);
    }
}