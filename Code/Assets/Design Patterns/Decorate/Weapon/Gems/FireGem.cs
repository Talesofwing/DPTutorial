using UnityEngine;

public class FireGem : BaseGem {
    
    public FireGem (Weapon wrapWeapon) : base(wrapWeapon) { }
    
    public override void Attack () {
        base.Attack ();

        Debug.Log ("帶有燃燒");
    }
    
    public override string Show () {
        return base.Show() + ", 冰凍寶石";
    }
    
    public override string ToString () {
        return "火焰寶石";
    }

}
