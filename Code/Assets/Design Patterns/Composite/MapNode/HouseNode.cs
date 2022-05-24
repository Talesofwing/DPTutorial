using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Leaf
/// </summary>
public class HouseNode : MapNode {
    
    public override void AddChild (MapNode node) { }
    
    public override void RemoveChild (MapNode node) { }
    
    public override void Display () {
        Debug.Log ("HouseNode節點");
    }
    
#region Iterator & Composite

    public override IEnumerator<MapNode> CreateIterator () {
        return new NULLIterator ();
    }

#endregion
    
}