using System;

namespace PureMVC.Interfaces {

    // 事件通知系統中的事件Notification的接口類
    // 每一次的事件通知，都需要創建INotificationt並發送
    public interface INotification {
        string Name { get; }         // 事件名稱
        object Body { get; set; }    // 消息發送者
        string Type { get; set; }    // 事件類型
        string ToString ();
    }

}