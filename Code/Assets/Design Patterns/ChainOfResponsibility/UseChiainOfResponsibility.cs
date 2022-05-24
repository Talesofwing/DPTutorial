using UnityEngine;

public class UseChiainOfResponsibility : MonoBehaviour {
    [SerializeField] private string m_Code = "Fuck Konami";
    
    private DecodeC m_C;
    private DecodeB m_B;
    private DecodeA m_A;
    
    
    private void Start () {
        m_C = new DecodeC ();
        m_B = new DecodeB (m_C);
        m_A = new DecodeA (m_B);
    }

    private void Update () {
        if (Input.GetKeyDown (KeyCode.A)) {
            if (!m_A.Decode (m_Code)) {
                Debug.Log ("解碼失敗A");
            }
        } else if (Input.GetKeyDown (KeyCode.B)) {
            if (!m_B.Decode (m_Code)) {
                Debug.Log ("解碼失敗B");
            }
        } else if (Input.GetKeyDown (KeyCode.C)) {
            if (!m_C.Decode (m_Code)) {
                Debug.Log ("解碼失敗C");
            }
        }
    }
    
}
