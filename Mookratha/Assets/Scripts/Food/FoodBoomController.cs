using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using UnityEngine;

public class FoodBoomController : MonoBehaviour
{
    public Material[] meterial;
    Renderer renderer;

    private float startTime;

    [Header("Cook Details")]
    public float cookLevel = 0;
    public float cookLevelMax = 100;
    public float cookRate = 0.2f;

    //Plume Added
    public float burnLevel = 0;
    public float burnLevelMax = 100;
    public float burnRate = 12;


    [Header("Food Details")]
    public float RawPoint = -30;
    public float DonePoint = 30;
    public float BurnPoint = -30;

    public float RawSetHealth = -10;
    public float DoneSetHealth = 10;
    public float BurnSetHealth = -10;


    [Header("Food Effects")]
    public GameObject boomEffect;
    public float boomTime;
    
    
    public float foodStage;
    public float foodPoint;


    public float inJarnBeforeDestroyTime = 5f;



  

    public bool isInJarn;


    private void Start()
    {
        renderer= GetComponent<Renderer>();
        renderer.enabled= true;
        renderer.sharedMaterial = meterial[0];

      

        isInJarn = false;
    }

    private void Update()
    {

        if (!isInJarn)
        {
            IncreaseCookLevel();
        }

        if (isInJarn)
        {
           

            if (Time.time > startTime + inJarnBeforeDestroyTime)
            {
                Destroy(this.gameObject);
            }
        }


        foodPoint = RawPoint;
        foodStage = RawSetHealth;

        

        if (cookLevel >= 40)
        {
            renderer.sharedMaterial = meterial[1];
        }

        if(cookLevel.Equals(cookLevelMax)) burnLevel = Mathf.MoveTowards(burnLevel, burnLevelMax, burnRate * Time.deltaTime);

       // Debug.Log("Cook Level : " + cookLevel);
        if (cookLevel >= 60)

        {
            this.transform.parent = null;
            boomEffect.SetActive(true);


        }

        if (cookLevel >= 65) 
        {
            boomEffect.SetActive(false);
            Destroy(this.gameObject);
        }

        /*
        if(Time.time > startTime + doneTime)
        {
            renderer.sharedMaterial = meterial[1];
        }

         if(Time.time > startTime + burnTime)
        {
            renderer.sharedMaterial = meterial[2];
        }
        */
    }

    public void IncreaseCookLevel()
    {
        cookLevel = Mathf.MoveTowards(cookLevel, cookLevelMax, cookRate * Time.deltaTime);
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "jarn")
        {
            isInJarn= true;
            startTime = Time.time;
            other.SendMessage("EatFood", foodPoint);
            other.SendMessage("EatFoodSetHealth", foodStage);
        }
    }


}


