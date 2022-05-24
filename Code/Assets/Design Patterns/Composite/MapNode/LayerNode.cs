using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Coposite
/// </summary>
public class LayerNode : MapNode {
    private List<MapNode> m_Notes = new List<MapNode> ();

    public override void AddChild (MapNode node) {
        m_Notes.Add (node);
    }

    public override void RemoveChild (MapNode node) {
        m_Notes.Remove (node);
    }
    
    public override void Display () {
        Debug.Log ("LayerNode");
        
        for (int i = 0; i < m_Notes.Count; i++) {
            m_Notes[i].Display ();
        }
    }
    
#region Iterator & Composite

    public override IEnumerator<MapNode> CreateIterator () {
        return new NodeIterator (m_Notes.GetEnumerator ());
    }

#endregion
    
}