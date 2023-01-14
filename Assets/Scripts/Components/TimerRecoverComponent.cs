using UnityEngine;
using Utils;

namespace Components
{
    public class TimerRecoverComponent: MonoBehaviour
    {
        [SerializeField] private Timer _timer;

        public void RecoverTime(float value)
        {
            _timer.RecoverTime(value);
        } 
    }
}