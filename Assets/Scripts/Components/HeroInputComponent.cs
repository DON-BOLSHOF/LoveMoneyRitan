using UnityEngine;
using UnityEngine.InputSystem;

namespace Components
{
    [RequireComponent(typeof(HeroComponent))]
    public class HeroInputComponent : MonoBehaviour
    {
        private HeroComponent _hero;

        private void Start()
        {
            _hero = GetComponent<HeroComponent>();
        }

        public void HorizontalMovement(InputAction.CallbackContext context)
        {
            var value = context.ReadValue<Vector2>();
            _hero.SetDirection(value);
        }

        public void Jump(InputAction.CallbackContext context)
        {
            _hero.Jump();
        }
    }
}