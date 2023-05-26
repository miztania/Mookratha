using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FoodState : MonoBehaviour
{
    protected Food food;
    protected FoodStateMachine stateMachine;
    protected FoodData foodData;

    protected float startTime;

    private string animBoolName;

    public FoodState(Food food,FoodStateMachine stateMachine, FoodData foodData, float startTime, string animBoolName)
    {
        this.food = food;
        this.stateMachine = stateMachine;
        this.foodData = foodData;
        this.startTime = startTime;
        this.animBoolName = animBoolName;
    }

    public virtual void Enter()
    {
        DoCheck();
        startTime = Time.time;
        Debug.Log(animBoolName);
    }

    public virtual void Exit() { }
    public virtual void LogicUpdate() { }
    public virtual void PhysicsUpdate() 
    {
        DoCheck();
    }
    public virtual void DoCheck() { }
}   
