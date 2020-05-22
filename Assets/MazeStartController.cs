using UnityEngine;
using UnityEngine.UI;

public class MazeStartController : MonoBehaviour
{
    public Text timerTextUI;
    CameraInteractions ci;
    

    float verweilenTimer = 5f;
    bool verweilt = false;
    bool started = false;

    void Update()
    {
        if (verweilt && !started)
        {
            if (verweilenTimer <= 0f)
            {
                started = true;
                timerTextUI.text = "Start!";
                ci.StartGame();
                LightController.setLightIntensity(1);
            }
            else
            {
                verweilenTimer -= Time.deltaTime;
                timerTextUI.text = "Time to start: " + verweilenTimer.ToString("0.##") + "s";
            }
        }
    }

    public void RayEnters(CameraInteractions ci)
    {
        if (!started)
        {
            Debug.Log("enter");
            verweilt = true;
            verweilenTimer = 5f;
            this.ci = ci;
            
        }
    }

    public void RayLeaves()
    {
        if (!started)
        {
            Debug.Log("leaves");
            verweilt = false;
            verweilenTimer = 5f;
            timerTextUI.text = "Time to start: " + verweilenTimer.ToString("0.##") + "s";
        }
    }
}
