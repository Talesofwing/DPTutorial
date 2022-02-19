using UnityEngine;

public class FrozenGem : BaseGem {
           
    public FrozenGem (Weapon wrapWeapon) : base(wrapWeapon) { }
    
    public override void Attack () {
        base.Attack ();
        
        Debug.Log ("帶有冰凍");
    } 
 
    public override string Show () {
        return base.Show() + ", 冰凍寶石";
    }
    
    public override string ToString () {
        return "冰凍寶石";
    }
    
}
