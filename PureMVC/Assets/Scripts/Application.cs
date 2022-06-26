using UnityEngine;

public class Application : MonoBehaviour {

    private void Awake () {
        MyFacade.GetInstance ().Launch ();
    }
    
}