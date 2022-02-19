using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Character : MonoBehaviour, IMovable {
    [SerializeField] private float m_Speed = 5.0f;

    private Transform m_CacheTf;
    private BaseMovement m_Movement;

    private void Awake () {
        m_CacheTf = this.transform;
        
        m_Movement = new NotMovement (this);
    }

    private void Update () {
        Move (Time.deltaTime);
    }

    private void Move (float dt) {
        m_Movement.Move (dt);
    }

#region Strategy

    public void SetMovement (int id) {
        if (id == 0) {
            m_Movement = new NotMovement (this);
            Debug.Log ("已切換到 「不動」");
        } else if (id == 1) {
            m_Movement = new MoveForwardMovement (this);
            Debug.Log ("已切換到 「向前移動」");
        } else if (id == 2) {
            m_Movement = new MoveBackMovement (this);
            Debug.Log ("已切換到 「向後移動」");
        }
    }

#endregion

#region IMovable Implementation

    public Transform GetTransform () {
        return m_CacheTf;
    }

    public float GetSpeed () {
        return m_Speed;
    }

#endregion

}
