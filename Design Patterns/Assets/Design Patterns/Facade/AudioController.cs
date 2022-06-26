using System.Runtime.CompilerServices;
using UnityEngine;


public class AudioController {
    private static AudioController m_Instance;
    public static AudioController Instance {
        get {
            if (null == m_Instance) {
                m_Instance = new AudioController ();
            }

            return m_Instance;
        }
    }

    private void Awake () {
        m_Instance = this;
    }
    
    public void PlayBGM (string clip) {
        Debug.Log ("播放BGM: " + clip);
    }

    public void PauseBGM (string clip) {
        Debug.Log("暫停BGM: " + clip);
    }

    public void StopBGM (string clip) {
        Debug.Log ("停止BGM: " + clip);
    }

}
