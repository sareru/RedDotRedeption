using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class OneTimeSelectController : MonoBehaviour
{
    public Material newMat;
    Renderer ren;

    float verweilenTimer = 0f;
    bool verweilt = false;
    bool used = false;

    // Start is called before the first frame update
    void Start()
    {
        ren = GetComponent<Renderer>();
    }

    void Update()
    {
        if (verweilt == !used)
        {
            if (verweilenTimer > 5f)
            {
                ChangeMaterial();
                RayLeaves();
                used = true;
            } else
            {
                verweilenTimer += Time.deltaTime;
            }
        }
        //Debug.Log(verweilenTimer);
    }

    public void RayEnters()
    {
        if (!used)
        {
            Debug.Log("enter");
            verweilt = true;
            verweilenTimer = 0f;
        }
    }

    public void RayLeaves()
    {
        if (!used)
        {
            Debug.Log("leaves");
            verweilt = false;
            verweilenTimer = 0f;
        }
    }

    public void ChangeMaterial()
    {
        ren.material = newMat;
    }
}
