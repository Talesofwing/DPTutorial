using UnityEngine;

public class RedPotion : BaseItem {
    
    public override void Use () {
        Debug.Log ("使用紅色藥水!");
    }
    
    public override void Display () {
        Debug.Log ("紅色藥水!");
    }

}