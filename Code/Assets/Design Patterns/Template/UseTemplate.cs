using UnityEngine;

public class UseTemplate : MonoBehaviour {
    [SerializeField] private Enemy m_Enemy;
    
    private void Update () {
        if (Input.GetKeyDown (KeyCode.Space)) {
            m_Enemy.Reset ();
        } else if (Input.GetKeyDown (KeyCode.Alpha1)) {
            AttackData data = new AttackData () {
                Type = AttackType.Fire, 
                Damage = 10
            };
            m_Enemy.TakeDamage (data);
        } else if (Input.GetKeyDown (KeyCode.Alpha2)) {
            AttackData data = new AttackData () {
                Type = AttackType.Frozen, 
                Damage = 10
            };
            m_Enemy.TakeDamage (data);
        } else if (Input.GetKeyDown (KeyCode.Alpha3)) {
            AttackData data = new AttackData () {
                Type = AttackType.Lighting, 
                Damage = 10
            };
            m_Enemy.TakeDamage (data);
        } else if (Input.GetKeyDown (KeyCode.Alpha4)) {
            AttackData data = new AttackData () {
                Type = AttackType.Water, 
                Damage = 10
            };
            m_Enemy.TakeDamage (data);
        } else if (Input.GetKeyDown (KeyCode.Alpha5)) {
            AttackData data = new AttackData () {
                Type = AttackType.Normal, 
                Damage = 10
            };
            m_Enemy.TakeDamage (data);
        }
    }
    
}
