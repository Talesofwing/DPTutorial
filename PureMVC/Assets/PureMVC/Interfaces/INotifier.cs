namespace PureMVC.Interfaces {

    // 事件通知系統中的發送者Notifier的接口類
    // 具體實現時，會創建INotification，並且通知所有的Observer，將INotification傳給Observer
    public interface INotifier {
        void SendNotification (string notificationName,
                               object body = null, string type = null);
    }

}