using UnityEngine;

public class SphereEnemy : BaseEnemy {
    
    public override EnemyType GetEnemyType () {
        return EnemyType.Sphere;
    }
    
}
