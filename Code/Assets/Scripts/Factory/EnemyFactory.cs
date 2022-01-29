using System;
using System.Reflection;
using UnityEngine;

public class EnemyFactory  : MonoBehaviour {
    [SerializeField] private BaseEnemy[] m_EnemyPrefabs;

    // Simple method.
    public BaseEnemy CreateEnemyInSimpleMethod (EnemyType type) {
        BaseEnemy prefab = GetEnemyPrefab (type);
        BaseEnemy enemy = Instantiate<BaseEnemy> (prefab);

        return enemy;
    }

    private BaseEnemy GetEnemyPrefab (EnemyType type) {
        int length = m_EnemyPrefabs.Length;
        for (int i = 0; i < length; i++) {
            if (m_EnemyPrefabs[i].GetEnemyType () == type) {
                return m_EnemyPrefabs[i];
            }
        }

        return null;
    }
    
}
