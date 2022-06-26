using UnityEngine;

// References: https://www.gdquest.com/tutorial/godot/design-patterns/mediator/

/// <summary>
/// 通過GUI，將各系統之間的耦合解除
/// </summary>
public class GUI : MonoBehaviour {
    [SerializeField] private GameObject m_Button1;
    [SerializeField] private GameObject m_Button2;

    private void Start () {
        RefreshUI ();
    }
    
    public void RefreshUI () {
        m_Button1.SetActive (InventorySystem.Instance.HasItem (1));
        m_Button2.SetActive (InventorySystem.Instance.HasItem (2));
    }

    /// <summary>
    /// 1. 得到配方
    /// 2. 判斷是否有道具
    /// 3. 制作
    /// 4. 刪除配方中的道具
    /// 5. 新增制作了的道具
    /// 6. 更新UI
    /// </summary>
    
    public void OnButton1Click () {
        RecipeSystem.Instance.GetRecipe (1);
        if (InventorySystem.Instance.HasItem (2)) {
            CraftSystem.Instance.Craft (1);
            InventorySystem.Instance.RemoveItem (2);
            InventorySystem.Instance.AddItem (1);
            RefreshUI ();
        }
    }

    public void OnButton2Click () {
        RecipeSystem.Instance.GetRecipe (2);
        if (InventorySystem.Instance.HasItem (1)) {
            CraftSystem.Instance.Craft (2);
            InventorySystem.Instance.RemoveItem (1);
            InventorySystem.Instance.AddItem (2);
            RefreshUI ();
        }
    }
    
}
