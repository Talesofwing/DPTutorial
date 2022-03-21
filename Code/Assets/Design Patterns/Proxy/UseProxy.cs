using UnityEngine;

public class UseProxy : MonoBehaviour {
    private Player m_Player;

    private void Awake () {
        ServerProxy.GetInstance ().SwitchServer (ServerType.Sql);
    }

    private void Start () {
        m_Player = new Player ();
    }

    private void Update () {
        if (Input.GetKeyDown (KeyCode.Alpha1) || Input.GetKeyDown (KeyCode.Keypad1)) {
            ServerProxy.GetInstance ().SwitchServer (ServerType.Sql);
        } else if (Input.GetKeyDown (KeyCode.Alpha2) || Input.GetKeyDown (KeyCode.Keypad2)) {
            ServerProxy.GetInstance ().SwitchServer (ServerType.Windows);
        } else if (Input.GetKeyDown (KeyCode.Alpha3) || Input.GetKeyDown (KeyCode.Keypad3)) {
            ServerProxy.GetInstance ().SwitchServer (ServerType.ServerN);
        } else if (Input.GetKeyDown (KeyCode.Space)) {
            if (m_Player.Logined) {
                m_Player.Quit ();
            } else {
                m_Player.Login ();
            }
        }
    }

}
