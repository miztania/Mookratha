using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FoodController : MonoBehaviour
{
    public Material[] meterial;
    Renderer renderer;
    public float startTime;
    public float doneTime = 50f ;
    public float burnTime = 10f;

    public float cookLevel = 0;
    public float cookLevelMax = 100;
    public float cookRate = 0.2f;

    public float inJarnBeforeDestroyTime = 5f;

    //Plume Added
    public float burnLevel = 0;
    public float burnLevelMax = 100;
    public float burnRate = 12;

  

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


        if (cookLevel >= 40)

        if(cookLevel.Equals(cookLevelMax)) burnLevel = Mathf.MoveTowards(burnLevel, burnLevelMax, burnRate * Time.deltaTime);

       // Debug.Log("Cook Level : " + cookLevel);
        if (cookLevel >= 60)

        {
            renderer.sharedMaterial = meterial[1];
        }

        if(cookLevel >= 100) 
        {
            renderer.sharedMaterial = meterial[2];
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
        }
    }


}
