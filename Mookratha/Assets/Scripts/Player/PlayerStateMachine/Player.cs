using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using static UnityEditor.Progress;

public class Player : MonoBehaviour
{
    public PlayerStateMachine StateMachine { get; private set; }

    public PlayerIdleState IdleState { get; private set; }
    public PlayerMoveState MoveState { get; private set; }  
    public PlayerDashState DashState { get; private set; }
    public PlayerHoldingState HoldingState { get; private set; }
    public PlayerHoldStillState HoldStillState { get; private set; }
    public PlayerThrowState ThrowState { get; private set; }


    public Animator Anim { get; private set; }
    public PlayerInputHandler InputHandler { get; private set; }
    public Rigidbody RB { get;private set; }

    public bool isDashing { get; private set; }
    public bool isCanHold { get; private set; }
    public bool isHolding { get; private set; }
    public bool isCanThrow { get; private set; }
    public Vector3 facingDirection;

    public GameObject item;
    public Rigidbody itemRigibody;
    public GameObject holdPosition;
    public GameObject playerPrefab;
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
        HoldStillState = new PlayerHoldStillState(this, StateMachine, playerData, "holdStill");
        ThrowState = new PlayerThrowState(this, StateMachine, playerData, "throw");
    }

    private void Start()
    {
        Anim = GetComponent<Animator>();
        InputHandler = GetComponent<PlayerInputHandler>();
        RB = GetComponent<Rigidbody>();

        isCanHold = false;
        isHolding = false;
        isCanThrow= false;

       




        StateMachine.Initialize(IdleState);
    }

    private void Update()
    { 
        
       
        StateMachine.CurrentState.LogicUpdate();
        CheckFacingDirection();
        /*
        if(Input.GetKeyDown(KeyCode.Space)) 
        {
            Throw();
        }
        */



    }

    private void FixedUpdate()
    {
        StateMachine.CurrentState.PhysicsUpdate();
    }

    public void SetVeclocity(float velocity)
    {
      

    }

    public void SetIsDash(bool b) => isDashing = b;
    public void SetIsCanThrow(bool b) => isCanThrow = b;



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

    public void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject.tag == "food")
        {
            item = null;
            itemRigibody = null;
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

    public void Throw()
    {
       
        itemRigibody = item.AddComponent<Rigidbody>();
      
        itemRigibody.AddForce(playerData.throwForceXZ*facingDirection.x,playerData.throwForceY, playerData.throwForceXZ* facingDirection.z);
 
        item.transform.parent = null;
        itemRigibody.mass = 1000;
        isHolding = false;
        SetIsCanThrow(false);
    }


    public void CheckFacingDirection()
    {
        if (InputHandler.NormInputX == 1)
        {
            facingDirection.x = 1;
        }
        else if(InputHandler.NormInputX == -1)
        {
            facingDirection.x = -1;
        }
        else if (InputHandler.NormInputY == 1)
        {
            facingDirection.z = 1;
        }
        else if (InputHandler.NormInputY == -1)
        {
            facingDirection.z = -1;
        }
    }

}
