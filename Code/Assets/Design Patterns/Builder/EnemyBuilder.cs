using UnityEngine;

public class EnemyBuilder : IBuilder {
    
    public void CreateBody () {
        Debug.Log ("EnemyBuilder: CreateBody");
    }

    public void CreateWeapon () {
        Debug.Log ("EnemyBuilder: CreateWeapon");
    }

    public T GetResult<T> () {
        return default (T);
    }
    
}