using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UseStrategy : MonoBehaviour {
    [SerializeField] private Character m_Character;

    // 0 : NotMovement
    // 1 : MoveTowardMovement
    // 2 : MoveBackMovement
    private int m_MovementID = 0;
    
    private void Update () {
        if (Input.GetKeyDown (KeyCode.Space)) {
            SetCharacterMovement ();
        }
    }

    private void SetCharacterMovement () {
        m_MovementID = (m_MovementID + 1) % 3;

        m_Character.SetMovement(m_MovementID);
    }
    
}
