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

        private void Awake() =>
            _image = GetComponent<Image>();

        private void OnEnable()
        {
            _provider.ItemChanged += UpdateView;
            UpdateView();
        }

        private void OnDisable() =>
            _provider.ItemChanged -= UpdateView;

        private void UpdateView()
        {
            _group.blocksRaycasts = _provider.Item is not null;
            _group.alpha = _provider.Item is not null ? 1f : 0f;
            _image.sprite = _provider.Item?.Sprite;
        }
    }
}