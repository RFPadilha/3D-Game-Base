using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PersistentPlayerStats : MonoBehaviour
{
    public static PersistentPlayerStats instance = null;
    public PlayerData data;
    private void Awake()
    {
        if(instance == null)
        {
            instance = this;
        }
    }
}
