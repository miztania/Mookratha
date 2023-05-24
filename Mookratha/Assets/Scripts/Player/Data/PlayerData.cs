using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu(fileName ="newPlayerData",menuName ="Data/Player Data/Base Data")]
public class PlayerData : ScriptableObject
{
    [Header("Move State")]
    public float movementSpeed = 10f;

    [Header("Dash State")]
    public float dashCoolDown = 0.2f;
    public float dashTime = 1f;
}
