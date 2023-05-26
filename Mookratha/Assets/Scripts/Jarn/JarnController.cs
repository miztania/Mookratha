using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JarnController : MonoBehaviour
{
    public float MaxHealth = 100;
    public float currentHealth = 0;

    public float currentPoint = 0;

    public HealthBar healthBar;

    private void Start()
    {
        currentHealth = MaxHealth;
        healthBar.SetMaxHealth((int)MaxHealth);
    }

    private void Update()
    {
        healthBar.SetHealth((int)currentHealth);
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "food")
        {
            currentHealth -= 10;
        }
    }



}
