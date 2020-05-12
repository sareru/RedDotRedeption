using UnityEngine;
using UnityEngine.UI;

public class CameraInteractions : MonoBehaviour
{
    // TODO: Interaction fürs Items aufsammeln

    public Text textUI;
    public LayerMask ignoreMask;

    RaycastHit oldHit;

    bool rayLeft = true;
    bool gameStarted = false;
    bool gameOver = false;

    float gameTimer = 0f;

    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        if (!gameOver)
        {
            if (gameStarted)
            {
                gameTimer += Time.deltaTime;
                textUI.text = "Timer: " + gameTimer.ToString("0.##") + "s";
            }

            RaycastHit hit;
            if (Physics.Raycast(transform.position, transform.forward, out hit))
            {
                if (hit.collider != null)
                {
                    if (hit.collider.tag == "Verweilen")
                    {
                        if (oldHit.collider != null)
                        {
                            if (oldHit.collider != hit.collider)
                            {
                                rayLeft = false;
                                OnRayLeave();
                                OnRayHit(hit);
                                oldHit = hit;
                            }
                            else
                            {
                                if (rayLeft)
                                {
                                    OnRayHit(hit);
                                    oldHit = hit;
                                    rayLeft = false;
                                }
                            }
                        }
                        else
                        {
                            OnRayHit(hit);
                            oldHit = hit;
                            rayLeft = false;
                        }
                    }
                    else
                    {
                        if (!rayLeft)
                        {
                            OnRayLeave();
                            rayLeft = true;
                        }
                    }
                    if (gameStarted && hit.collider.tag == "Mauer")
                    {
                        textUI.text = "Game over!";
                        gameOver = true;
                    }
                    else
                    {
                        if (gameStarted && oldHit.collider != null)
                        {
                            OnRayLeave();
                            rayLeft = true;
                        }
                    }
                }
                else
                {
                    OnRayLeave();
                    rayLeft = true;
                    if (gameStarted)
                    {
                        textUI.text = "Game over!";
                        gameOver = true;
                    }
                }
            }
        }
    }

    void OnRayHit(RaycastHit hit)
    {
        Debug.Log("hit");
        hit.collider.GetComponent<MazeStartController>().RayEnters(this);
    }

    void OnRayLeave()
    {
        if (!rayLeft)
        {
            Debug.Log("leave");
            oldHit.collider.GetComponent<MazeStartController>().RayLeaves();
        }
    }

    public void StartGame()
    {
        gameStarted = true;
    }
}
