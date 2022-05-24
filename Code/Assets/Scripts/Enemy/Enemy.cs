using UnityEngine;

// 攻擊屬性
public enum AttackType {
    Normal,
    Fire,
    Water,
    Frozen,
    Lighting,
}

public enum EnemyType {
    FireEnemy,
}

// 攻擊數據
public struct AttackData {
    public int Damage;
    public AttackType Type;
}

public abstract class Enemy : MonoBehaviour {
    // 因為享元模式，所以name可以去掉 (但是在原型模式中有使用，所以保留)
    [SerializeField] private string m_EnemyName;
    [SerializeField] private int m_StartingHealth;

    private EnemyBaseAttr m_Attr;
    
    private int m_CurrentHealth = 0;

    public bool Alive { get; protected set; }

    public void SetName (string name) {
        m_EnemyName = name;
    }
    
    public abstract EnemyType EType {
        get;
    }
    
    private void Awake () {
        Debug.Log ("Enemy Awake");

        // 每一次的Get都會有一定的性能損耗
        m_Attr = AttrFactory.Instance.GetEnemyBaseAttr (EType);
        Debug.Log ("Enemy Attr: " + m_Attr);
        
        m_CurrentHealth = m_StartingHealth;

        Alive = true;
    }

    private void Start () {
        Debug.Log ("Enemy Start");
    }

    public virtual void Death () {
        if (Alive) {
            Debug.Log (m_Attr.Name + " 死亡!");

            Alive = false;
        }
    }

    public virtual void Reset () {
        Debug.Log (m_Attr.Name + " 已重置!");
        
        Alive = true;
        m_CurrentHealth = m_StartingHealth;
    }

#region Template 方法例子
    
    // TakeDamage就是模板方法
    // 首先利用TakeDamageCondition判斷是否會受到傷害
    // 再利用CalculateDamage來計算傷害量
    public virtual void TakeDamage (AttackData data) {
        Debug.Log (m_Attr.Name + " 受到 " + AttackType2Chinese (data.Type) + data.Damage + " 點傷害");
        
        if (!Alive) {
            Debug.Log (m_Attr.Name + " 已經死亡!");
            return;
        }
        
        // 判斷是否會受到傷害 (由子類判斷)
        if (TakeDamageCondition (data)) {
            // 計算傷害 (由子類計算)
            int damage = CalculateDamage (data);
            m_CurrentHealth -= damage;
            Debug.Log (m_Attr.Name + " 失去了 " + damage + " 點生命值");
            
            if (m_CurrentHealth <= 0) {
                Death ();
            } else {
                Debug.Log (m_Attr.Name + "剩餘生活值: " + m_CurrentHealth);
            }
        }
    }
    
    // 能夠受到傷害的條件判斷由子類完成
    protected abstract bool TakeDamageCondition (AttackData data);
    
    // 計算受到的傷害的具體值
    protected abstract int CalculateDamage (AttackData data);
    
#endregion
    
#region 工具方法

    public string AttackType2Chinese (AttackType type) {
        switch (type) {
            case AttackType.Fire:
                return "火屬性";
            case AttackType.Lighting:
                return "雷屬性";
            case AttackType.Frozen:
                return "冰屬性";
            case AttackType.Normal:
                return "無屬性";
            case AttackType.Water:
                return "水屬性";
            default:
                return "出錯啦!";
        }
    } 
    
#endregion

    public override string ToString () {
        return "EnemyName: " + m_Attr.Name + " Hp: " + m_CurrentHealth;
    }
}
