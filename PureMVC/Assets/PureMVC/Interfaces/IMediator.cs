using System;

namespace PureMVC.Interfaces {

    // Mediator的接口類，Mediator是UI的上層模塊
    // 會持有自身所對應的UI (ViewComponent)
    // 對感興趣的事件則由ListNotificationInterests () 返回
    // 而Mediator會接收Notification (HandleNotification)
    public interface IMediator {
        string MediatorName { get; }
        object ViewComponent { get; set; }
        string[] ListNotificationInterests ();
        void HandleNotification (INotification notification);
        void OnRegister ();
        void OnRemove ();
    }

}