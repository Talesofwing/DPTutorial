using System.Collections.Generic;
using UnityEngine;

// 要與Block交互的話，要滿足InteractionConditions的條件
// 這裏的Conditions其實相當於"命令"
public class Block {
    private List<BaseCondition> m_InteractionConditions = new List<BaseCondition> (); // 交互條件

    public bool CanInteract () {
        for (int i = 0; i < m_InteractionConditions.Count; ++i) {
            if (!m_InteractionConditions[i].Check ()) {
                Debug.Log ("不能交互!");
                return false;
            }
        }
        
        // 交互成功
        Debug.Log ("可以交互");
        return true;
    }

    public void Interact () {
        Debug.Log ("交互!");
    }
    
    public void AddCondition (BaseCondition condition) {
        m_InteractionConditions.Add (condition);
    }

    public void RemoveCondition (BaseCondition condition) {
        m_InteractionConditions.Remove (condition);
    }
    
}
    
