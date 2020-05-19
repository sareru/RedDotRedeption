using System.Collections;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Security.Cryptography;
using UnityEngine;

public class RotateCube : MonoBehaviour
    
{
    private bool IsInFocus;
    public void SetIsInFocus (bool state)
    {
        IsInFocus = state;
    }
    public bool GetIsInFocus()
    {
        return IsInFocus;
    }
    // Start is called before the first frame update
    void Start()
    {
        IsInFocus = false;
    }

    // Update is called once per frame
    void Update()
    {
        //For Testing, remove it for correct use
        /*
        if (Input.GetKeyDown("space"))
        {
            SetIsInFocus(!IsInFocus);
        }
        */

        if (transform.eulerAngles.x >= 0 && transform.eulerAngles.x < 89.8 && IsInFocus == true) // && GameObject is focused
        {
            transform.Rotate(0.2f, 0, 0, Space.Self);
            
        }
     
       else if (transform.eulerAngles.x >= 0.2 && transform.eulerAngles.x <= 90 && IsInFocus == false) // && GameObject is not focused
        {
            transform.Rotate(-0.2f, 0, 0, Space.Self);
        }
    }
}
