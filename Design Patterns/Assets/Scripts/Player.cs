using UnityEngine;

public class Player {

#region Proxy

    private string m_Account = "F";
    private string m_Password = "123";

    public bool Logined { get; private set; } = false;

    // 玩家作為Server的使用者，並不需要知道目前的程序中使用的是哪一種Server
    // ServerProxy提供了接口，所以Player不需要開心這些細節

    public void Login () {
        ServerProxy.GetInstance ().Login (m_Account, m_Password);
        ServerProxy.GetInstance ().LoginTime ();

        Logined = true;
    }

    public void Quit () {
        ServerProxy.GetInstance ().Quit ();
        ServerProxy.GetInstance ().QuitTime ();

        Logined = false;
    }

#endregion

#region Memento

    private Vector3 m_Position;

    public void Update () {
        m_Position += new Vector3 (1, 1, 1);
    }

    public PlayerStateMemento SaveState () {
        Debug.Log ("Player save state");

        return new PlayerStateMemento (m_Position);
    }

    public void RecoveryState (PlayerStateMemento memento) {
        Debug.Log ("Player recovery state");
        
        m_Position = memento.Position;
    }

    public void DisplayPosition () {
        Debug.Log ("Position: " + m_Position);
    }
    
#endregion

}
