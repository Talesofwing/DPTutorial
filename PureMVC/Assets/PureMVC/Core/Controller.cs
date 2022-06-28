using System;
using System.Collections.Concurrent;
using PureMVC.Interfaces;
using PureMVC.Patterns.Observer;

// PureMVC的三大核心之一
// 相當於一個管理類，保存了Command的Map
// 每一個Command都會向View注冊一個Observer，當Notification發生時，View就會執行ExecuteCommand ()
namespace PureMVC.Core {

    public class Controller : IController {
        protected const string SingletonMsg = "Controller Singleton already constructed!";

        protected IView view;
        protected readonly ConcurrentDictionary<string, Func<ICommand>> commandMap;
        protected static IController instance;

        public Controller () {
            if (instance != null)
                throw new Exception (SingletonMsg);
            
            instance = this;
            commandMap = new ConcurrentDictionary<string, Func<ICommand>> ();
            InitializeController ();
        }

        protected virtual void InitializeController () {
            view = View.GetInstance (() => new View ());
        }

        public static IController GetInstance (Func<IController> factory) {
            if (instance == null) {
                instance = factory ();
            }

            return instance;
        }

        /// <summary>
        /// 注冊Command後，會往View注冊新的Observer，回調函數為ExecuteCommand
        /// </summary>
        public void RegisterCommand (string notificationName, Func<ICommand> factory) {
            if (commandMap.TryGetValue (notificationName, out _) == false) {
                view.RegisterObserver (notificationName, new Observer (ExecuteCommand, this));
            }
            commandMap[notificationName] = factory;
        }

        /// <summary>
        /// 事件通知的callback函數
        /// </summary>
        public void ExecuteCommand (INotification notification) {
            if (commandMap.TryGetValue (notification.Name, out var factory)) {
                var commandInstance = factory ();
                commandInstance.Execute (notification);
            }
        }

        public void RemoveCommand (string notificationName) {
            if (commandMap.TryRemove (notificationName, out _)) {
                view.RemoveObserver (notificationName, this);
            }
        }

        public bool HasCommand (string notificationName) {
            return commandMap.ContainsKey (notificationName);
        }
    }

}