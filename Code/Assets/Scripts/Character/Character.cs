using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Character : MonoBehaviour, IMovable {
    [SerializeField] private float m_Speed = 5.0f;

    private Transform m_CacheTf;
    private BaseMovement m_Movement;

    private void Awake () {
        m_CacheTf = this.transform;
    }

    private void Update () {
        Move (Time.deltaTime);
    }

    private void Move (float dt) {
        m_Movement.Move (dt);
    }

#region Strategy

    public void SetMovement (BaseMovement movement) {
        m_Movement = movement;
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
