using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class JarnController : MonoBehaviour
{
    public float MaxHealth = 100;
    public float currentHealth = 0;

   

    public Text pointText;
    public float currentPoint = 0;

    public HealthBar healthBar;

    private void Start()
    {
        currentHealth = MaxHealth;
        healthBar.SetMaxHealth((int)MaxHealth);
    }

    private void Update()
    {
        pointText.text = currentPoint.ToString();
        healthBar.SetHealth((int)currentHealth);


        if(currentHealth >= MaxHealth)
        {
            currentHealth = MaxHealth;
        }
    }


    /*
    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "food")
        {
            currentHealth -= 10;
        }
    }
    */


    public void EatFood(float foodPoint)
    {
        currentPoint += foodPoint;
    }

    public void EatFoodSetHealth(float foodHealth)
    {
        currentHealth += foodHealth;
    }


}
