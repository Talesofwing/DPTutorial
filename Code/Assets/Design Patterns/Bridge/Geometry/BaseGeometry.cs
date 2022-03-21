public abstract class BaseGeometry {
    protected string m_Name;
    protected IRenderEngine m_RenderEngine;

    public BaseGeometry (IRenderEngine re) {
        m_RenderEngine = re;
    }

    public void Draw () {
        m_RenderEngine.Draw (m_Name);
    }
    
}