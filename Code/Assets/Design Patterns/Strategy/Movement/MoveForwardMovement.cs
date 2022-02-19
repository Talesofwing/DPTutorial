using UnityEngine;

public class MoveForwardMovement : BaseMovement {
    
    public MoveForwardMovement (IMovable owner) : base (owner) { }


    public override void Move (float dt) {
        Vector2 pos = m_Owner.GetTransform ().position;
        pos += Vector2.right * m_Owner.GetSpeed () * dt;
        m_Owner.GetTransform ().position = pos;
    }

}
