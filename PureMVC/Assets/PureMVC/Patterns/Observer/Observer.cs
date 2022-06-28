using System;
using PureMVC.Interfaces;

namespace PureMVC.Patterns.Observer {

    // IObserver的實現
    // 保存callback以及
    public class Observer : IObserver {
        public Action<INotification> NotifyMethod { get; set; }    // callback
        public object NotifyContext { get; set; }        // 關注的主題 (一般是Controller)

        public Observer (Action<INotification> notifyMethod, object notifyContext) {
            NotifyMethod = notifyMethod;
            NotifyContext = notifyContext;
        }
        
        public void NotifyObserver (INotification notification) {
            NotifyMethod (notification);
        }

        public virtual bool CompareNotifyContext (object obj) {
            return NotifyContext.Equals (obj);
        }
        
    }

}