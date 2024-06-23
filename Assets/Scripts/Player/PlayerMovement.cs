using UnityEngine;

namespace PlayerControl
{
    public class PlayerMovement : MonoBehaviour, IPlayerController
    {
        // Handle player movement
        [SerializeField] private float moveSpeed = 5f;
        private Rigidbody2D _rb;
        private FrameInput _frameInput;
        private bool _canMove = true;

        public Vector2 FrameInput => _frameInput.Move;

        private void Awake()
        {
            _rb = GetComponent<Rigidbody2D>();
        }
        private void Start()
        {
            GameManager.Instance.SetPlayer(gameObject);
        }
        private void OnEnable()
        {
            if (GameManager.Instance)
            {
                GameManager.Instance.movementChanged += onMoveChanged;
                GameManager.Instance.SetPlayer(gameObject);
            }
        }
        private void OnDisable()
        {
            GameManager.Instance.movementChanged -= onMoveChanged;
            GameManager.Instance.SetPlayer(null);
        }

        private void Update()
        {
            GatherInput();
        }

        private void GatherInput()
        {
            if (Input.GetButtonDown("Inventory"))
            {
                GameManager.Instance.ToggleInventory();
            }
            if (!_canMove)
            {
                _frameInput = new FrameInput
                {
                    Move = Vector2.zero
                };
                return;
            }
            _frameInput = new FrameInput
            {
                Move = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"))
            };
        }

        private void FixedUpdate()
        {
            if (!_canMove)
                return;
            _rb.MovePosition(_rb.position + _frameInput.Move.normalized * moveSpeed * Time.fixedDeltaTime);
        }

        private void onMoveChanged(bool canMove)
        {
            _canMove = canMove;
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
