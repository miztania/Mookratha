using System.Collections;
using System.Collections.Generic;
using System.Xml.Serialization;
using UnityEngine;

public class Food : MonoBehaviour
{
    public FoodStateMachine StateMachine { get; private set; }

    private void Awake()
    {
        StateMachine = new FoodStateMachine();
    }

    private void Start()
    {
        
    }

    private void Update()
    {
        
    }

    private void FixedUpdate()
    {
        
    }
}
