using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CubeEnemy : BaseEnemy {

    public override EnemyType GetEnemyType () {
        return EnemyType.Cube;
    }
    
}
