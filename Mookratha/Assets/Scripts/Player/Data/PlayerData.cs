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

    [Header("Throw State")]
    public float throwForceXZ = 522;
    public float throwForceY = 100f;
    public float throwTime = 0.2f;
    public float holdBeforeThrow = 0.5f;
}
