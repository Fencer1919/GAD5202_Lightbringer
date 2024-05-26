using System;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    public static PlayerController Instance;

    public PlayerHealth playerHealth;
    public Rigidbody2D rb;
    public Collider2D hurtBox;

    private bool isWalking;
    private bool isDodging;
    private bool isAttacking;

    private bool isAttributeTab;

    public bool meleeAttackInput;
    public bool rangedAttackInput;

    [Header("Oath")]
    [SerializeField] public OathTracker oathTracker;

    [Header("Component")]
    [SerializeField] private Animator anim;
    [SerializeField] GameObject playerWeapon;

    [Header("Movement")]
    [HideInInspector] public Vector2 movementVector;
    [SerializeField] private float movementSpeed;

    [Header("Attack")]
    public GameObject rangedAttackObject;


    private IState currentState;
    [Header("Input")]
    [SerializeField] private PlayerInputAction playerInputAction;
    [SerializeField] private PlayerInput playerInput;


    public static event Action onToggleAttributeTab;

    //Properties
    public bool IsWalking { get => isWalking; set => isWalking = value; }
    public bool IsDodging { get => isDodging; set => isDodging = value; }
    public bool IsAttacking { get => isAttacking; set => isAttacking = value; }
    public float MovementSpeed { get => movementSpeed; set => movementSpeed = value; }
    public GameObject PlayerWeapon { get => playerWeapon; set => playerWeapon = value; }
    public Animator Anim { get => anim; set => anim = value; }
    public Vector2 MovementVector { get => movementVector; set => movementVector = value; }
    public bool IsAttributeTab { get => isAttributeTab; set => isAttributeTab = value; }

    private void Awake()
    {
        if (Instance == null)
            Instance = this;
        else
            Destroy(gameObject);

        playerInputAction = new PlayerInputAction();
        playerInputAction.Enable();

        playerInputAction.Gameplay.Movement.performed += Movement;
        playerInputAction.Gameplay.Movement.canceled += Movement;

        playerInputAction.Gameplay.Dodge.performed += Dodge;
        playerInputAction.Gameplay.Dodge.canceled += Dodge;

        playerInputAction.Gameplay.MeleeAttack.performed += MeleeAttack;
        playerInputAction.Gameplay.MeleeAttack.canceled += MeleeAttack;

        playerInputAction.Gameplay.RangedAttack.performed += RangedAttack;
        playerInputAction.Gameplay.RangedAttack.canceled += RangedAttack;

        playerInputAction.Gameplay.AttributeTab.started += AttributeTab;
    }

    void OnDisable()
    {
        playerInputAction.Gameplay.Movement.performed -= Movement;
        playerInputAction.Gameplay.Movement.canceled -= Movement;

        playerInputAction.Gameplay.Dodge.performed -= Dodge;
        playerInputAction.Gameplay.Dodge.canceled -= Dodge;

        playerInputAction.Gameplay.MeleeAttack.performed -= MeleeAttack;
        playerInputAction.Gameplay.MeleeAttack.canceled -= MeleeAttack;

        playerInputAction.Gameplay.RangedAttack.performed -= RangedAttack;
        playerInputAction.Gameplay.RangedAttack.canceled -= RangedAttack;

        playerInputAction.Gameplay.AttributeTab.started -= AttributeTab;
    }

    void Start()
    {
        currentState = new IdleState();
        currentState.EnterState(this);

        Anim.SetFloat("attackSpeed", new AttackState().attackRate);
    }
    
    void Update()
    {
        currentState.UpdateState(this);
    }

    public void ChangeState(IState newState)
    {
        currentState.ExitState(this);
        currentState = newState;
        currentState.EnterState(this);
    }
    public void HandleMovement()
    {        
        transform.Translate(Time.deltaTime * MovementVector * MovementSpeed);
    }
    private void Movement(InputAction.CallbackContext context)
    {
        isWalking = context.performed ? true : false;        
        
        MovementVector = context.ReadValue<Vector2>();
    }
    private void Dodge(InputAction.CallbackContext context)
    {
        IsDodging = true;
    }
    private void MeleeAttack(InputAction.CallbackContext context)
    {
        meleeAttackInput = context.ReadValueAsButton();

        if (context.performed)
        {
            IsAttacking = true;
        }
    }
    private void RangedAttack(InputAction.CallbackContext context)
    {
        rangedAttackInput = context.ReadValueAsButton();

        if (context.performed)
        {
            IsAttacking = true;
        }
    }

    private void AttributeTab(InputAction.CallbackContext context)
    {
        if (IsAttributeTab)
        {
            IsAttributeTab = false;
        }
        else
        {
            IsAttributeTab = true;
        }

        onToggleAttributeTab?.Invoke();
    }

    public void HandleAttackCooldown()
    {
        if (meleeAttackInput) { return; }

        IsAttacking = false;
    }
    public void HandleRangedAttackCooldown()
    {
        if (rangedAttackInput) { return; }

        Debug.Log("rangedattackcooldown");

        IsAttacking = false;
    }

}
