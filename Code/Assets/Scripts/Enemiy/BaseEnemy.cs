using UnityEngine;

public enum EnemyType {
    Cube,
    Sphere,
}

public abstract class BaseEnemy : MonoBehaviour {

    public virtual void Init () {
        Debug.Log (this.name + "(" + GetEnemyType () + ")" + " 初始化.");
    }

    public abstract EnemyType GetEnemyType ();

}
