using UnityEngine;

public class OpenGLRenderer : IRenderEngine {

    public void Draw (string name) {
        Debug.Log ("OpenGL Draw: " + name);
    }
    
}
