using System.Collections;
using UnityEngine;

namespace Utils
{
    public class Timer : MonoBehaviour
    {
        [SerializeField] private float _valueToCome;
        private ObservableProperty<float> _currentTimeValue = new ObservableProperty<float>();

        public float ValueToCome => _valueToCome;
        public ObservableProperty<float> CurrentTime => _currentTimeValue;
        public bool IsOver => _currentTimeValue.Value >= _valueToCome;

        private Coroutine _coroutine;

        public void StartTimer()
        {
            _coroutine = StartCoroutine(StartTime());
        }

        public void RecoverTime(float value)
        {
            _currentTimeValue.Value = _currentTimeValue.Value - value < 0 ? 0 : _currentTimeValue.Value - value;
        }

        private IEnumerator StartTime()
        {
            while (_valueToCome > _currentTimeValue.Value)
            {
                _currentTimeValue.Value += Time.deltaTime;
                yield return null;
            }

            StopCoroutine(_coroutine);
        }
    }
}