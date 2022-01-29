using UnityEngine;

// 直接使用類名當技能名稱
public abstract class BaseSkill {
    protected string m_SkillName;
    
    public BaseSkill (string name) {
        m_SkillName = name;

        Debug.Log (name + " 初始化");
    }

    public abstract void Use ();
}
