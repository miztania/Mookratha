using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Animations;
using System.Diagnostics.Contracts;

public class JarnController : MonoBehaviour
{
    public float MaxHealth = 100;
    public float currentHealth = 0;
    public GameObject PlayerGameObject;
    public Animator animator;
   

    public Text pointText;
    public float currentPoint = 0;

    public HealthBar healthBar;

    public GameObject foodParticle;


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

        if(currentHealth <= 0)
        {
            Destroy(PlayerGameObject);
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
        Instantiate(foodParticle, this.transform);
        currentPoint += foodPoint;
    }

    public void EatFoodSetHealth(float foodHealth)
    {
        currentHealth += foodHealth;
    }

    public void EatAnim_Done()
    {
        animator.SetBool("Aroi", true);
        Invoke("setBoolAroifalse", 1.5f);
        
    }

    public void EatAnim_Rare_Burn()
    {
        animator.SetBool("MaiAroi", true);
        Invoke("setBoolMaiAroifalse", 1.5f);
    }

    void setBoolAroifalse()
    {
        animator.SetBool("Aroi", false);
    }

    void setBoolMaiAroifalse()
    {
        animator.SetBool("MaiAroi", false);
    }

}
