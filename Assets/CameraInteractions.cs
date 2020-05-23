using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

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
                textUI.text = "Timer:\n" + (gameTimer/60).ToString("00") + ":" + gameTimer.ToString("00.0") + "s";
            }

            RaycastHit hit;
            if (Physics.Raycast(transform.position, transform.forward, out hit))
            {
                if (hit.collider != null)
                {
                    // Menü-Aktionen
                    if (SceneManager.GetActiveScene().name == "Menü")
                    {
                        // Level laden
                        if (hit.collider.tag == "Verweilen")
                        {
                            if (oldHit.collider != null)
                            {
                                if (oldHit.collider != hit.collider)
                                {
                                    rayLeft = false;
                                    OnRayLeaveLvlBlock();
                                    OnRayHitLvlBlock(hit);
                                    oldHit = hit;
                                }
                                else
                                {
                                    if (rayLeft)
                                    {
                                        OnRayHitLvlBlock(hit);
                                        oldHit = hit;
                                        rayLeft = false;
                                    }
                                }
                            }
                            else
                            {
                                OnRayHitLvlBlock(hit);
                                oldHit = hit;
                                rayLeft = false;
                            }
                            oldHit = hit;
                        } else
                        {
                            if (oldHit.collider != null && oldHit.collider.tag == "Verweilen")
                            {
                                OnRayLeaveLvlBlock();
                                rayLeft = true;
                            }
                        }

                        // Beschreibung anzeigen
                        if (hit.collider.tag == "Rotieren")
                        {
                            if (!hit.collider.GetComponent<RotateCube>().GetIsInFocus())
                                hit.collider.GetComponent<RotateCube>().SetIsInFocus(true);
                            oldHit = hit;
                        }
                    }

                    // Aktionen im Spiel
                    else
                    {
                        if (hit.collider.tag == "Verweilen")
                        {
                            if (oldHit.collider != null)
                            {
                                if (oldHit.collider != hit.collider)
                                {
                                    rayLeft = false;
                                    OnRayLeaveMaze();
                                    OnRayHitMaze(hit);
                                    oldHit = hit;
                                }
                                else
                                {
                                    if (rayLeft)
                                    {
                                        OnRayHitMaze(hit);
                                        oldHit = hit;
                                        rayLeft = false;
                                    }
                                }
                            }
                            else
                            {
                                OnRayHitMaze(hit);
                                oldHit = hit;
                                rayLeft = false;
                            }
                        }
                        else
                        {
                            if (!rayLeft)
                            {
                                OnRayLeaveMaze();
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
                                OnRayLeaveMaze();
                                rayLeft = true;
                            }
                        }
                    }
                }
            }
            else
            {
                // Menü-Aktionen
                if (SceneManager.GetActiveScene().name == "Menü")
                {
                    if (oldHit.collider != null && oldHit.collider.tag == "Rotieren")
                    {
                        if (oldHit.collider.GetComponent<RotateCube>().GetIsInFocus())
                            oldHit.collider.GetComponent<RotateCube>().SetIsInFocus(false);
                    }
                    if (oldHit.collider != null && oldHit.collider.tag == "Verweilen")
                    {
                        OnRayLeaveLvlBlock();
                        rayLeft = true;
                    }
                }
                else
                {
                    OnRayLeaveMaze();
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

    void OnRayHitMaze(RaycastHit hit)
    {
        hit.collider.GetComponent<MazeStartController>().RayEnters(this);
    }

    void OnRayLeaveMaze()
    {
        if (!rayLeft)
        {
            oldHit.collider.GetComponent<MazeStartController>().RayLeaves();
        }
    }

    public void StartGame()
    {
        gameStarted = true;
    }

    public float getGameTimer()
    {
        return gameTimer;
    }

    void OnRayLeaveLvlBlock()
    {
        if (oldHit.collider.tag == "Verweilen" && !rayLeft)
        {
            oldHit.collider.GetComponent<LoadLvl>().RayLeaves();
        }
    }

    void OnRayHitLvlBlock(RaycastHit hit)
    {
        hit.collider.GetComponent<LoadLvl>().RayEnters();
    }
}
