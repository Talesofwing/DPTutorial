using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UseBridge : MonoBehaviour {
    
    private void Start () {
        OpenGLRenderer opengl = new OpenGLRenderer ();
        DirectXRenderer dx = new DirectXRenderer ();
        VulkanRenderer vulkan = new VulkanRenderer ();
        
        Sphere sphere = new Sphere (opengl);
        sphere.Draw ();
        Cube cube = new Cube (vulkan);
        cube.Draw ();
        Capsule capsule = new Capsule (dx);
        capsule.Draw ();
    }
    
}
