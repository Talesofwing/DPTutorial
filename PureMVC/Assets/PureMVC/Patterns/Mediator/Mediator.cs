using PureMVC.Interfaces;
using PureMVC.Patterns.Observer;

namespace PureMVC.Patterns.Mediator {

    // IMediator的實現
    // 因為會發送事件，所以也是Notifier
    public class Mediator : Notifier, IMediator {
        public static string NAME = "Mediator";

        public string MediatorName { get; protected set; }
        public object ViewComponent { get; set; }

        public Mediator (string mediatorName, object viewComponent = null) {
            MediatorName = mediatorName ?? NAME;
            ViewComponent = viewComponent;
        }

        public virtual string[] ListNotificationInterests () {
            return new string[0];
        }

        public virtual void HandleNotification (INotification notification) { }

        public virtual void OnRemove () { }

        public void OnRegister () { }
    }

}