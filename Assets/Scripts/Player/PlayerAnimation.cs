using UnityEngine;
using PlayerControl;

public class PlayerAnimation : MonoBehaviour
{
    // Handle player animation
    [SerializeField] private Transform _visual;
    private IPlayerController _player;
    private Animator _animator;

    private void Awake()
    {
        _animator = GetComponent<Animator>();
        _player = GetComponentInParent<IPlayerController>();
    }

    void Update()
    {
        if (_player == null) return;
        HandleSpriteFlip();
        HandleWalk();
    }

    private void HandleSpriteFlip()
    {
        if (_player.FrameInput.x != 0)
        {
            _visual.localScale = _player.FrameInput.x < 0 ? new Vector3(-1, 1, 1) : new Vector3(1, 1, 1);
        }
    }

    private void HandleWalk()
    {
        _animator.SetBool("Moving", _player.FrameInput.magnitude != 0);
    }
}
