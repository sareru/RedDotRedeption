using UnityEngine;

public class RightOffAxisScript : MonoBehaviour
{
    public Camera referenceCam;

    // Start is called before the first frame update
    void Start()
    {
        Camera cam = GetComponent<Camera>();
        cam.SetStereoProjectionMatrix(Camera.StereoscopicEye.Right, referenceCam.projectionMatrix);
    }
}
