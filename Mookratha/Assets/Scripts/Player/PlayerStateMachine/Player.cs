using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
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
    public PlayerGetHitState GetHitState { get; private set; }


    public Animator Anim { get; private set; }
    public PlayerInputHandler InputHandler { get; private set; }
    public Rigidbody RB { get; private set; }
    public Transform respawndPos;
    public GameObject HitBox;

    public bool isDashing { get; private set; }
    public bool isCanHold { get; private set; }
    public bool isHolding { get; private set; }
    public bool isCanThrow { get; private set; }
    public bool isGetingHit { get; private set; }
    public bool isCanGetHit { get; private set; }


    public Vector3 facingDirection;

    public GameObject item;
    public Rigidbody itemRigibody;
    public GameObject holdPosition;
    public GameObject playerPrefab;
    [SerializeField]
    private PlayerData playerData;

    private Vector3 workSpace;

    public float finishThrowTime;
    public float holdDelayAfterThrow = 0.5f;

    private void Awake()
    {
        StateMachine = new PlayerStateMachine();

        IdleState = new PlayerIdleState(this, StateMachine, playerData, "idle");
        MoveState = new PlayerMoveState(this, StateMachine, playerData, "move");
        DashState = new PlayerDashState(this, StateMachine, playerData, "dash");
        HoldingState = new PlayerHoldingState(this, StateMachine, playerData, "hold");
        HoldStillState = new PlayerHoldStillState(this, StateMachine, playerData, "holdStill");
        ThrowState = new PlayerThrowState(this, StateMachine, playerData, "throw");
        GetHitState = new PlayerGetHitState(this, StateMachine, playerData, "fall");
    }

    private void Start()
    {
        Anim = GetComponent<Animator>();
        InputHandler = GetComponent<PlayerInputHandler>();
        RB = GetComponent<Rigidbody>();


        isCanHold = false;
        isHolding = false;
        isCanThrow = false;


        isCanGetHit = true;
        isGetingHit = false;






        StateMachine.Initialize(IdleState);
    }

    private void Update()
    {

       // Debug.Log("isCanHold :" + isCanHold);

        if (this.transform.position.y <= -20)
        {
            Respawn();
        }


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
    public void SetIsCanThrow(bool b) => isCanThrow = b;
    public void SetIsCanHold(bool b) => isCanHold = b;
    public void SetFinishedThrowTime(float f) => finishThrowTime = f;


    public void OnCollisionStay(Collision collision)
    {

        if (!isHolding)
        {
            if (collision.gameObject.tag == "food")
            {
                // Debug.Log("Hit Food");

                item = collision.gameObject;
                itemRigibody = collision.rigidbody;
                isCanHold = true;
            }
        }



    }

    public void OnCollisionExit(Collision collision)
    {
        if (!isHolding)
        {
            if (collision.gameObject.tag == "food")
            {
                item = null;
                itemRigibody = null;
                isCanHold = false;

                // PickUp();
            }
        }



    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "dead zone")
        {
            Respawn();
        }

        if (other.gameObject.tag == "hitbox")
        {
            Debug.Log("HIT");
            SetIsGettingHit(true);
        }

       

    }

    private void OnTriggerStay(Collider other)
    {

        if (other.gameObject.tag == "hitbox")
        {
            Debug.Log("Boom");
            SetIsGettingHit(true);
        }

       
    }

    private void Respawn()
    {
        Debug.Log("Respawn Called");

        if (isHolding)
        {
            item.transform.parent = null;
            Destroy(item.gameObject);
            isHolding = false;
            SetIsCanThrow(false);
        }


        transform.position = respawndPos.position;

        StateMachine.ChangeState(this.IdleState);

    }






    public void PickUp()
    {
        if (!isHolding && isCanHold)
        {
            if (item.gameObject.tag == "food")
            {
                item.gameObject.tag = "foodUnholdable";
                item.gameObject.layer = LayerMask.NameToLayer("FoodUnholdable");
                item.transform.position += new Vector3(0, 0.8f, 0);
                item.transform.SetParent(this.transform);
                Destroy(itemRigibody);
            }
        }


        // item.transform.localPosition = Vector3.MoveTowards(item.transform.position, holdPosition.transform.position, 0.1f);
        // item.transform.position = holdPosition.transform.position;
        //item.transform.localRotation = holdPosition.transform.localRotation;


    }

    public void SetIsHolding(bool b) => isHolding = b;

    public void Throw()
    {
        if (isCanThrow && isHolding  )
        {
            item.gameObject.tag = "food";
            item.gameObject.layer = LayerMask.NameToLayer("Food");
            itemRigibody = item.AddComponent<Rigidbody>();

            itemRigibody.AddForce(playerData.throwForceXZ * this.transform.forward.x, playerData.throwForceY, playerData.throwForceXZ * this.transform.forward.z);

            item.transform.parent = null;
            itemRigibody.mass = 1000;
            isHolding = false;
            SetIsCanThrow(false);

        }
       
 
     
    }

    public void Drop()
    {
        if (isHolding)
        {
            item.gameObject.tag = "food";
            item.gameObject.layer = LayerMask.NameToLayer("Food");
            itemRigibody = item.AddComponent<Rigidbody>();
            item.transform.parent = null;
            itemRigibody.mass = 1000;
            isHolding = false;
            SetIsCanThrow(false);
        }
    }

    public void Hit()
    {
        Debug.Log("Hit recived");
        SetIsGettingHit(true);
    }
        


    public void HitBoxActive()
    {
        HitBox.SetActive(true);
    }

    public void HitBoxUnActive() { HitBox.SetActive(false); }

    public void SetIsGettingHit(bool b) => isGetingHit= b;
    public void SetIsCanGetHit(bool b) => isCanGetHit= b;

    public void SetAbilityDone()
    {
        GetHitState.SetIsAbilityDone(true);
    }
}
