using PureMVC.Interfaces;
using PureMVC.Patterns.Command;
using UnityEngine;

public class PlayCommand : SimpleCommand {

   /// <summary>
   /// 點擊"隨機獲取"得的Command
   /// 隨機獲得一種BonusItem
   /// </summary>
   public override void Execute (INotification notification) {
      BonusProxy bonus = MyFacade.GetInstance ().RetrieveProxy (BonusProxy.NAME) as BonusProxy;
      int id = Random.Range (0, bonus.BonusCount);

      Debug.Log ("result:" + bonus.BonusLists[id].Name + "," + bonus.BonusLists[id].Reward);

      PlayerDataProxy playerData = Facade.RetrieveProxy (PlayerDataProxy.NAME) as PlayerDataProxy;
      if (playerData != null) {
         playerData.GetReward (bonus.BonusLists[id].Reward, bonus.BonusLists[id].Name);
         Debug.Log ("================PlayCommand");
      }
   }

}
