using PureMVC.Interfaces;
using PureMVC.Patterns.Command;
using UnityEngine;

/// <summary>
/// 顯示RewardTip頁面的Command
/// </summary>
public class RewardTipCommand : SimpleCommand {
   
   public override void Execute (INotification notification) {
      RewardTipViewMediator mediator = Facade.RetrieveMediator(RewardTipViewMediator.NAME) as RewardTipViewMediator;
      
      if (mediator == null) {
         GameObject obj = GameObjectUtility.CreateGameObject ("RewardTipView");
         mediator = new RewardTipViewMediator (obj);
         Facade.RegisterMediator (mediator);
      }

      SendNotification (MyFacade.UPDATE_REWARD_TIP_VIEW, notification.Body);
   }
   
}
