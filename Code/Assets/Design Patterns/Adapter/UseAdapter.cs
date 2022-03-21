using UnityEngine;

public class UseAdapter : MonoBehaviour {

    private void Start () {
        BaseItem item = new RedPotion ();
        item.Use ();
        item.Display ();
        item.TakeIt ();

        BaseOldItem bluePotion = new BluePotion ();
        BaseItem adapter = new ItemAdapter (bluePotion);
        adapter.Use ();
        adapter.Display ();
        adapter.TakeIt ();
    }
    
}
