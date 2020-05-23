using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class LoadLvl : MonoBehaviour
{
    public Text timerTextUI;
    public int zuLadendesLvl = 1;

    float verweilenTimer = 3f;
    bool verweilt = false;
    bool gestartet = false;

    void Update()
    {
        if (verweilt && !gestartet)
        {
            if (verweilenTimer <= 0f)
            {
                // Level laden
                SceneManager.LoadScene("Lvl" + zuLadendesLvl.ToString(), LoadSceneMode.Single);
                gestartet = true;
            }
            else
            {
                verweilenTimer -= Time.deltaTime;
                timerTextUI.text = "Level " + zuLadendesLvl.ToString() + " wird geladen...";
                Debug.Log(zuLadendesLvl);
            }
        }
    }

    public void RayEnters()
    {
        verweilt = true;
        verweilenTimer = 5f;
    }

    public void RayLeaves()
    {
        verweilt = false;
        verweilenTimer = 5f;
    }
}
