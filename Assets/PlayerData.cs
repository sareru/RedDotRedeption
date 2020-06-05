using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class PlayerData
{
    public double time;
   
    public PlayerData (PlayerTime score)
    {
        time = score.time;
    }
}
