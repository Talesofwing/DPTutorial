using UnityEngine;

public class UseObserver : MonoBehaviour, IModuleObserver, IPlayerModuleListener {

    private void Start () {
        Debug.Log (PlayerModule.GetInstance<PlayerModule> ());

        ObserverTest ();

        EventDelegateTest ();
    }

    private void ObserverTest () {
        Debug.Log ("觀察者模式");
        
        PlayerModule.GetInstance<PlayerModule> ().AddObserver (this);
        
        PlayerModule.GetInstance<PlayerModule> ().Atk += 1;
        PlayerModule.GetInstance<PlayerModule> ().Hp += 1;
        PlayerModule.GetInstance<PlayerModule> ().Def += 1;
        
        PlayerModule.GetInstance<PlayerModule> ().RemoveObserver (this);
        
        PlayerModule.GetInstance<PlayerModule> ().Atk += 1;
        PlayerModule.GetInstance<PlayerModule> ().Hp += 1;
        PlayerModule.GetInstance<PlayerModule> ().Def += 1;
    }

    private void EventDelegateTest () {
        Debug.Log ("事件與委托");
        
        PlayerModule.GetInstance<PlayerModule> ().AddListener (this);
        
        PlayerModule.GetInstance<PlayerModule> ().Hp += 1;
        PlayerModule.GetInstance<PlayerModule> ().Def += 1;
        
        PlayerModule.GetInstance<PlayerModule> ().RemoveListener (this);
        
        PlayerModule.GetInstance<PlayerModule> ().Hp += 1;
        PlayerModule.GetInstance<PlayerModule> ().Def += 1;
    }
    
    // Observer
    public void OnModuleChanged () {
        Debug.Log (PlayerModule.GetInstance<PlayerModule> ());
    }

    public void OnPlayerModuleChanged (BaseModule sender, PlayerModuleData data) {
        switch (data.Type) {
            case PlayerModuleChangeEventType.Hp:
                Debug.Log("血量改變了: " + data.Hp);
                break;
            case PlayerModuleChangeEventType.Atk:
                Debug.Log("攻擊力改變了: " + data.Atk);
                break;
            case PlayerModuleChangeEventType.Def:
                Debug.Log("防禦力改變了: " + data.Def);
                break;
        }
    }
    
}
