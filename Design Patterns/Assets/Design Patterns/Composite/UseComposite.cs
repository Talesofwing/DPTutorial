using UnityEngine;

public class UseComposite : MonoBehaviour {

    private void Start () {
        LayerNode root = new LayerNode ();

        LayerNode treeLayer = new LayerNode ();
        treeLayer.AddChild (new TreeNode());
        treeLayer.AddChild (new TreeNode());

        LayerNode npcLayer = new LayerNode ();
        npcLayer.AddChild (new NPCNode());
        npcLayer.AddChild (new NPCNode());
        npcLayer.AddChild (new NPCNode());

        root.AddChild (new HouseNode());
        root.AddChild (treeLayer);
        root.AddChild (npcLayer);

        Debug.Log ("Display Root節點");
        root.Display ();
        
        Debug.Log ("Display Tree節點");
        treeLayer.Display ();
        
        Debug.Log ("Display NPC節點");
        npcLayer.Display ();
    }

}
