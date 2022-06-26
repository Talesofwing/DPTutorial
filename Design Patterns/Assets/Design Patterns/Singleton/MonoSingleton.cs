using UnityEngine;

/// <summary>
/// 1. 因為Unity是單線程的，所以可以忽略多線程帶來的問題
/// 2. 場景中有的物件才會調用Awake，因此會被調用Awake的物件99%都是有用的
/// </summary>

public class MonoSingleton : MonoBehaviour {
    private static MonoSingleton m_Instance;

    public static MonoSingleton Instance {
        get {
            return m_Instance;
        }
    }

    private void Awake () {
        m_Instance = this;
    }

}
