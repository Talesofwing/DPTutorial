using PureMVC.Patterns.Proxy;
using UnityEngine;

public class PlayerDataProxy : Proxy {
    public new static string NAME = "PLAYER_DATA";

    private PlayerDataModel _playerData;

    public int PlayGameCount => _playerData.PlayGameCount;
    public int RewardTotal => _playerData.RewardTotal;
    
    public PlayerDataProxy (string proxyName, object data = null) : base (proxyName, data) {
        _playerData = new PlayerDataModel ();
    }

    public void GetReward (int reward, string info) {
        _playerData.PlayGameCount++;
        _playerData.RewardTotal += reward;

        SendNotification (MyFacade.UPDATE_PLAYER_DATA);
        SendNotification (MyFacade.REWARD_TIP_VIEW, info + reward);
    }

    public override void OnRegister () {
        base.OnRegister ();
        Debug.Log ("PlayerDataProxy OnRegister");
    }
    
    public override void OnRemove () {
        base.OnRegister ();
        Debug.Log ("PlayerDataProxy OnRemove");
    }
    
}
