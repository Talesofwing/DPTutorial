using UnityEngine;
using UnityEngine.UI;

public class BattleView : MonoBehaviour, IBattleModelObserver {
    [SerializeField] private Text m_HeartText;
    
    private IController m_Controller;
    private BattleModel m_Model;

    public void Init (IController controller, BattleModel model) {
        m_Model = model;
        m_Controller = controller;
        
        m_Model.RegisterObserver (this);
    }
    
    public void UpdateBattleModel () {
        m_HeartText.text = "Hearts: " + m_Model.HeartCount.ToString ();
    }

    public void HideHeart () {
        m_HeartText.text = "";
    }
    
    private void OnDestroy () {
        m_Model.UnregisterObserver (this);
    }
}
