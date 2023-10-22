using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using System.IO;

public class FileDataHandler
{
    private string dataDirPath = "";
    private string dataFileName = "";
    private bool useEncryption = false;
    private readonly string encryptionCodeWord = "capivara";

    public FileDataHandler(string dataDirPath, string dataFileName, bool useEncryption)
    {
        this.dataDirPath = dataDirPath;
        this.dataFileName = dataFileName;
        this.useEncryption = useEncryption;
    }
    public GameData Load()
    {
        //Path.Combine guarantees the correct path on different OS's
        string fullPath = Path.Combine(dataDirPath, dataFileName);
        GameData loadedData = null;

        if (File.Exists(fullPath))
        {
            try
            {
                //load serialized data
                string dataToLoad = "";
                using (FileStream stream = new FileStream(fullPath, FileMode.Open))
                {
                    using (StreamReader reader = new StreamReader(stream))
                    {
                        dataToLoad = reader.ReadToEnd();
                    }
                }

                //optionally decrypt data
                if (useEncryption)
                {
                    dataToLoad = EncryptDecrypt(dataToLoad);
                }

                //deserialize from JSON to C# object
                loadedData = JsonUtility.FromJson<GameData>(dataToLoad);

            }
            catch (Exception e)
            {
                Debug.LogError("Error when loading file: " + fullPath + "\n" + e);
            }
        }
        return loadedData;

    }
    public void Save(GameData data)
    {
        //Path.Combine guarantees the correct path on different OS's
        string fullPath = Path.Combine(dataDirPath, dataFileName);
        try
        {
            //creates directory if it doesnt exist yet
            Directory.CreateDirectory(Path.GetDirectoryName(fullPath));
            //serialize data as JSON
            string dataToStore = JsonUtility.ToJson(data, true);

            //optionally encrypt file data
            if (useEncryption)
            {
                dataToStore = EncryptDecrypt(dataToStore);
            }

            //write data to file
            using(FileStream stream = new FileStream(fullPath, FileMode.Create))
            {
                using (StreamWriter writer = new StreamWriter(stream))
                {
                    writer.Write(dataToStore);
                }
            }

        }
        catch (Exception e)
        {
            Debug.LogError("Error when trying to save data to file: " + fullPath + "\n" + e);
        }
    }

    //simple implementation of XOR encryption
    private string EncryptDecrypt(string data)
    {
        string modifiedData = "";
        for (int i = 0; i < data.Length; i++)
        {
            modifiedData += (char)(data[i] ^ encryptionCodeWord[i % encryptionCodeWord.Length]);
        }
        return modifiedData;
    }
}

