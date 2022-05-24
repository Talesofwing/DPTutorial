// 敵人基础屬性

using System;

public class EnemyBaseAttr {
    private string m_Name;
    private int m_StartingHP;
    private int m_Damage;
    private float m_MoveSpeed;

    public string Name {
        get => m_Name;
    }

    public int StartingHP {
        get => m_StartingHP;
    }

    public int Damage {
        get => m_Damage;
    }

    public float MoveSpeed {
        get => m_MoveSpeed;
    }
    
    public EnemyBaseAttr (string name, int hp, int damage, float moveSpeed) {
        m_Name = name;
        m_StartingHP = hp;
        m_Damage = damage;
        m_MoveSpeed = moveSpeed;
    }

    public override string ToString () {
        return String.Format ("Name: " + m_Name + ", HP: " + m_StartingHP + ", Damage: " + m_Damage + ", MoveSpeed: " +
                              m_MoveSpeed);
    }
    
}