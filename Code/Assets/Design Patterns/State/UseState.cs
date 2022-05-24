using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UseState : MonoBehaviour {
    [SerializeField] private Character m_Character;

    private void Update () {
        if (Input.GetKeyDown (KeyCode.Space)) {
            m_Character.TakeDamage (10);
        } else if (Input.GetKeyDown (KeyCode.A)) {
            m_Character.Attack ();
        }
    }
    
}
