using System;

namespace PureMVC.Interfaces {

    // 事件通知系統中的監聽器Observer的接口類
    public interface IObserver {
        Action<INotification> NotifyMethod { set; get; }    // callback函數
        object NotifyContext { set; }                       // 監聽器持有者
        void NotifyObserver (INotification notification);
        bool CompareNotifyContext (object obj);
    }

}