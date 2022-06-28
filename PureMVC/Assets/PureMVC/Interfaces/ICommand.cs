using System;

namespace PureMVC.Interfaces {

    // Command的接口類
    // Command是消息的發信者
    public interface ICommand : INotifier {
        void Execute (INotification notification);
    }

}