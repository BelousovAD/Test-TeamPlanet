using System;
using System.Collections;
using UnityEngine;

namespace Timer
{
    public class CoroutineTimer : MonoBehaviour
    {
        public const int Min = 0;
        private const int Second = 1;
        private readonly WaitForSeconds _delay = new (Second);

        [SerializeField][Min(0)] private int _startTime;
        
        private Coroutine _coroutine;
        private int _time;

        public event Action TimeChanged;
        public event Action Finished;

        public int Time
        {
            get => _time;

            private set
            {
                if (value != _time)
                {
                    _time = Mathf.Max(value, Min);
                    TimeChanged?.Invoke();
                }
            }
        }

        public void StartTimer()
        {
            StopTimer();
            Time = _startTime;
            _coroutine = StartCoroutine(Countdown());
        }

        private void StopTimer()
        {
            if (_coroutine is not null)
            {
                StopCoroutine(_coroutine);
                _coroutine = null;
            }
            
            Time = Min;
        }

        private IEnumerator Countdown()
        {
            while (Time > Min)
            {
                yield return _delay;

                Time--;
            }

            _coroutine = null;
            Finished?.Invoke();
        }
    }
}