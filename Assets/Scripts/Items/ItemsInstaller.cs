using System;
using Reflex.Core;
using UnityEngine;

namespace Items
{
    internal class ItemsInstaller : MonoBehaviour, IInstaller
    {
        [SerializeField][Min(1)] private int _fieldSizeX = 1;
        [SerializeField][Min(1)] private int _fieldSizeY = 1;
        [SerializeField] private ItemData _spawnerData;
        [SerializeField][Min(0)] private int _spawnerIndexX;
        [SerializeField][Min(0)] private int _spawnerIndexY;
        
        public void InstallBindings(ContainerBuilder builder)
        {
            Item[,] items = new Item[_fieldSizeY, _fieldSizeX];
            items[_spawnerIndexY, _spawnerIndexX] = new Item(_spawnerData);

            builder.RegisterValue(new ItemArray(items));
        }

        private void OnValidate()
        {
            _spawnerIndexX = Mathf.Min(_spawnerIndexX, _fieldSizeX - 1);
            _spawnerIndexY = Mathf.Min(_spawnerIndexY, _fieldSizeY - 1);
        }
    }
}