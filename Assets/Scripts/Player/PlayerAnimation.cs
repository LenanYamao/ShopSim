using UnityEngine;
using PlayerControl;

public class PlayerAnimation : MonoBehaviour
{
    // Handle player animation
    // Add Y sorting if there's enough time.
    [SerializeField] private Transform _visual;
    private IPlayerController _player;
    private Animator _animator;

    #region Sprite Reference

    [Header("Head Reference")]
    [SerializeField] private SpriteRenderer face;
    [SerializeField] private SpriteRenderer hood;

    [Header("Chest Reference")]
    [SerializeField] private SpriteRenderer chest;
    [SerializeField] private SpriteRenderer shoulderL;
    [SerializeField] private SpriteRenderer shoulderR;
    [SerializeField] private SpriteRenderer pelvis;

    [Header("Arm Reference")]
    [SerializeField] private SpriteRenderer wristL;
    [SerializeField] private SpriteRenderer elbowL;
    [SerializeField] private SpriteRenderer wristR;
    [SerializeField] private SpriteRenderer elbowR;

    [Header("Leg Reference")]
    [SerializeField] private SpriteRenderer legL;
    [SerializeField] private SpriteRenderer bootL;
    [SerializeField] private SpriteRenderer legR;
    [SerializeField] private SpriteRenderer bootR;

    private Sprite faceDefault;
    private Sprite hoodDefault;
    private Sprite chestDefault;
    private Sprite shoulderLDefault;
    private Sprite shoulderRDefault;
    private Sprite pelvisDefault;
    private Sprite wristLDefault;
    private Sprite elbowLDefault;
    private Sprite wristRDefault;
    private Sprite elbowRDefault;
    private Sprite legLDefault;
    private Sprite bootLDefault;
    private Sprite legRDefault;
    private Sprite bootRDefault;
    #endregion

    private void Awake()
    {
        _animator = GetComponent<Animator>();
        _player = GetComponentInParent<IPlayerController>();

        SetDefaultVisual();
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

    private void SetDefaultVisual()
    {
        faceDefault = face.sprite;
        hoodDefault = hood.sprite;
        chestDefault = chest.sprite;
        shoulderLDefault = shoulderL.sprite;
        shoulderRDefault = shoulderR.sprite;
        pelvisDefault = pelvis.sprite;
        wristLDefault = wristL.sprite;
        elbowLDefault = elbowL.sprite;
        wristRDefault = wristR.sprite;
        elbowRDefault = elbowR.sprite;
        legLDefault = legL.sprite;
        bootLDefault = bootL.sprite;
        legRDefault = legR.sprite;
        bootRDefault = bootR.sprite;
    }

    private void ResetDefaultVisual(Slot slot)
    {
        switch (slot)
        {
            case Slot.Head:
                face.sprite = faceDefault;
                hood.sprite = hoodDefault;
                break;
            case Slot.Chest:
                chest.sprite = chestDefault;
                shoulderL.sprite = shoulderLDefault;
                shoulderR.sprite = shoulderRDefault;
                pelvis.sprite = pelvisDefault;
                break;
            case Slot.Arm:
                wristL.sprite = wristLDefault;
                elbowL.sprite = elbowLDefault;
                wristR.sprite = wristRDefault;
                elbowR.sprite = elbowRDefault;
                break;
            case Slot.Leg:
                legL.sprite = legLDefault;
                bootL.sprite = bootLDefault;
                legR.sprite = legRDefault;
                bootR.sprite = bootRDefault;
                break;
            default:
                break;
        }
    }

    public void ChangeVisual(Slot slot, Clothes clothe = null)
    {
        if (clothe == null)
        {
            ResetDefaultVisual(slot);
            return;
        }
        switch (slot)
        {
            case Slot.Head:
                face.sprite = clothe.face;
                hood.sprite = clothe.hood;
                break;
            case Slot.Chest:
                chest.sprite = clothe.chest;
                shoulderL.sprite = clothe.shoulderL;
                shoulderR.sprite = clothe.shoulderR;
                pelvis.sprite = clothe.pelvis;
                break;
            case Slot.Arm:
                wristL.sprite = clothe.wristL;
                elbowL.sprite = clothe.elbowL;
                wristR.sprite = clothe.wristR;
                elbowR.sprite = clothe.elbowR;
                break;
            case Slot.Leg:
                legL.sprite = clothe.legL;
                bootL.sprite = clothe.bootL;
                legR.sprite = clothe.legR;
                bootR.sprite = clothe.bootR;
                break;
            case Slot.None:
                break;
        }
    }
}
