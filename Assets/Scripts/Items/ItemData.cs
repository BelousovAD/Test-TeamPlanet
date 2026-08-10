using System.Collections.Generic;
using UnityEngine;

namespace Items
{
    [CreateAssetMenu(fileName = nameof(ItemData), menuName = nameof(Items) + nameof(ItemData))]
    public class ItemData : ScriptableObject
    {
        [SerializeField] private ItemType _type;
        [SerializeField] private List<Sprite> _sprites = new ();

        public ItemType Type => _type;

        public IReadOnlyList<Sprite> Sprites => _sprites;
    }
}