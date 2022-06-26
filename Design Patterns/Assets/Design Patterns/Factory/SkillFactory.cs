using System.Globalization;
using System.Reflection;
using UnityEngine;

public struct SkillData {
    public int Atk;
    public int Duration;
}

public static class SkillFactory {

    public static BaseSkill CreateSkill (string skillName, SkillData data) {
        BaseSkill skill = null;
        switch (skillName) {
            case "Fireball":
                skill = new Fireball ("火球術");
                break;
            case "Lighting":
                skill = new Lighting ("雷鳴術");
                break;
        }

        Debug.Log ("通過技能工廠創建了 " + skillName + " 技能了!");
        return skill;
    }

    // Reflection (反射機制)
    public static BaseSkill CreateSkillInReflection (string skillName, SkillData data) {
        BaseSkill skill = Assembly.GetExecutingAssembly ().CreateInstance (skillName, false,
                                                                           BindingFlags.Default, 
                                                                           null, new object[] { skillName }, 
                                                                           CultureInfo.CurrentCulture, null) as BaseSkill;
        Debug.Log ("通過技能工廠創建了(反射機制) " + skillName + " 技能了!");
        return skill;
    }
    
}
    
