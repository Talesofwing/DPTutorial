using System.Collections.Generic;

/// <summary>
/// Coposite
/// </summary>
public class LayerNode : MapNote {
    private List<MapNote> m_Notes = new List<MapNote> ();

    public override void AddChild (MapNote node) {
        m_Notes.Add (node);
    }

    public override void RemoveChild (MapNote node) {
        m_Notes.Remove (node);
    }
    
    public override void Display () {
        for (int i = 0; i < m_Notes.Count; i++) {
            m_Notes[i].Display ();
        }
    }
    
}