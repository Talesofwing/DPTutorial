using System;
using UnityEngine;

public class CraftSystem {
    
#region Singleton
    
    private static Lazy<CraftSystem> m_Instance = new Lazy<CraftSystem> (()=> new CraftSystem ());

    public static CraftSystem Instance {
        get {
            return m_Instance.Value;
        }
    }
    
    private CraftSystem () { }

#endregion

    public void Craft (int itemID) {
        Debug.Log ("制作" + itemID + "道具");
    }
    
}