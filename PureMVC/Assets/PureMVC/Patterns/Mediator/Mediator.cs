using System;
using System.Collections.Generic;
using PureMVC.Interfaces;
using PureMVC.Patterns.Observer;

namespace PureMVC.Patterns.Mediator {

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