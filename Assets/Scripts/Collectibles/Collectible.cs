using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collectible : MonoBehaviour, IDataPersistence
{
    [SerializeField] private string id;
    private bool collected = false;

    [ContextMenu("Generate guid for id")]
    private void GenerateGuid()
    {
        id = System.Guid.NewGuid().ToString();
    }

    public void LoadData(GameData data)
    {
        data.collectedObjects.TryGetValue(id, out collected);
        if (collected)
        {
            //disable in-game rendering for object
            gameObject.SetActive(false);
        }
    }

    public void SaveData(ref GameData data)
    {
        if (data.collectedObjects.ContainsKey(id))
        {
            data.collectedObjects.Remove(id);
        }
        data.collectedObjects.Add(id, collected);
    }
    /*In case there is an UI element indicating how many of these collectibles were collected, add the following code to the UI script:
     * Remember that the script must also extend from IDataPersistence
     * public void LoadData(GameData data)
     * {
     *      foreach(KeyValuePair<string, bool> pair in data.collectedObjects){
     *          if(pair.Value){
     *              collectedObjectsCounter++;
     *          }
     *      }
     *  }
     *  public void SaveData(ref GameData data)
     *  {
     *  }
     * */
}
