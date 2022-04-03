using UnityEngine;

/// <summary>
/// Leaf
/// </summary>
public class TreeNode : MapNote {
    
    public override void AddChild (MapNote node) { }
    
    public override void RemoveChild (MapNote node) { }
    
    public override void Display () {
        Debug.Log ("Tree節點");
    }
    
}