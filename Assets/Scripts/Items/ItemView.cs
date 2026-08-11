using UnityEngine;
using UnityEngine.UI;

namespace Items
{
    [RequireComponent(typeof(Image))]
    internal class ItemView : MonoBehaviour
    {
        [SerializeField] private ItemProvider _provider;
        [SerializeField] private CanvasGroup _group;

        private Image _image;
        private Item _item;

        private void Awake() =>
            _image = GetComponent<Image>();

        private void OnEnable()
        {
            _provider.ItemChanged += UpdateSubscriptions;
            UpdateSubscriptions();
        }

        private void OnDisable()
        {
            _provider.ItemChanged -= UpdateSubscriptions;
            UpdateSubscriptions();
        }

        private void UpdateSubscriptions()
        {
            if (_item is not null)
            {
                Unsubscribe();
            }

            _item = _provider.Item;

            if (_item is not null)
            {
                Subscribe();
            }
            
            UpdateView();
        }

        private void Subscribe() =>
            _item.StateChanged += UpdateView;

        private void Unsubscribe() =>
            _item.StateChanged -= UpdateView;

        private void UpdateView()
        {
            _group.blocksRaycasts = _item is not null;
            _group.alpha = _item is not null ? 1f : 0f;
            _image.sprite = _item?.Sprite;
        }
    }
}