using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UseIteratorAndComposite : MonoBehaviour {
    private MapNode m_Root; 
    
    private void Start () {
        m_Root = new LayerNode ();

        LayerNode treeLayer = new LayerNode ();
        treeLayer.AddChild (new TreeNode());
        treeLayer.AddChild (new TreeNode());

        LayerNode npcLayer = new LayerNode ();
        npcLayer.AddChild (new NPCNode());
        npcLayer.AddChild (new NPCNode());
        npcLayer.AddChild (new NPCNode());

        m_Root.AddChild (new HouseNode());
        m_Root.AddChild (treeLayer);
        m_Root.AddChild (npcLayer);

        // m_Root.Display ();
        
        Print ();
    }

    private void Print () {
        IEnumerator<MapNode> iterator = m_Root.CreateIterator ();
        while (iterator.MoveNext ()) {
            MapNode node = iterator.Current;

            if (node is LayerNode) {
                Debug.Log ("---Layer Node---");
            } else {
                node.Display ();
            }
        }
    }
    
}
