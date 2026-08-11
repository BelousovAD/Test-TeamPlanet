using Items;
using Reflex.Attributes;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

namespace DragAndDrop
{
    public class DraggableItem : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler
    {
        [SerializeField] private ItemProvider _itemProvider;

        private Canvas _canvas;
        private RectTransform _rectTransform;
        private Transform _defaultParent;
        private Image _image;
        private ItemArray _itemArray;

        [Inject]
        private void Initialize(ItemArray itemArray) =>
            _itemArray = itemArray;

        private void Awake()
        {
            _canvas = GetComponentInParent<Canvas>();
            _rectTransform = transform as RectTransform;
            _defaultParent = _rectTransform!.parent;
            _image = GetComponent<Image>();
        }

        public void OnBeginDrag(PointerEventData eventData)
        {
            _image.raycastTarget = false;
            _rectTransform.SetParent(_canvas.transform);
            _rectTransform.SetAsLastSibling();
        }

        public void OnDrag(PointerEventData eventData)
            => _rectTransform.anchoredPosition += eventData.delta / _canvas.scaleFactor;

        public void OnEndDrag(PointerEventData eventData)
        {
            _rectTransform.SetParent(_defaultParent);
            _rectTransform.SetAsFirstSibling();
            _rectTransform.anchoredPosition = Vector2.zero;
            _image.raycastTarget = true;

            RaycastResult raycast = eventData.pointerCurrentRaycast;
            ItemProvider itemProvider = raycast.gameObject?.GetComponentInParent<ItemProvider>();
            
            if (itemProvider is not null)
            {
                _itemArray.Merge(_itemProvider.Index, itemProvider.Index);
            }
        }
    }
}