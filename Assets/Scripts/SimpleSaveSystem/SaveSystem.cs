using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using UnityEngine;

public static class SaveSystem{

    public static void SavePlayer(PlayerData player)
    {
        BinaryFormatter formatter = new BinaryFormatter();
        string path = Application.persistentDataPath + "/player.data";
        FileStream fs = new FileStream(path, FileMode.Create);

        PlayerData data = new PlayerData(player.maxHealth, player.currentHealth, player.exp, player.expToLevelUp, player.level, player.position);

        formatter.Serialize(fs, data);
        fs.Close();
    }

    public static PlayerData LoadPlayer()
    {
        string path = Application.persistentDataPath + "/player.data";
        if (File.Exists(path))
        {
            BinaryFormatter formatter = new BinaryFormatter();
            FileStream fs = new FileStream(path, FileMode.Open);

            PlayerData data = formatter.Deserialize(fs) as PlayerData;
            fs.Close();

            return data;
        }
        else
        {
            Debug.Log($"Save file not found in {path}");
            return null;
        }
    }

}
