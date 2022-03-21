using System;
using UnityEngine;

public class WindowsServer : IServer {
    
    public void Login (string name, string password) {
        Debug.Log ("WindowsServer login: " + name + ", " + password);
    }

    public void Quit () {
        Debug.Log ("WindowsServer quit.");
    }


    public void LoginTime () {
        Debug.Log ("WindowsServer LoginTime: " + DateTime.Now);
    }

    public void QuitTime () {
        Debug.Log ("WindowsServer QuitTime: " + DateTime.Now);
    }
    
}