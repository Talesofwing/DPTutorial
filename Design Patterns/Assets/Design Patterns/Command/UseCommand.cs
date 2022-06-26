using UnityEngine;

public class UseCommand : MonoBehaviour {

    private void Start () {
        Block block = new Block ();

        BaseCondition condition = new HasItemsCondition ();
        BaseCondition condition2 = new HoldItemCondition ();

        block.AddCondition (condition);
        block.AddCondition (condition2);

        if (block.CanInteract ()) {
            block.Interact ();
        }

        block.RemoveCondition (condition);
        if (block.CanInteract ()) {
            block.Interact ();
        }
    }
    
}
