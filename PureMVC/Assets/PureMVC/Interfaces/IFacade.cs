using System;

namespace PureMVC.Interfaces {

    // Facade的接口類，是Controller、View、Model接口的一個大集合
    // 包含了IController、IView、IModel的接口
    // 並且Facade自身也是一個消息發信者 (通過View來發送)
    public interface IFacade : INotifier {
        void RegisterProxy (IProxy proxy);
        IProxy RetrieveProxy (string proxyName);
        IProxy RemoveProxy (string proxyName);
        bool HasProxy (string proxyName);

        void RegisterCommand (string notificationName, Func<ICommand> factory);
        void RemoveCommand (string notificationName);
        bool HasCommand (string notificationName);

        void RegisterMediator (IMediator mediator);
        IMediator RetrieveMediator (string mediatorName);
        IMediator RemoveMediator (string mediatorName);
        bool HasMediator (string mediatorName);
        void NotifyObservers (INotification notification);
    }

}