using PureMVC.Interfaces;

namespace PureMVC.Patterns.Observer {

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