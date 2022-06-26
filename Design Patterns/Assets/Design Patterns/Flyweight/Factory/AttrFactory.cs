using System.Collections.Generic;
using UnityEngine;

public class AttrFactory : IAttrFactory {
    private static AttrFactory m_Instance;
    
    private Dictionary<EnemyType, EnemyBaseAttr> m_EnemyBaseAttrDict;

    public static AttrFactory Instance {
        get {
            if (null == m_Instance) {
                m_Instance = new AttrFactory();
            }

            return m_Instance;
        }
    }
    
    private AttrFactory () {
        m_EnemyBaseAttrDict = new Dictionary<EnemyType, EnemyBaseAttr> ();
        
        m_EnemyBaseAttrDict.Add(EnemyType.FireEnemy, 
                                new EnemyBaseAttr ("火焰敵人", 100, 5, 5.0f));
    }
    
    public EnemyBaseAttr GetEnemyBaseAttr (EnemyType type) {
        if (!m_EnemyBaseAttrDict.ContainsKey (type)) {
            Debug.LogError("在字典中不存在該類型: " + type);

            return null;
        }

        return m_EnemyBaseAttrDict[type];
    }
    
}
