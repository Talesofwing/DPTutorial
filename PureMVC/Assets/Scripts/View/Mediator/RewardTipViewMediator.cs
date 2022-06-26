using System.Collections.Generic;
using PureMVC.Patterns.Mediator;
using UnityEngine;
using PureMVC.Interfaces;

public class RewardTipViewMediator : Mediator {
    public new const string NAME = "REWARDTIPVIEWMEDIATOR";

    private RewardTipView _view;

    public RewardTipViewMediator (object viewComponent = null) :
            base (NAME, viewComponent) {

        _view = ((GameObject)ViewComponent).GetComponent<RewardTipView> ();
        Debug.Log ("RewardTip Mediator");

        _view.BackButton.onClick.AddListener (OnClickBack);
    }

    public void OnClickBack () {
        _view.gameObject.SetActive (false);

        SendNotification (MyFacade.REFRESH_BONUS_ITEMS);
    }

    public override string[] ListNotificationInterests () {
        string[] list = {MyFacade.UPDATE_REWARD_TIP_VIEW};

        return list;
    }

    public override void HandleNotification (INotification notification) {
        switch (notification.Name) {
            case MyFacade.UPDATE_REWARD_TIP_VIEW:
                if (!_view.isActiveAndEnabled) {
                    _view.gameObject.SetActive (true);
                }
                string text = notification.Body as string;
                //update text
                Debug.Log (text);
                _view.SetText (text);

                break;
        }
    }

}