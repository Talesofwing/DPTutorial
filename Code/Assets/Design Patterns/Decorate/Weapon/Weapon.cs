using UnityEngine;

public class Weapon {

    public int ID {
        get;
        set;
    }
    
    public virtual void Attack () {
        Debug.Log ("攻擊!");
    }

    public virtual string Show () {
        return "普通武器";
    }
    
    public virtual void Unload (int id) { }
    
    public virtual void WrapWeapon (Weapon weapon) { }

    public virtual void WrappedWeapon (Weapon weapon) { }
    
    
    
    public override string ToString () {
        return "普通武器";
    }
    
}
