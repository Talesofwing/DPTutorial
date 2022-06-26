using System;
using UnityEngine;

public class RecipeSystem {
    
#region Singleton
    
    private static Lazy<RecipeSystem> m_Instance = new Lazy<RecipeSystem> (()=> new RecipeSystem ());

    public static RecipeSystem Instance {
        get {
            return m_Instance.Value;
        }
    }
    
    private RecipeSystem () { }

#endregion

    public void GetRecipe (int itemID) {
        Debug.Log ("獲得" + itemID + "配方");
    }
    
}
