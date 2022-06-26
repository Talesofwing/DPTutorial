using UnityEngine;

public class DirectXRenderer : IRenderEngine {

    public void Draw (string name) {
        Debug.Log ("DirectX Draw: " + name);
    }
    
}
