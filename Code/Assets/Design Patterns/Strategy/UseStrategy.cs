using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UseStrategy : MonoBehaviour {
    [SerializeField] private Character m_Character;

    // 0 : NotMovement
    // 1 : MoveTowardMovement
    // 2 : MoveBackMovement
    private int m_MovementID = 0;

    private void Awake () {
        m_Character.SetMovement (new NotMovement(m_Character));
    }
    
    private void Update () {
        if (Input.GetKeyDown (KeyCode.Space)) {
            SetCharacterMovement ();
        }
    }

    private void SetCharacterMovement () {
        // Range: [0, 2]
        m_MovementID = (m_MovementID + 1) % 3;
        BaseMovement movement ;
        if (m_MovementID == 0) {
            movement = new NotMovement (m_Character);
            Debug.Log ("已切換到 「不動」");
        } else if (m_MovementID == 1) {
            movement = new MoveForwardMovement (m_Character);
            Debug.Log ("已切換到 「向前移動」");
        } else if (m_MovementID == 2) {
            movement = new MoveBackMovement (m_Character);
            Debug.Log ("已切換到 「向後移動」");
        } else {
            movement = new NotMovement (m_Character);
            Debug.Log ("已切換到 「不動」");
        }

        m_Character.SetMovement(movement);
    }
    
}
