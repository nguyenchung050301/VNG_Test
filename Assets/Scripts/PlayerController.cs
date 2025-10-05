using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{

    //Boundary
    [SerializeField] private Vector2 minBound;
    [SerializeField] private Vector2 maxBound;
    //

    //State Manager
    private StateManager stateManager;
    private ICharacterState idleState;
    private ICharacterState moveState;
    private ICharacterState attackState;
    private ICharacterState dieState;
    //

    private CharacterHealth characterHealth;
    [SerializeField] private PlayerController target;
    private SpriteRenderer spriteRenderer;
    private Animator animator;
    [SerializeField] private float speed;
    [SerializeField] private float gap; //maintain a gap between player and target

    //Attack
    [Header("Attack")]
    [SerializeField] private float attackRate;
    [SerializeField] private bool canAttack;
    [SerializeField] private bool isOnAttackAnimation;
    //
    private IEnumerator attackCoroutine;
    private void Awake()
    {
        isOnAttackAnimation = false;
        canAttack = true;

        stateManager = new StateManager();
        idleState = new IdleState(this);
        moveState = new MoveState(this);
        attackState = new AttackState(this);
        dieState = new DieState(this);

        spriteRenderer = GetComponent<SpriteRenderer>();
        animator = GetComponent<Animator>();
        characterHealth = GetComponent<CharacterHealth>();
    }
    // Start is called before the first frame update
    void Start()
    {
        stateManager.ChangeState(idleState);
    }

    // Update is called once per frame
    void Update()
    {
        stateManager.UpdateState();

        if (target.enabled)
        {
            if (Vector2.Distance(transform.position, target.transform.position) <= gap)
            {

                //Attack State Change

                if (canAttack && !isOnAttackAnimation)
                {
                    canAttack = false;
                    stateManager.ChangeState(attackState);
                    attackCoroutine = AttackCooldown(attackRate);
                    StartCoroutine(attackCoroutine);

                }

                //
            }
            else
            {

                //Move State Change

                if (stateManager.GetCurrentState() != moveState && !isOnAttackAnimation)
                {
                    stateManager.ChangeState(moveState);
                }

                //

             
            }
        }
        //

        //Idle State Change

        if (!target.enabled && stateManager.GetCurrentState() != idleState && !isOnAttackAnimation)
        {
            stateManager.ChangeState(idleState);
        }

        //


        //Die State Change
        if (characterHealth.GetCurrentHealth() <= 0 && stateManager.GetCurrentState() != dieState)
        {
            stateManager.ChangeState(dieState);
        }
        
    }
    private void FixedUpdate()
    {
        Vector2 clampedPos = new Vector2(
            Mathf.Clamp(transform.position.x, minBound.x, maxBound.x),
            Mathf.Clamp(transform.position.y, minBound.y, maxBound.y)
        );

        transform.position = clampedPos;
    }
    public IEnumerator AttackCooldown(float time)
    {
        yield return new WaitForSeconds(time);
        
        canAttack = true;

    }
    
    public void SetIsOnAttackAnimation_On()
    {
        isOnAttackAnimation = true;
    }
    public void SetIsOnAttackAnimation_Off()
    {
        isOnAttackAnimation = false;
        stateManager.ChangeState(idleState);
    }

    public IEnumerator PlayerDie(float value)
    {
        target.stateManager.ChangeState(idleState); //change target to idle state
        enabled = false; //self script

        yield return new WaitForSeconds(value);
       
        gameObject.SetActive(false);
    }


    public Animator GetAnimator() => animator;
    public float GetSpeed() => speed;
    public float GetGap() => gap;
    public PlayerController GetTarget () => target; 
    public SpriteRenderer GetSpriteRenderer() => spriteRenderer;
    public float GetAttackRate() => attackRate;
}
