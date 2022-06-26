using System;
using PureMVC.Core;
using PureMVC.Interfaces;
using PureMVC.Patterns.Observer;
using UnityEngine;

namespace PureMVC.Patterns.Facade {

    public class Facade : IFacade {
        protected static IFacade instance;
        
        protected IController controller;
        protected IModel model;
        protected IView view;

        protected const string SingletonMsg = "Facade Singleton already constructed!";
        
        public Facade () {
            if (instance != null) throw new Exception(SingletonMsg);
            instance = this;
            InitializeFacade ();
        }

        protected virtual void InitializeFacade () {
            InitializeModel();
            InitializeController();
            InitializeView();
        }

        public static IFacade GetInstance (Func<IFacade> facadeFunc) {
            if (instance == null) {
                instance = facadeFunc ();
            }

            return instance;
        }
        
        protected virtual void InitializeModel () {
            model = Model.GetInstance(() => new Model());
        }
        
        protected virtual void InitializeController () {
            controller = Controller.GetInstance(() => new Controller());
        }
        
        protected virtual void InitializeView () {
            view = View.GetInstance(() => new View());
        }
        
        public void SendNotification (string notificationName, object body = null, string type = null) {
            NotifyObservers (new Notification (notificationName, body, type));
        }

        public void RegisterProxy (IProxy proxy) {
            model.RegisterProxy (proxy);
        }

        public IProxy RetrieveProxy (string proxyName) {
            return model.RetrieveProxy (proxyName);
        }

        public IProxy RemoveProxy (string proxyName) {
            return model.RemoveProxy (proxyName);
        }

        public bool HasProxy (string proxyName) {
            return model.HasProxy (proxyName);
        }

        public void RegisterCommand (string notificationName, Func<ICommand> factory) {
            controller.RegisterCommand (notificationName, factory);
        }

        public void RemoveCommand (string notificationName) {
            controller.RemoveCommand (notificationName);
        }

        public bool HasCommand (string notificationName) {
            return controller.HasCommand (notificationName);
        }

        public void RegisterMediator (IMediator mediator) {
            view.RegisterMediator (mediator);
        }

        public IMediator RetrieveMediator (string mediatorName) {
            return view.RetrieveMediator (mediatorName);
        }

        public IMediator RemoveMediator (string mediatorName) {
            return view.RemoveMediator (mediatorName);
        }

        public bool HasMediator (string mediatorName) {
            return view.HasMediator (mediatorName);
        }

        public void NotifyObservers (INotification notification) {
            view.NotifyObservers (notification);
        }
    }

}