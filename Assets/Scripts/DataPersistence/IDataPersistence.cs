using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IDataPersistence
{
    void LoadData(GameData data);

    void SaveData(ref GameData data);//"ref" indicates referencing the actual data, so the script calling this function can modify it
}
