using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class LoadLvl : MonoBehaviour
{
    //public Text timerTextUI;
    public Slider loadingSliderUI;
    public string zuLadendesLvl;

    const float timer = 2f;
    float verweilenTimer;
    bool verweilt = false;
    bool gestartet = false;

    private void Start()
    {
        verweilenTimer = timer;
    }

    void Update()
    {
        if (verweilt && !gestartet)
        {
            if (verweilenTimer <= 0f)
            {
                // Level laden
                SceneManager.LoadScene(zuLadendesLvl, LoadSceneMode.Single);
                gestartet = true;
            }
            else
            {
                verweilenTimer -= Time.deltaTime;
                loadingSliderUI.value = (timer - verweilenTimer) / timer;
            }
        }
    }

    public void RayEnters()
    {
        verweilt = true;
        loadingSliderUI.value = 0f;
        loadingSliderUI.gameObject.SetActive(true);
        Debug.Log(zuLadendesLvl);
    }

    public void RayLeaves()
    {
        loadingSliderUI.gameObject.SetActive(false);
        verweilt = false;
        verweilenTimer = timer;
    }
}
