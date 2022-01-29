using UnityEngine;

public class Lighting : BaseSkill {

    public Lighting (string name) : base (name) {
        
    }
    
    public override void Use () {
        Debug.Log ("使用 " + m_SkillName);
    }

}
    