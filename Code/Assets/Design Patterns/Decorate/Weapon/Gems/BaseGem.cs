// 修飾武器的GEM

using UnityEngine;

public abstract class BaseGem : Weapon {
    protected Weapon m_WrapWeapon;      // 裝飾中的對象
    protected Weapon m_WrappedWeapon;   // 被誰裝飾中?

    public BaseGem (Weapon weapon) {
        m_WrapWeapon = weapon;
        weapon.WrappedWeapon (this);
    }

    public override void Attack () {
        m_WrapWeapon.Attack ();
    }
    
    public override string Show () {
        return m_WrapWeapon.Show ();
    }
    
    // 裝飾武器
    public override void WrapWeapon (Weapon weapon) {
        m_WrapWeapon = weapon;
        weapon.WrappedWeapon (this);
    }

    // 被武器裝飾
    public override void WrappedWeapon (Weapon weapon) {
        m_WrappedWeapon = weapon;
    }

    // 卸載
    public override void Unload (int id) {
        if (ID != id) {
            m_WrapWeapon.Unload (id);

            return;
        }

        Debug.Log ("卸載了 " + this);
        
        // 因為自己要被刪除了
        // 所以將上一層的寶石設置為裝飾下一層寶石
        // 而下一層的寶石也會設置成被上一層寶石所裝飾
        if (m_WrappedWeapon != null) {
            m_WrappedWeapon.WrapWeapon (m_WrapWeapon);
        }
    }

}
