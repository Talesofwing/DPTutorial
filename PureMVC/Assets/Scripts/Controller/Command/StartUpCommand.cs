using PureMVC.Interfaces;
using PureMVC.Patterns.Command;
using UnityEngine;

/// <summary>
/// 程序啟動的Command
/// 可以在這裏注冊Mediator
/// </summary>
public class StartUpCommand : SimpleCommand {
   
   public override void Execute (INotification notification) {
      // Create UI
      GameObject obj = GameObjectUtility.CreateGameObject ("MainPanelView");
      
      // Bind mediator
      Facade.RegisterMediator (new MainPanelViewMediator (obj));
      
      // Update 12 items.
      SendNotification (MyFacade.REFRESH_BONUS_ITEMS);
      SendNotification (MyFacade.UPDATE_PLAYER_DATA);
   }
   
}
