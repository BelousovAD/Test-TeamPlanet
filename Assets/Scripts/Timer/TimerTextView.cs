using UnityEngine;
using UnityEngine.UI;

namespace Timer
{
    [RequireComponent(typeof(Text))]
    internal class TimerTextView : MonoBehaviour
    {
        private const int Min2Sec = 60;

        [SerializeField] private string _format = "{0:D2}:{1:D2}";
        [SerializeField] private CoroutineTimer _timer;

        private Text _textField;

        private void Awake() =>
            _textField = GetComponent<Text>();

        private void OnEnable()
        {
            _timer.TimeChanged += UpdateView;
            UpdateView();
        }

        private void OnDisable() =>
            _timer.TimeChanged -= UpdateView;

        private void UpdateView()
        {
            int minutes = _timer.Time / Min2Sec;
            int seconds = _timer.Time % Min2Sec;
            _textField.text = string.Format(_format, minutes, seconds);
        }
    }
}