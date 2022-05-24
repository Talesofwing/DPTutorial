using UnityEngine;

public class UseBuilder : MonoBehaviour{

    private void Start () {
        IBuilder builder = new EnemyBuilder ();
        BuilderDirector director = new BuilderDirector (builder);

        director.CreateEnemy ();
    }
    
}
