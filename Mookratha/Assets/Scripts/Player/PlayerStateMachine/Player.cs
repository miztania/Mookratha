using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public PlayerStateMachine StateMachine { get; private set; }

    public PlayerIdleState IdleState { get; private set; }
    public PlayerMoveState MoveState { get; private set; }  
    public PlayerDashState DashState { get; private set; }


    public Animator Anim { get; private set; }
    public PlayerInputHandler InputHandler { get; private set; }
    public Rigidbody RB { get;private set; }

    public bool isDashing { get; private set; }

    [SerializeField]
    private PlayerData playerData;

    private Vector3 workSpace;


    private void Awake()
    {
        StateMachine = new PlayerStateMachine();

        IdleState = new PlayerIdleState(this,StateMachine,playerData,"idle");
        MoveState = new PlayerMoveState(this, StateMachine, playerData, "move");
        DashState = new PlayerDashState(this, StateMachine, playerData, "dash");

    }

    private void Start()
    {
        Anim = GetComponent<Animator>();
        InputHandler = GetComponent<PlayerInputHandler>();
        RB = GetComponent<Rigidbody>();

        StateMachine.Initialize(IdleState);
    }

    private void Update()
    { 
       
        StateMachine.CurrentState.LogicUpdate();
     
       

    }

    private void FixedUpdate()
    {
        StateMachine.CurrentState.PhysicsUpdate();
    }

    public void SetVeclocity(float velocity)
    {
      

    }

    public void SetIsDash(bool b) => isDashing = b;

     void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "player")
        {
            Debug.Log("Hit player");
        }
    }

}
