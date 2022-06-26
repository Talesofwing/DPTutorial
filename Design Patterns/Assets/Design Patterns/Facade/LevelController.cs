using UnityEngine;

public class LevelController {
    private static LevelController m_Instance;
    public static LevelController Instance {
        get {
            if (null == m_Instance) {
                m_Instance = new LevelController ();
            }

            return m_Instance;
        }
    }

    private int m_CurrentLevel;
    
    public void CreateLevel (int level) {
        m_CurrentLevel = level;
        
        Debug.Log ("CreateLevel: " + level);
    }

    public void RemoveLevel () {
        Debug.Log ("RemoveLevel: " + m_CurrentLevel);
    }
    
}
