using System;

namespace PureMVC.Interfaces {

    // Model的接口類
    public interface IModel {
        void RegisterProxy (IProxy proxy);
        IProxy RetrieveProxy (string proxyName);
        IProxy RemoveProxy (string proxyName);
        bool HasProxy (string proxyName);
    }

}