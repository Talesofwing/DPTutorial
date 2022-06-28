using PureMVC.Interfaces;

namespace PureMVC.Patterns.Observer {

    // INotifier的實現
    // 由於經常會使用Facade，所以保存了Facade的單例引用
    public class Notifier : INotifier {
        public void SendNotification (string notificationName, object body = null, string type = null) {
            Facade.SendNotification (notificationName, body, type);
        }

        protected IFacade Facade {
            get {
                return Patterns.Facade.Facade.GetInstance (() => new Facade.Facade ());
            }
        }
    }

}