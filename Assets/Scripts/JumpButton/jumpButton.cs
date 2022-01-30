using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class jumpButton : MonoBehaviour
{
    void Start()
    {
        
    }

    
    void Update()
    {
        if(Input.GetMouseButtonDown(0))
        {
            playerJumpscript.instance.setPower(true);
        }
        else if(Input.GetMouseButtonUp(0))
        {
           playerJumpscript.instance.setPower(false);
        }
    }
}
