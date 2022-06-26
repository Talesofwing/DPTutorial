using System.Collections.Generic;

// 觀察者接口
public interface IModuleObserver {
    void OnModuleChanged ();
}

// 被觀察者
public abstract class BaseModule {
    private static BaseModule m_Instance;

    public static T GetInstance<T> () where T : BaseModule, new() {
        if (m_Instance == null) {
            m_Instance = new T ();
        }

        return m_Instance as T;
    }

    // 觀察者們
    private List<IModuleObserver> m_Observers = new List<IModuleObserver> ();

    protected BaseModule () { }

    public void AddObserver (IModuleObserver observer) {
        m_Observers.Add (observer);
    }

    public void RemoveObserver (IModuleObserver observer) {
        m_Observers.Remove (observer);
    }

    protected void CallObservers () {
        for (int i = 0; i < m_Observers.Count; i++) {
            m_Observers[i].OnModuleChanged ();
        }
    }
    
}
