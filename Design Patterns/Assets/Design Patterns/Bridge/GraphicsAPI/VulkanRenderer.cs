using UnityEngine;

public class VulkanRenderer : IRenderEngine {

    public void Draw (string name) {
        Debug.Log ("Vulkan Draw: " + name);
    }
    
}