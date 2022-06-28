namespace PureMVC.Interfaces {

    // Proxy的接口類，是數據的上層模塊
    // Proxy會提供操作或訪問數據的接口
    public interface IProxy {
        string ProxyName { get; }
        object Data { get; set; }
        void OnRegister ();
        void OnRemove ();
    }

}