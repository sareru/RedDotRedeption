using UnityEngine;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;


public static class SaveSystem
{
    public static void SaveScore (PlayerTime time)
    {
        BinaryFormatter formatter = new BinaryFormatter();
        string path = Application.persistentDataPath + "/highscore/points";
        FileStream stream = new FileStream(path, FileMode.Create);
        PlayerData data = new PlayerData(time);

        formatter.Serialize(stream, data);
        stream.Close();
    }

    public static PlayerData LoadScore()
    {
        string path = Application.persistentDataPath + "/highscore/points";
        if (File.Exists(path))
        {
            BinaryFormatter formatter = new BinaryFormatter();
            FileStream stream = new FileStream(path, FileMode.Open);

            PlayerData data = formatter.Deserialize(stream) as PlayerData;
            // DEBUG:
            return null;
        } else
        {
            Debug.LogError("Keine Speicherdaten in " + path);
            return null;
        }

    }
}
