using UnityEngine;

public class PlayerStateMemento {
    public Vector3 Position {
        get;
        set;
    }

    public PlayerStateMemento (Vector3 pos) {
        Position = pos;
    }
    
}
