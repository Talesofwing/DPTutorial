public class BuilderDirector {
    private IBuilder m_Builder;

    public BuilderDirector (IBuilder pb) {
        m_Builder = pb;
    }

    public Enemy CreateEnemy () {
        m_Builder.CreateBody ();
        m_Builder.CreateWeapon ();

        return m_Builder.GetResult<Enemy> ();
    }
    
}
