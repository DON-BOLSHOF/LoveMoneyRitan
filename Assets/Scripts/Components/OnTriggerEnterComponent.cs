using UnityEngine;
using UnityEngine.Events;

namespace Components
{
    public class OnTriggerEnterComponent: MonoBehaviour
    {
        [SerializeField] private UnityEvent _event;

        private void OnTriggerEnter2D(Collider2D col)
        {
            if (col.gameObject.CompareTag("Player"))
                _event?.Invoke();
        }
    }
}