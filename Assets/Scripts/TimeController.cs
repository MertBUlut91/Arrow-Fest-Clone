using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimeController : MonoBehaviour
{

    private bool pause = false;

    void Start()
    {
        
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))    
        {
            if (pause)
            {
                Time.timeScale = 1;
                pause = false;

            }
            else
            {
                Time.timeScale = 0;

                pause = !pause;
            }
        }
    }
}
