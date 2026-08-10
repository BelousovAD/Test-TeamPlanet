using Reflex.Core;
using UnityEngine;

namespace Items
{
    internal class ItemsInstaller : MonoBehaviour, IInstaller
    {
        [SerializeField][Min(1)] private int _fieldSizeX = 1;
        [SerializeField][Min(1)] private int _fieldSizeY = 1;
        [SerializeField] private ItemData _spawnerData;
        
        public void InstallBindings(ContainerBuilder builder)
        {
            Item[,] items = new Item[_fieldSizeY, _fieldSizeX];
            items[0, 0] = new Item(_spawnerData);

            builder.RegisterValue(new ItemArray(items));
        }
    }
}