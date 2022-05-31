public class EnemyAmountVisitor  : IEnemyVisitor {
    public int Amount {
        get;
        private set;
    }

    public override void Visit (FireEnemy enemy) {
        Amount++;
    }
    
}
    
