using UnityEngine;

public class UseCompound : MonoBehaviour {
    [SerializeField] private BattleView m_View;

    private BattleViewController m_Controller;
    // private BattleFeverViewController m_Controller;
    
    private void Start () {
        BattleModel model = new BattleModel ();
        m_Controller = new BattleViewController (model, m_View);
        // m_Controller = new BattleFeverViewController (model, m_View);
    }
    
    private void Update () {
        if (Input.GetMouseButtonDown (0)) {
            m_Controller.RemoveHeart ();
        }
    }
    
}
