using UnityEngine;

namespace PlayerControl
{
    public class PlayerMovement : MonoBehaviour, IPlayerController
    {
        // Handle player movement
        [SerializeField] private float moveSpeed = 5f;
        private Rigidbody2D _rb;
        private FrameInput _frameInput;

        public Vector2 FrameInput => _frameInput.Move;

        private void Awake()
        {
            _rb = GetComponent<Rigidbody2D>();
        }

        private void Update()
        {
            GatherInput();
        }

        private void GatherInput()
        {
            _frameInput = new FrameInput
            {
                Move = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"))
            };
        }

        private void FixedUpdate()
        {
            _rb.MovePosition(_rb.position + _frameInput.Move.normalized * moveSpeed * Time.fixedDeltaTime);
        }
    }

    public struct FrameInput
    {
        public Vector2 Move;
    }

    public interface IPlayerController
    {
        public Vector2 FrameInput { get; }
    }
}
