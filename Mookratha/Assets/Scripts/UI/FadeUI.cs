using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FadeUI : MonoBehaviour
{
    public float time = 5; //Seconds to read the text
    public GameObject IU;

    //IEnumerator Start()
    //{
    //    yield return new WaitForSeconds(time);
    //    IU.SetActive(false);
    //}

    private void Update()
    {
        time -= Time.deltaTime;
        
        if(time <= 0)
        {
            time = 5;
            IU.SetActive(false);
        }
    }
}
