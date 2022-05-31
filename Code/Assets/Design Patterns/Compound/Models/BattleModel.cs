using System.Collections.Generic;

public class BattleModel : IModel {
    private int m_HeartCount;
    public int HeartCount {
        get {
            return m_HeartCount;
        }
        set {
            m_HeartCount = value;
            NotifyObserver ();
        }
    }

    private List<IBattleModelObserver> m_Observers = new List<IBattleModelObserver> ();
    
    public void Initialize () {
        HeartCount = 3;
    }

    public void RegisterObserver (IObserver observer) {
        m_Observers.Add (observer as IBattleModelObserver);
    }

    public void UnregisterObserver (IObserver observer) {
        m_Observers.Remove (observer as IBattleModelObserver);
    }
    
    private void NotifyObserver () {
        for (int i = 0; i < m_Observers.Count; i++) {
            m_Observers[i].UpdateBattleModel ();
        }
    }
    
}
