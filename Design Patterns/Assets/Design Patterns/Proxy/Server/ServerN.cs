using System;
using UnityEngine;

public class ServerN : IServer {
    
    public void Login (string name, string password) {
        Debug.Log ("ServerN login: " + name + ", " + password);
    }

    public void Quit () {
        Debug.Log ("ServerN quit.");
    }


    public void LoginTime () {
        Debug.Log ("ServerN LoginTime: " + DateTime.Now);
    }

    public void QuitTime () {
        Debug.Log ("ServerN QuitTime: " + DateTime.Now);
    }
    
}
    