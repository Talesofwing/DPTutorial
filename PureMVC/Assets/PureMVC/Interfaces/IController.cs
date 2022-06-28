using System;

namespace PureMVC.Interfaces {

    // Controller的接口類
    public interface IController {
        void RegisterCommand (string notificationName, Func<ICommand> factory);
        void ExecuteCommand (INotification notification);
        void RemoveCommand (string notificationName);
        bool HasCommand (string notificationName);
    }

}