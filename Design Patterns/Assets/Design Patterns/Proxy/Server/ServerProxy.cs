using System;
using UnityEngine;

public enum ServerType {
    Sql,
    Windows,
    ServerN,
}

/// <summary>
/// 作為服務器的中間人，可以隱藏具體使用的是哪個服務器
/// 封裝了"服務器"相關的具體邏輯
/// </summary>
public class ServerProxy : IServer {
    private IServer m_CurrentServer;

#region Singleton

    // 採用了Lazy的方法的單例模式
    private static Lazy<ServerProxy> m_Instance = new Lazy<ServerProxy> (() => new ServerProxy ());

    public static ServerProxy GetInstance () {
        return m_Instance.Value;
    }

    private ServerProxy () { }

#endregion
    
    public void Login (string name, string password) {
        m_CurrentServer.Login(name, password);
    }
    
    public void Quit () {
        m_CurrentServer.Quit ();
    }
    
    public void LoginTime () {
        m_CurrentServer.LoginTime ();
    }
    
    public void QuitTime () {
        m_CurrentServer.QuitTime ();
    }

    // 更好的做法是將Proxy寫在Manager裏的
    // 這樣就只有Manager能調用SwitchServer方法
    public void SwitchServer (ServerType type) {
        Debug.Log ("切換到" + type.ToString () + "服務器");
        
        switch (type) {
            case ServerType.Sql:
                m_CurrentServer = new SqlServer ();

                break;
            case ServerType.Windows:
                m_CurrentServer = new WindowsServer ();
                
                break;
            case ServerType.ServerN:
                m_CurrentServer = new ServerN ();
                
                break;
            default:
                Debug.Log ("輸入無效!");

                break;
        }
    }

}
