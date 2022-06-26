using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UseDecorate : MonoBehaviour {
    
    private void Start () {
        // 創建基础武器
        Weapon weapon = new Weapon ();
        weapon = new FireGem (weapon); // 火焰寶石 (武器)
        weapon.ID = 1;
        weapon = new FrozenGem (weapon); // 冰凍寶石 (火焰寶石 (武器))
        weapon.ID = 2;
        Debug.Log ("武器: " + weapon.Show ());
        weapon.Attack ();

        // 卸載寶石
        weapon.Unload (1); // 冰凍寶石 (武器)
        Debug.Log ("武器: " + weapon.Show ()); 
        weapon.Attack ();
        
        // 繼續裝寶石
        weapon = new FrozenGem (weapon); // 冰凍寶石 (冰凍寶石 (武器))
        weapon.ID = 1;
        weapon = new FrozenGem (weapon); // 冰凍寶石 (冰凍寶石 (冰凍寶石 (武器)))
        weapon.ID = 3;
        Debug.Log ("武器: " + weapon.Show ());
        weapon.Attack ();
        
        // 再卸一個寶石
        weapon.Unload (2); // 冰凍寶石 (冰凍寶石 (武器))
        Debug.Log ("武器: " + weapon.Show ());
        weapon.Attack ();
    }
    
}
