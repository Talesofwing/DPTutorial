using UnityEngine;

/// <summary>
/// Leaf
/// </summary>
public class HouseNode : MapNote {
    
    public override void AddChild (MapNote node) { }
    
    public override void RemoveChild (MapNote node) { }
    
    public override void Display () {
        Debug.Log ("HouseNode節點");
    }
    
}