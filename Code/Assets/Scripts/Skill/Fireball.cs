using UnityEngine;

public class Fireball : BaseSkill {

    public Fireball (string name) : base (name) {
        
    }
    
    public override void Use () {
        Debug.Log ("使用 " + m_SkillName);
    }

}