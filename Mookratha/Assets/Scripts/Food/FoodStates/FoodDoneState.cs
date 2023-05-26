using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FoodDoneState : FoodState
{
    public FoodDoneState(Food food, FoodStateMachine stateMachine, FoodData foodData, float startTime, string animBoolName) : base(food, stateMachine, foodData, startTime, animBoolName)
    {
    }
}
