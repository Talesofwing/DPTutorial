public class BattleFeverViewController : IController {
    private BattleView m_View;
    private BattleModel m_Model;

    public BattleFeverViewController (BattleModel model, BattleView view) {
        m_Model = model;
        m_View = view;

        m_View.Init (this, model);
        m_Model.Initialize ();

        m_View.HideHeart ();
    }
    
    public void RemoveHeart () {
        
    }
    
}
