using UnityEngine;
using UnityEngine.UI;
using Utils;

namespace Widgets
{
    public class TimerScrollWidget : MonoBehaviour
    {
        [SerializeField] private Image _bar;

        private Timer _timer;

        private void Start()
        {
            _timer = FindObjectOfType<GameSession>().Timer;

            _timer.CurrentTime.OnChanged += ChangeBar;
        }

        private void ChangeBar(float value)
        {
            _bar.fillAmount = 1 - value / _timer.ValueToCome < 0 ? 0 : 1 - value / _timer.ValueToCome;
        }
    }
}