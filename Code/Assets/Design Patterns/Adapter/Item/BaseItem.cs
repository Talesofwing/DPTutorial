using UnityEngine;

public abstract class BaseItem {
    
    public virtual void Use () {
        
    }

    public virtual void Display () {
        
    }

    public virtual void TakeIt () {
        Debug.Log ("拿在手上!");
    }
    
}