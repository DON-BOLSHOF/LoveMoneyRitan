using UnityEditor;
using UnityEngine;
using Utils;

namespace Components
{
    [RequireComponent(typeof(Rigidbody2D))]
    [RequireComponent(typeof(Animator))]
    public class HeroComponent : MonoBehaviour //Вдальнейшем создай Creature и отнаследуй!
    {
        [Header("Checkers")] [SerializeField] private float _groundCheckRadious;
        [SerializeField] private LayerMask _groundLayer;
        [SerializeField] private Vector3 _groundCheckPositionDelta;

        [SerializeField] private float _runSpeed;
        [SerializeField] private float _jumpSpeed;

        [SerializeField] private bool _isInversed; // инверснут ли спрайт

        private static readonly int IsRunningKey = Animator.StringToHash("Is-Running");
        private static readonly int IsJumpingKey = Animator.StringToHash("Is-Jumping");
        private static readonly int IsFallingKey = Animator.StringToHash("Is-Falling");

        private Rigidbody2D _rigidbody;
        private Animator _animator;

        private Vector2 _direction;

        private bool IsJumping => _rigidbody.velocity.y>.7f; //Чтобы при 2-ом клике не улетал в космос
        private bool IsFalling => _rigidbody.velocity.y<-0.7f;
        private bool _isGround;

        private void Start()
        {
            _rigidbody = GetComponent<Rigidbody2D>();
            _animator = GetComponent<Animator>();
        }

        private void FixedUpdate()
        {
            _isGround = IsGrounded();

            Move();

            _animator.SetBool(IsRunningKey, _direction.x != 0);
            _animator.SetBool(IsJumpingKey,IsJumping);
            _animator.SetBool(IsFallingKey,IsFalling);
        }

        private void Move()
        {
            SubClasses.UpgradeSpriteDirection(_direction, transform, _isInversed);

            _rigidbody.velocity = new Vector2(_runSpeed * _direction.x, _rigidbody.velocity.y);
        }

        public void Jump()
        {
            if (IsGrounded() && !IsJumping)
            {
                _rigidbody.velocity = new Vector2(_rigidbody.velocity.x, _rigidbody.velocity.y + _jumpSpeed);
            }
        }

        public void SetDirection(Vector2 value)
        {
            _direction = value;
        }

        private bool IsGrounded()
        {
            var hit = Physics2D.CircleCast(transform.position + _groundCheckPositionDelta, _groundCheckRadious,
                Vector2.down, 0, _groundLayer);
            return hit.collider != null;
        }

#if UNITY_EDITOR
        private void OnDrawGizmos()
        {
            Handles.color = _isGround ? HandlesUtils.TransparentRed : HandlesUtils.TransparentGreen;
            Handles.DrawSolidDisc(transform.position + _groundCheckPositionDelta, Vector3.forward, _groundCheckRadious);
        }
#endif
    }
}