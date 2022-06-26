public class BattleViewController : IController {
    private BattleView m_View;
    private BattleModel m_Model;

    public BattleViewController (BattleModel model, BattleView view) {
        m_Model = model;
        m_View = view;

        m_View.Init (this, model);
        m_Model.Initialize ();
    }
    
    public void RemoveHeart () {
        m_Model.HeartCount--;
    }
    
}
