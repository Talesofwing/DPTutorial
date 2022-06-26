using UnityEngine;

// Facade class
public class GameController {
    private static GameController m_Instance;
    public static GameController Instance {
        get {
            if (null == m_Instance) {
                m_Instance = new GameController ();
            }

            return m_Instance;
        }
    }
    
    public void GameInit () {
        Debug.Log ("GameInit");
    }

    public void GameStart () {
        Debug.Log ("GameStart");

        AudioController.Instance.PlayBGM ("BGM");
        LevelController.Instance.CreateLevel (1);
    }

    public void GamePause () {
        Debug.Log ("GamePause");

        AudioController.Instance.PauseBGM ("BGM");
    }

    public void GameContinue () {
        Debug.Log ("GameContinue");
        
        AudioController.Instance.PlayBGM ("BGM");
    }

    public void GameOver () {
        Debug.Log ("GameOver");
        
        AudioController.Instance.StopBGM ("BGM");
    }

    public void GameClose () {
        Debug.Log ("GameClose");
        
        AudioController.Instance.StopBGM ("BGM");
        LevelController.Instance.RemoveLevel ();
    }

}
