using Items;
using Reflex.Attributes;
using UnityEngine;
using UnityEngine.EventSystems;

namespace Spawn
{
    internal class SpawnButton : MonoBehaviour, IPointerClickHandler
    {
        [SerializeField] private ItemProvider _itemProvider;

        private SpawnCaller _spawnCaller;

        [Inject]
        private void Initialize(SpawnCaller spawnCaller) =>
            _spawnCaller = spawnCaller;

        public void OnPointerClick(PointerEventData eventData)
        {
            Item item = _itemProvider.Item;
            
            if (item is not null && item.IsSpawner)
            {
                _spawnCaller.Spawn(item.Type, item.State);
            }
        }
    }
}