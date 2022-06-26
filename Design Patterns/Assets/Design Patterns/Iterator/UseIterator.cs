using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UseIterator : MonoBehaviour {
    [SerializeField] private Enemy[] m_Enemies;
    
    private void Start () {
        for (int i = 0; i < m_Enemies.Length; i++) {
            EnemyManager.Instance.AddEnemy (m_Enemies[i]);
        }
    }

    private void Update () {
        if (Input.GetKeyDown (KeyCode.Alpha1) || Input.GetKeyDown (KeyCode.Keypad1)) {
            IterateMethod1 ();
        } else if (Input.GetKeyDown (KeyCode.Alpha2) || Input.GetKeyDown (KeyCode.Keypad2)) {
            IterateMethod2 ();
        } else if (Input.GetKeyDown (KeyCode.Alpha3) || Input.GetKeyDown (KeyCode.Keypad3)) {
            IterateMethod3 ();
        } else if (Input.GetKeyDown (KeyCode.Alpha4) || Input.GetKeyDown (KeyCode.Keypad4)) {
            IterateMethod4 ();
        }
    }
    
    private void IterateMethod1 () {
        foreach (var Enemy in EnemyManager.Instance) {
            Debug.Log (Enemy);
        }
    }

    private void IterateMethod2 () {
        IEnumerator<Enemy> enumerator =  EnemyManager.Instance.GetEnumerator ();
        while (enumerator.MoveNext ()) {
            Debug.Log (enumerator.Current);
        }
        enumerator.Dispose ();
    }
    
    /// <summary>
    /// 即使EnemyManager不是IEnumerable，也能通過這種方式遍歷
    /// </summary>
    private void IterateMethod3 () {
        for (int i = 0; i < EnemyManager.Instance.Count; i++) {
            Debug.Log (EnemyManager.Instance[i]);
        }
    }

    private void IterateMethod4 () {
        Debug.Log (EnemyManager.Instance["a"]);
    }

}
