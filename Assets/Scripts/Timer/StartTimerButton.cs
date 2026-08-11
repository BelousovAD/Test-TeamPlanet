using UnityEngine;
using UnityEngine.UI;

namespace Timer
{
    [RequireComponent(typeof(Button))]
    internal class StartTimerButton : MonoBehaviour
    {
        [SerializeField] private CoroutineTimer _timer;

        private Button _button;

        private void Awake() =>
            _button = GetComponent<Button>();

        private void OnEnable() =>
            _button.onClick.AddListener(HandleClick);

        private void OnDisable() =>
            _button.onClick.RemoveListener(HandleClick);

        private void HandleClick() =>
            _timer.StartTimer();
    }
}