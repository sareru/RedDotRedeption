using UnityEngine;

public class RotateCube : MonoBehaviour
{
    public bool IsInFocus = true;

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
        if (transform.eulerAngles.x >= 0 && transform.eulerAngles.x < 90 && IsInFocus == true) // && GameObject is focused
        {
            transform.Rotate(0.2f, 0, 0, Space.Self);

        }

        else if (transform.eulerAngles.x >= 0 && transform.eulerAngles.x <= 90 && IsInFocus == false) // && GameObject is not focused
        {
            transform.Rotate(-0.2f, 0, 0, Space.Self);
        }
    }
}
