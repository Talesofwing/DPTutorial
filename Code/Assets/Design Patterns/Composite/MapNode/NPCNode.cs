using UnityEngine;

/// <summary>
/// Leaf
/// </summary>
public class NPCNode : MapNote {

    public override void AddChild (MapNote node) { }
    
    public override void RemoveChild (MapNote node) { }
    
    public override void Display () {
        Debug.Log ("NPC節點");
    }
    
}