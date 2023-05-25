using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public PlayerStateMachine StateMachine { get; private set; }

    public PlayerIdleState IdleState { get; private set; }
    public PlayerMoveState MoveState { get; private set; }  
    public PlayerDashState DashState { get; private set; }
    public PlayerHoldingState HoldingState { get; private set; }


    public Animator Anim { get; private set; }
    public PlayerInputHandler InputHandler { get; private set; }
    public Rigidbody RB { get;private set; }

    public bool isDashing { get; private set; }
    public bool isCanHold { get; private set; }
    public bool isHolding { get; private set; }

    public GameObject item;
    public Rigidbody itemRigibody;
    public GameObject holdPosition;

    [SerializeField]
    private PlayerData playerData;

    private Vector3 workSpace;


    private void Awake()
    {
        StateMachine = new PlayerStateMachine();

        IdleState = new PlayerIdleState(this,StateMachine,playerData,"idle");
        MoveState = new PlayerMoveState(this, StateMachine, playerData, "move");
        DashState = new PlayerDashState(this, StateMachine, playerData, "dash");
        HoldingState = new PlayerHoldingState(this, StateMachine, playerData, "hold");
    }

    private void Start()
    {
        Anim = GetComponent<Animator>();
        InputHandler = GetComponent<PlayerInputHandler>();
        RB = GetComponent<Rigidbody>();

        isCanHold = false;
        isHolding = false;

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



    public void OnCollisionStay(Collision collision)
    {
       

        if (collision.gameObject.tag == "food")
        {
           // Debug.Log("Hit Food");
            item = collision.gameObject;
            itemRigibody = collision.rigidbody;
            isCanHold= true;
            
           // PickUp();
        }
    }

    private void OnCollisionExit(Collision collision)
    {

        if (collision.gameObject.tag == "food")
        {
         
            isCanHold = false;

            // PickUp();
        }
    }


    public void PickUp()
    {
        if (!isHolding)
        {
            item.transform.position += new Vector3(0, 0.8f, 0);
            item.transform.SetParent(this.transform);



            Destroy(itemRigibody);
        }
        // item.transform.localPosition = Vector3.MoveTowards(item.transform.position, holdPosition.transform.position, 0.1f);
        // item.transform.position = holdPosition.transform.position;
        //item.transform.localRotation = holdPosition.transform.localRotation;
    
      
    }

    public void SetIsHolding(bool b) => isHolding = b;


}
