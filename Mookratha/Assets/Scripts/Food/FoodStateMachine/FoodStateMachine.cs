using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FoodStateMachine 
{
    public FoodState CurrentState { get; private set; }

    public void Initialize(FoodState startingState)
    {
        CurrentState = startingState;
        CurrentState.Enter();
    }

    public void ChangeState(FoodState newState)
    {
        CurrentState.Exit();
        CurrentState = newState;
        CurrentState.Enter();
    }
}
