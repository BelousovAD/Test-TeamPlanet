using UnityEngine;
using UnityEngine.UI;

namespace Items
{
    [RequireComponent(typeof(Image))]
    internal class ItemView : MonoBehaviour
    {
        private readonly Color Transparency = new (1f, 1f, 1f, 0f);
        
        [SerializeField] private ItemProvider _provider;

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
            _image.sprite = _provider.Item?.Sprite;
            _image.color = _provider.Item is null ? Transparency : Color.white;
        }
    }
}