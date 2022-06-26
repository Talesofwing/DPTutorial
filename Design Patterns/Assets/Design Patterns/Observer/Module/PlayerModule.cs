using System;
using System.Collections.Generic;

public enum PlayerModuleChangeEventType {
    Hp,
    Atk,
    Def
}

public struct PlayerModuleData {
    public PlayerModuleChangeEventType Type;
    public int Hp;
    public int Atk;
    public int Def;
}

public interface IPlayerModuleListener {
    void OnPlayerModuleChanged (BaseModule sender, PlayerModuleData data);
}

public class PlayerModule : BaseModule {
    private int m_Hp;
    private int m_Atk;
    private int m_Def;

    public int Hp {
        set {
            if (m_Hp == value)
                return;
            
            m_Hp = value;
            CallObservers ();
            CallListeners (CreateData (PlayerModuleChangeEventType.Hp));
        }
        get {
            return m_Hp;
        }
    }

    public int Atk {
        set {
            if (m_Atk == value)
                return;
            
            m_Atk = value;
            CallObservers ();
            CallListeners (CreateData (PlayerModuleChangeEventType.Atk));
        }
        get {
            return m_Atk;
        }
    }
    
    public int Def {
        set {
            if (m_Def == value)
                return;
            
            m_Def = value;
            CallObservers ();
            CallListeners (CreateData (PlayerModuleChangeEventType.Def));
        }
        get {
            return m_Def;
        }
    }

    private List<IPlayerModuleListener> m_Listeners = new List<IPlayerModuleListener> ();
    
    public void AddListener (IPlayerModuleListener listener) {
        m_Listeners.Add (listener);
    }

    public void RemoveListener (IPlayerModuleListener listener) {
        m_Listeners.Remove (listener);
    }

    private void CallListeners (PlayerModuleData data) {
        for (int i = 0; i < m_Listeners.Count; i++) {
            m_Listeners[i].OnPlayerModuleChanged(this, data);
        }
    }

    private PlayerModuleData CreateData (PlayerModuleChangeEventType type) {
        PlayerModuleData data;
        data.Type = type;
        data.Atk = Atk;
        data.Hp = Hp;
        data.Def = Def;

        return data;
    }
    
    public override string ToString () {
        return String.Format ("血量: {0}, 攻擊力: {1}, 防禦力:{2}", m_Hp, m_Atk, m_Def);
    }
}
    