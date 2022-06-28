using System.Collections.Generic;
using PureMVC.Core;
using PureMVC.Interfaces;
using UnityEngine;
using PureMVC.Patterns.Facade;

public class MainPanelViewMediator : PureMVC.Patterns.Mediator.Mediator {
    public new const string NAME = "MAINPANELVIEWMEDIATOR";

    private MainPanelView _view;
    private PlayerDataProxy _playerDataProxy;
    private List<GameObject> _bonusItemLists = new List<GameObject> ();

    public MainPanelViewMediator (object viewComponent = null) :
            base (NAME, viewComponent) {

        // 獲取UI以及Data的Proxy
        _view = ((GameObject)ViewComponent).GetComponent<MainPanelView> ();
        Debug.Log ("Panel Mediator");
        _playerDataProxy = PureMVC.Patterns.Facade.Facade.GetInstance (() => new Facade ())
                                  .RetrieveProxy (PlayerDataProxy.NAME) as PlayerDataProxy;
        
        _view.GetButton.onClick.AddListener(OnClickGet);
    }

    public void OnClickGet () {
        Debug.Log ("Get");

        SendNotification (MyFacade.PLAY);
    }

    public override void HandleNotification (INotification notification) {
        switch (notification.Name) {
            case MyFacade.REFRESH_BONUS_UI:
                if (!_view.isActiveAndEnabled) {
                    _view.gameObject.SetActive (true);
                }

                break;
            case MyFacade.UPDATE_PLAYER_DATA:
                if (_playerDataProxy != null) {
                    _view.UpdateGamePlayCount (_playerDataProxy.PlayGameCount);
                    _view.UpdateRewardTotal (_playerDataProxy.RewardTotal);

                    // SendNotification (MyFacade.REWARD_TIP_VIEW, notification.Body);
                }

                break;
        }
    }

    public void AddItems (GameObject obj) {
        _bonusItemLists.Add (obj);
    }

    public GameObject BonusItem (int index) {
        return _bonusItemLists[index];
    }

    public int BonusitemCount {
        get { return _bonusItemLists.Count; }
    }

    public GameObject InstanceBonusItem () {
        return GameObjectUtility.CreateGameObject (_view.BonusItemTemplate, _view.ItemsRoot);
    }

    public override string[] ListNotificationInterests () {
        string[] list = {MyFacade.REFRESH_BONUS_UI, MyFacade.UPDATE_PLAYER_DATA};

        return list;
    }

}
