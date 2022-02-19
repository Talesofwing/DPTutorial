using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UseDecorate : MonoBehaviour {
    
    private void Start () {
        // 創建基础武器
        Weapon weapon = new Weapon ();
        weapon = new FireGem (weapon);
        weapon.ID = 1;
        weapon = new FrozenGem (weapon);
        weapon.ID = 2;
        Debug.Log ("武器: " + weapon.Show ());
        weapon.Attack ();

        
        // 卸載寶石
        weapon.Unload (1);
        Debug.Log ("武器: " + weapon.Show ());
        weapon.Attack ();
        
        // 繼續裝寶石
        weapon = new FrozenGem (weapon);
        weapon.ID = 1;
        weapon = new FrozenGem (weapon);
        weapon.ID = 3;
        Debug.Log ("武器: " + weapon.Show ());
        weapon.Attack ();
        
        // 再卸一個寶石
        weapon.Unload (2);
        Debug.Log ("武器: " + weapon.Show ());
        weapon.Attack ();
    }
    
}
