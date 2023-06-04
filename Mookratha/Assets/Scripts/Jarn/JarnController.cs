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
    public float aroiDelay;
    public float maiAroiDelay;
   

    public Text pointText;
    public float currentPoint = 0;

    public HealthBar healthBar;

    public GameObject foodParticle;


    private void Start()
    {
        if (aroiDelay == 0) aroiDelay = 2f;
        if (maiAroiDelay == 0) maiAroiDelay = 2f;
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

        if(currentPoint < 0)
        {
            currentPoint= 0;
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
        Invoke("setBoolAroifalse", aroiDelay);
        
    }

    public void EatAnim_Rare_Burn()
    {
        animator.SetBool("MaiAroi", true);
        Invoke("setBoolMaiAroifalse", maiAroiDelay);

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
