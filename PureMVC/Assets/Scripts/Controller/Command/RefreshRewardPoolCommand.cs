using PureMVC.Interfaces;
using PureMVC.Patterns.Command;
using UnityEngine;

public class RefreshRewardPoolCommand : SimpleCommand {

   public override void Execute (INotification notification) {
      BonusProxy bonus = Facade.RetrieveProxy (BonusProxy.NAME) as BonusProxy;
      if (bonus != null) {
         bonus.Clear ();
         bonus.CreateRewardPool (12);

         Debug.Log ("start REFRESH_BONUS_UI");

         MainPanelViewMediator mediator = Facade.RetrieveMediator (MainPanelViewMediator.NAME) as MainPanelViewMediator;
         if (mediator == null) {
            Debug.LogError("[RefreshRewardPoolCommand]: 沒有找到名字為" + MainPanelViewMediator.NAME + "的Mediator");

            return;
         }
         
         // 是不是第一次創建
         bool newCreate = mediator.BonusitemCount == 0;
         
         GameObject obj = null;
         for (int i = 0; i < bonus.BonusCount; ++i) {
            if (newCreate) {
               obj = mediator.InstanceBonusItem ();
               obj.SetActive (true);
            } else {
               obj = mediator.BonusItem (i);
            }
            
            BonusItem item = obj.GetComponent<BonusItem> ();
            if (item != null) {
               item.UpdateItem (bonus.BonusLists[i]);
            }
            
            mediator.AddItems (obj);
         }
         
         SendNotification (MyFacade.REFRESH_BONUS_UI);

         Debug.Log ("Refresh Reward Pool Command done");
      }

   }
   
}
