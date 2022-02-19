using UnityEngine;

public class MoveBackMovement : BaseMovement {

    public MoveBackMovement (IMovable owner) : base (owner) { }

    public override void Move (float dt) {
        Vector2 pos = m_Owner.GetTransform ().position;
        pos += Vector2.left * m_Owner.GetSpeed () * dt;
        m_Owner.GetTransform ().position = pos;
    }
    
}
