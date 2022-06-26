using UnityEngine;

public class Character : MonoBehaviour, IMovable {
    [SerializeField] private float m_Speed = 5.0f;

    private Transform m_CacheTf;
    private BaseMovement m_Movement;

    private ICharacterState m_State;

    private int m_CurrentHP = 100;
    private bool m_IsDead = false;
    
    private void Awake () {
        m_CacheTf = this.transform;

        ChangeState (new CharacterNormalState ());
    }

    private void Update () {
        Move (Time.deltaTime);
    }

    private void Move (float dt) {
        m_Movement.Move (dt);
    }

    private void Death () {
        Debug.Log ("角色死亡!");

        m_IsDead = true;
    }

#region State

    /*
     * 對於外部的使用者來說
     * Attack和TakeDamage都是沒有變化的接口，能照常使用
     * 但是其行為卻發生了變化
     */

    public void Attack () {
        m_State.Attack ();
    }

    public void TakeDamage (int damage) {
        if (m_IsDead) {
            Debug.Log ("Character has died.");

            return;
        }
        
        Debug.Log ("Character TakeDamage: " + damage);
        int realDamage = m_State.TakeDamage(damage);
        m_CurrentHP -= realDamage;
        Debug.Log ("Character TakeDamage(real): " + realDamage);
        Debug.Log ("Character CurrentHP: " + m_CurrentHP);

        if (m_State.GetStateType () == CharacterState.Normal && m_CurrentHP <= 50) {
            ChangeState (new CharacterAngerState ());
        } else if (m_State.GetStateType () == CharacterState.Anger && m_CurrentHP <= 20) {
            ChangeState (new CharacterFeverState ());
        } else if (m_CurrentHP <= 0) {
            Death ();
        }
    }

    private void ChangeState (ICharacterState state) {
        Debug.Log ("Character ChangeState: " + state);
        m_State = state;
    }

#endregion

#region Strategy

    public void SetMovement (BaseMovement movement) {
        m_Movement = movement;
    }

#endregion

#region IMovable Implementation

    public Transform GetTransform () {
        return m_CacheTf;
    }

    public float GetSpeed () {
        return m_Speed;
    }

#endregion

}
