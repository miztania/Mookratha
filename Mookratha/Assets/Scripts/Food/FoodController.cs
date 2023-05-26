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

    //Plume Added
    public float burnLevel = 0;
    public float burnLevelMax = 100;
    public float burnRate = 12;


    private void Start()
    {
        renderer= GetComponent<Renderer>();
        renderer.enabled= true;
        renderer.sharedMaterial = meterial[0];
        startTime = Time.time;
    }

    private void Update()
    {
      
        cookLevel = Mathf.MoveTowards(cookLevel, cookLevelMax, cookRate * Time.deltaTime);

        if(cookLevel.Equals(cookLevelMax)) burnLevel = Mathf.MoveTowards(burnLevel, burnLevelMax, burnRate * Time.deltaTime);

        Debug.Log("Cook Level : " + cookLevel);
        if (cookLevel >= 40)
        {
            renderer.sharedMaterial = meterial[1];
        }

        if(cookLevel >= 60) 
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
}
