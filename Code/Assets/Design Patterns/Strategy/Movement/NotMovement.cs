public class NotMovement : BaseMovement {

    public NotMovement (IMovable owner) : base (owner) { }
    
    public override void Move (float dt) {
        // 甚麼都不做的移動
    }
    
}
