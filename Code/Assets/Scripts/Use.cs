using System;
using UnityEngine;
using UnityEngine.UI;

public class Use : MonoBehaviour, ILocalizationListener {
    [Header("UI")]
    [SerializeField] private Text m_Text;

    [Header ("初始化配置")] 
    [SerializeField] private Language m_Lang = Language.EN;
    [SerializeField] private int m_TextID = 0;
    
    private void Awake () {
        LocalizationSystem.Instance.AddListener (this);
    }
    
    private void Start () {
        BaseSkill lighting = SkillFactory.CreateSkill ("Lighting", new SkillData() {Atk = 1});
        BaseSkill fireball = SkillFactory.CreateSkillInReflection ("Fireball", new SkillData() {Atk = 3});

        lighting.Use ();
        fireball.Use ();

        LocalizationSystem.Instance.Lang = Language.EN;
    }

    public void ChangeLanguage (int id) {
        LocalizationSystem.Instance.Lang = (Language)id;
    }

    public void OnLangugageChanged () {
        m_Text.text = LocalizationSystem.Instance.GetString (m_TextID);
    }

    public void OnDestroy () {
        LocalizationSystem.Instance.RemoveListner (this);
    }
}
