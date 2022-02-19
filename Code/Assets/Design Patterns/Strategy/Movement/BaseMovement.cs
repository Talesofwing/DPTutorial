using UnityEngine;

public abstract class BaseMovement {
    protected IMovable m_Owner;

    public BaseMovement (IMovable owner) {
        m_Owner = owner;
    }

    public abstract void Move (float dt);
}
