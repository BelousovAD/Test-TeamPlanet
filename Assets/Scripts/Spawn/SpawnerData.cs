using System.Collections.Generic;
using Items;
using UnityEngine;

namespace Spawn
{
    [CreateAssetMenu(fileName = nameof(SpawnerData), menuName = nameof(Spawn) + "/" + nameof(SpawnerData))]
    internal class SpawnerData : ScriptableObject
    {
        [SerializeField] private ItemType _type;
        [SerializeField] private ItemData _itemData;
        [SerializeField] private List<ChanceData> _chances;

        public ItemType Type => _type;
        
        public ItemData ItemData => _itemData;

        public IReadOnlyList<ChanceData> Chances => _chances;
    }
}