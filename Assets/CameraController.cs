using UnityEngine;

public class CameraController : MonoBehaviour
{
    Gyroscope gyro;

    // Start is called before the first frame update
    void Start()
    {
        gyro = Input.gyro;
        gyro.enabled = true;
    }
    void Update()
    {
        transform.rotation = GyroToUnity(gyro.attitude);
    }

    private static Quaternion GyroToUnity(Quaternion q)
    {
        //Debug.Log(q);
        //return new Quaternion(q.x, q.z, q.y, -q.w); /// iOS autorotation with child camera objected rotated on x = 90
        return new Quaternion(q.w, q.z, q.y, q.x); /// iOS left rotation with child camera objected rotated on x = -180
    }
}
