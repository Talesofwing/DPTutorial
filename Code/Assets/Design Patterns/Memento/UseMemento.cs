using UnityEngine;

public class UseMemento : MonoBehaviour {
    private PlayerStateCaretaker m_PlayerStateCaretaker;
    private Player m_Player;
    
    private void Awake () {
        m_PlayerStateCaretaker = new PlayerStateCaretaker ();
        m_Player = new Player ();
    }

    private void Start () {
        SaveState ();
    }

    private void Update () {
        if (Input.GetKeyDown (KeyCode.Space)) {
            if (m_PlayerStateCaretaker.HasMemento ()) {
                RecoveryState ();
                m_Player.DisplayPosition ();
            }
        } else if (Input.GetKeyDown (KeyCode.A)) {
            // 應該保存的是上一個狀態
            SaveState ();
            m_Player.Update ();
            m_Player.DisplayPosition ();
        }
    }

    private void SaveState () {
        m_PlayerStateCaretaker.AddMemento (m_Player.SaveState ());
    }

    private void RecoveryState () {
        m_Player.RecoveryState (m_PlayerStateCaretaker.PopMemento ());
    }
    
}
