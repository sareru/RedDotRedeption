using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LeftOffAxisScript : MonoBehaviour
{
    public Camera referenceCam;

    // Start is called before the first frame update
    void Start()
    {
        Camera cam = GetComponent<Camera>();
        cam.SetStereoProjectionMatrix(Camera.StereoscopicEye.Left, referenceCam.projectionMatrix);
    }
}
