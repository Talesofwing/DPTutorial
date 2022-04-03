using System;
using UnityEngine;

public class InventorySystem {

#region Singleton
    private static Lazy<InventorySystem> m_Instance = new Lazy<InventorySystem> (()=> new InventorySystem ());

    public static InventorySystem Instance {
        get {
            return m_Instance.Value;
        }
    }
    
    private InventorySystem () { }

#endregion

    private bool m_Item1 = true;
    private bool m_Item2 = true;
    
    public void AddItem (int itemID) {
        Debug.Log ("增加" + itemID + "道具.");
    }

    public void RemoveItem (int itemID) {
        m_Item1 = !(itemID == 1);
        m_Item2 = !(itemID == 2);
        Debug.Log ("刪除" + itemID + "道具.");
    }

    public bool HasItem (int itemID) {
        if (itemID == 1) {
            return m_Item1;
        } else {
            return m_Item2;
        }
    }
    
}
