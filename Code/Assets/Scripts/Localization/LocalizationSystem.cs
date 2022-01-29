using System.Collections.Generic;

[System.Serializable]
public enum Language {
    None = 0,
    EN,
    zh_TW,
    zh_CN,
    JP,
    KR,
}

public interface ILocalizationListener {
    public void OnLangugageChanged ();
}

public class LocalizationSystem {
    // 單例
    private static LocalizationSystem m_Instance;
    public static LocalizationSystem Instance {
        get {
            if (null == m_Instance) {
                m_Instance = new LocalizationSystem ();
            }

            return m_Instance;
        }
    }  
    
    private Language m_Language = Language.None;
    public Language Lang {
        get {
            return m_Language;
        }
        set {
            if (m_Language == value) {
                return;
            }

            m_Language = value;
            Refresh();
        }
    }

    private ILocalizationFactory m_Factory;
    private Dictionary<int, string> m_NPCName;

    private List<ILocalizationListener> m_Listeners = new List<ILocalizationListener> ();
    
    // 禁止使用new創建新的實例
    private LocalizationSystem () {}
    
    private void Refresh () {
        m_NPCName = GetFactory ().Create ();

        for (int i = 0; i < m_Listeners.Count; i++) {
            m_Listeners[i].OnLangugageChanged ();
        }
    }

    public string GetString (int id) {
        if (m_NPCName.ContainsKey (id))
            return m_NPCName[id];

        return "NONE";
    }

    private ILocalizationFactory GetFactory () {
        ILocalizationFactory factory = null;
        switch (m_Language) {
            case Language.JP:
                factory = new JPFactory();
                break;
            case Language.zh_CN:
                factory = new CNFactory();
                break;
            case Language.zh_TW:
                factory = new TWFactory();
                break;
            case Language.EN:
            default:
                factory = new ENFactory();
                break;
        }

        return factory;
    }

    public void AddListener (ILocalizationListener listener) {
        m_Listeners.Add (listener);
    }

    public void RemoveListner (ILocalizationListener listener) {
        m_Listeners.Remove (listener);
    }
    
}
