using UnityEngine;

public class UseFacade : MonoBehaviour {

    private void Start () {
        // 利用外觀類的GameController，直接游戲開始
        
        // 不需要由用戶調用AudioController和LevelController

        GameController.Instance.GameInit ();
        GameController.Instance.GameStart ();
        GameController.Instance.GamePause ();
        GameController.Instance.GameContinue ();
        GameController.Instance.GameOver ();
        GameController.Instance.GameClose ();
    }
    
}
