using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UseFactory : MonoBehaviour, ILocalizationListener {
    [Header ("UI")] 
    [SerializeField] private Text m_Text;

    private int m_TextID = 1;

#region Unity Lifetime

    private void Awake () {
        LocalizationSystem.Instance.AddListener (this);
    }

    private void Start () {
        LocalizationSystem.Instance.Lang = Language.EN;
    }

    private void Update () {
        if (Input.GetKeyDown (KeyCode.Alpha1) || Input.GetKeyDown (KeyCode.Keypad1)) {
            SetTextID (1);
        } else if (Input.GetKeyDown (KeyCode.Alpha2) || Input.GetKeyDown (KeyCode.Keypad2)) {
            SetTextID (2);
        } else if (Input.GetKeyDown (KeyCode.Alpha3) || Input.GetKeyDown (KeyCode.Keypad3)) {
            SetTextID (3);
        } else if (Input.GetKeyDown (KeyCode.Alpha4) || Input.GetKeyDown (KeyCode.Keypad4)) {
            SetTextID (4);
        }
    }

    public void OnDestroy () {
        LocalizationSystem.Instance.RemoveListner (this);
    }

#endregion

#region Factory
    
    //
    // 使用技能
    //
    private void UseSkillFactory () {
        BaseSkill lighting = SkillFactory.CreateSkill ("Lighting", new SkillData () {Atk = 1});
        BaseSkill fireball = SkillFactory.CreateSkillInReflection ("Fireball", new SkillData () {Atk = 3});

        lighting.Use ();
        fireball.Use ();
    }

    //
    // 刷新UI
    //
    private void RefreshUI () {
        m_Text.text = LocalizationSystem.Instance.GetString (m_TextID);
    }

    //
    // Factory的解耦說明
    //
    private void RefreshUI2 () {
        // 我們不需要知道目前是甚麼語言，會得到甚麼語言的工廠
        // 而只需要知道工廠的接口ILocalizationFactory便可，即與「具體工廠類」解耦 <--- 重點理解
        ILocalizationFactory factory = LocalizationSystem.Instance.GetFactory ();
        Dictionary<int, string> npcNames = factory.Create ();
        m_Text.text = npcNames[m_TextID];
    }
    
#endregion

#region Observer

    public void OnLangugageChanged () {
        RefreshUI ();
    }

#endregion

#region UI Method
    
    private void SetTextID (int id) {
        m_TextID = id;
        RefreshUI ();
    }
    
    public void ChangeLanguage (int id) {
        LocalizationSystem.Instance.Lang = (Language)id;
    }

#endregion

}
