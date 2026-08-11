using UnityEngine;

namespace Timer
{
    internal class StartTimerButtonView : MonoBehaviour
    {
        [SerializeField] private CanvasGroup _group;
        [SerializeField] private CoroutineTimer _timer;

        private void OnEnable()
        {
            _timer.TimeChanged += UpdateView;
            UpdateView();
        }

        private void OnDisable() =>
            _timer.TimeChanged -= UpdateView;

        private void UpdateView() =>
            _group.interactable = _timer.Time <= CoroutineTimer.Min;
    }
}