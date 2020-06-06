using UnityEngine;
using UnityEngine.UI;

public class MazeStartController : MonoBehaviour
{
    public Text timerTextUI;
    public Text messageTextUI;
    public Slider loadingSliderUI;
    public GameObject arrows;
    CameraInteractions ci;

    const float timer = 2f;
    float verweilenTimer;
    bool verweilt = false;
    bool started = false;
    bool allSet = false;

    private void Start()
    {
        verweilenTimer = timer;
    }

    void Update()
    {
        if (verweilt && !started)
        {
            if (verweilenTimer <= 0f)
            {
                started = true;
                messageTextUI.text = "Start!";
                ci.StartGame();
                arrows.gameObject.SetActive(false);
                LightController.setLightIntensity(1);
                loadingSliderUI.gameObject.SetActive(false);
                messageTextUI.gameObject.SetActive(true);
            }
            else
            {
                // INFO: der Startblock wird gerade angesehen und der Countdown bis zum Spielstart zählt runter
                verweilenTimer -= Time.deltaTime;
                loadingSliderUI.value = (timer - verweilenTimer) / timer;
                //timerTextUI.text = "Time to start:\n" + verweilenTimer.ToString("0.0") + "s";
            }
        } else if (started && verweilenTimer < 2f)
        {
            verweilenTimer += Time.deltaTime;
        }/* else if (started && verweilenTimer >= 2f && !allSet)
        {
            messageTextUI.gameObject.SetActive(false);
            allSet = true;
        }*/
    }

    public void RayEnters(CameraInteractions ci)
    {
        if (!started)
        {
            Debug.Log("enter");
            verweilt = true;
            this.ci = ci;
            loadingSliderUI.value = 0f;
            loadingSliderUI.gameObject.SetActive(true);
        }
    }

    public void RayLeaves()
    {
        if (!started)
        {
            loadingSliderUI.gameObject.SetActive(false);
            Debug.Log("leaves");
            verweilt = false;
            verweilenTimer = timer;
        }
    }
}
