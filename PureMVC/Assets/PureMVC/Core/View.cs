using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using PureMVC.Interfaces;
using PureMVC.Patterns.Observer;
using UnityEngine;

namespace PureMVC.Core {

    public class View : IView {
        protected const string SingletonMsg = "View Singleton already constructed!";

        protected readonly ConcurrentDictionary<string, IMediator> mediatorMap;
        protected readonly ConcurrentDictionary<string, IList<IObserver>> observerMap;
        protected static IView instance;

        protected virtual void InitializeView () { }

        public View () {
            if (instance != null)
                throw new Exception (SingletonMsg);
            
            instance = this;
            mediatorMap = new ConcurrentDictionary<string, IMediator> ();
            observerMap = new ConcurrentDictionary<string, IList<IObserver>> ();
            InitializeView ();
        }

        public static IView GetInstance (Func<IView> factory) {
            if (instance == null) {
                instance = factory ();
            }

            return instance;
        }

        public void RegisterObserver (string notificationName, IObserver observer) {
            if (observerMap.TryGetValue (notificationName, out var observers)) {
                observers.Add (observer);
            } else {
                observerMap.TryAdd (notificationName, new List<IObserver> {observer});
            }
        }

        public void RemoveObserver (string notificationName, object notifyContext) {
            if (observerMap.TryGetValue (notificationName, out var observers)) {
                for (var i = 0; i < observers.Count; i++) {
                    if (observers[i].CompareNotifyContext (notifyContext)) {
                        observers.RemoveAt (i);

                        break;
                    }
                }

                if (observers.Count == 0)
                    observerMap.TryRemove (notificationName, out _);
            }
        }

        public void NotifyObservers (INotification notification) {
            if (observerMap.TryGetValue (notification.Name, out var observersRef)) {
                var observers = new List<IObserver> (observersRef);

                foreach (var observer in observers) {
                    observer.NotifyObserver (notification);
                }
            }
        }

        public void RegisterMediator (IMediator mediator) {
            if (mediatorMap.TryAdd (mediator.MediatorName, mediator)) {
                var interests = mediator.ListNotificationInterests ();
                if (interests.Length > 0) {
                    IObserver observer = new Observer (mediator.HandleNotification, mediator);

                    foreach (var interest in interests) {
                        RegisterObserver (interest, observer);
                    }
                }
                mediator.OnRegister ();
            }
        }

        public IMediator RetrieveMediator (string mediatorName) {
            return mediatorMap.TryGetValue(mediatorName, out var mediator) ? mediator : null;
        }

        public IMediator RemoveMediator (string mediatorName) {
            if (mediatorMap.TryRemove (mediatorName, out var mediator)) {
                var interests = mediator.ListNotificationInterests ();
                foreach (var interest in interests) {
                    RemoveObserver (interest, mediator);
                }

                mediator.OnRemove ();
            }

            return mediator;
        }

        public bool HasMediator (string mediatorName) {
            return mediatorMap.ContainsKey (mediatorName);
        }
    }

}