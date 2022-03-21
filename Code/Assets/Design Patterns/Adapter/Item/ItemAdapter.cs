using UnityEngine;

public class ItemAdapter : BaseItem {
    private BaseOldItem m_Item;

    public ItemAdapter () {
        m_Item = new BluePotion ();
    }

    public ItemAdapter (BaseOldItem item) {
        m_Item = item;
    }
    
    public override void Use () {
        Debug.Log ("舊道具的適配器使用!");
        m_Item.UseItem ();
    }
    
    public override void Display () {
        Debug.Log ("舊道具的適配器!");
    }

}