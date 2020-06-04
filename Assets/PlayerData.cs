using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class PlayerData
{
    public double time;
   
    public PlayerData (Time score)
    {
        time = score.time;
    }
}
