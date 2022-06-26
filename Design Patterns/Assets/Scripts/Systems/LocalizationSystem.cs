using System.Collections.Generic;

public enum Language {
    None = 0,
    EN,
    zh_TW,
    zh_CN,
    JP,
    KR,
}

// 觀察者
public interface ILocalizationListener {
    public void OnLangugageChanged ();
}

public class LocalizationSystem {

#region Singleton

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

#endregion

    private Language m_Language = Language.None;

    public Language Lang {
        get { return m_Language; }
        set {
            if (m_Language == value) {
                return;
            }

            m_Language = value;
            Refresh ();
        }
    }

    private Dictionary<int, string> m_NPCNames;

    // 禁止使用new創建新的實例
    private LocalizationSystem () { }

    // 當語言更改後，自動調用
    private void Refresh () {
        // 只需要知道ILocalizationFactory
        m_NPCNames = GetFactory ().Create ();

        for (int i = 0; i < m_Listeners.Count; i++) {
            m_Listeners[i].OnLangugageChanged ();
        }
    }

    // 根據ID獲得NPC的名字
    public string GetString (int id) {
        if (m_NPCNames.ContainsKey (id))
            return m_NPCNames[id];

        return "NONE";
    }

#region Factory

    // 簡單工廠
    public ILocalizationFactory GetFactory () {
        ILocalizationFactory factory = null;
        switch (m_Language) {
            case Language.JP:
                factory = new JPFactory ();

                break;
            case Language.zh_CN:
                factory = new CNFactory ();

                break;
            case Language.zh_TW:
                factory = new TWFactory ();

                break;
            case Language.KR:
                factory = new KRFactory ();

                break;
            case Language.EN:
            default:
                factory = new ENFactory ();

                break;
        }

        return factory;
    }

#endregion

#region Observer

    private List<ILocalizationListener> m_Listeners = new List<ILocalizationListener> ();

    public void AddListener (ILocalizationListener listener) {
        m_Listeners.Add (listener);
    }

    public void RemoveListner (ILocalizationListener listener) {
        m_Listeners.Remove (listener);
    }

#endregion

}