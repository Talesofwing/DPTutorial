using System;
using System.Collections.Concurrent;
using PureMVC.Interfaces;

// PureMVC的三大核心之一
// 相當於一個管理類，保存了Proxy的Map
namespace PureMVC.Core {

    public class Model : IModel {
        protected const string SingletonMsg = "Model Singleton already constructed!";

        protected readonly ConcurrentDictionary<string, IProxy> proxyMap;
        protected static IModel instance;

        public Model () {
            if (instance != null)
                throw new Exception (SingletonMsg);
            instance = this;
            proxyMap = new ConcurrentDictionary<string, IProxy> ();
            InitializeModel ();
        }

        protected virtual void InitializeModel () { }

        public static IModel GetInstance (Func<IModel> factory) {
            if (instance == null) {
                instance = factory ();
            }

            return instance;
        }

        public void RegisterProxy (IProxy proxy) {
            proxyMap[proxy.ProxyName] = proxy;
            proxy.OnRegister ();
        }

        public IProxy RetrieveProxy (string proxyName) {
            return proxyMap.TryGetValue (proxyName, out var proxy) ? proxy : null;
        }

        public IProxy RemoveProxy (string proxyName) {
            if (proxyMap.TryRemove (proxyName, out var proxy)) {
                proxy.OnRemove ();
            }

            return proxy;
        }

        public bool HasProxy (string proxyName) {
            return proxyMap.ContainsKey (proxyName);
        }
    }

}