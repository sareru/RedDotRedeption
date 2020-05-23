using UnityEngine;

public class RotateCube : MonoBehaviour
{
    public bool IsInFocus = false;

    public void SetIsInFocus(bool state)
    {
        IsInFocus = state;
    }

    public bool GetIsInFocus()
    {
        return IsInFocus;
    }

    // Update is called once per frame
    void Update()
    {
        if (transform.localEulerAngles.x >= 0 && transform.localEulerAngles.x < 89.8 && IsInFocus == true) // && GameObject is focused
        {
            transform.Rotate(0.2f, 0, 0, Space.Self);

        }
        
        else if (transform.localEulerAngles.x >= 0.2f && transform.localEulerAngles.x <= 90 && IsInFocus == false) // && GameObject is not focused
        {
            transform.Rotate(-0.2f, 0, 0, Space.Self);
        }
    }
}
