using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Teleporto : MonoBehaviour
{
    // Start is called before the first frame update
    public Transform teleportZiel;
    public GameObject RedDot;

    void OnTriggerEnter(Collider other)
    {
        RedDot.transform.position = teleportZiel.transform.position;
    }
}
