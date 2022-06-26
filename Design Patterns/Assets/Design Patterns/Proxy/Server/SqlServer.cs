using System;
using UnityEngine;

public class SqlServer : IServer {

    public void Login (string name, string password) {
        Debug.Log ("SqlServer login: " + name + ", " + password);
    }

    public void Quit () {
        Debug.Log ("SqlSever quit.");
    }


    public void LoginTime () {
        Debug.Log ("SqlServer LoginTime: " + DateTime.Now);
    }

    public void QuitTime () {
        Debug.Log ("SqlServer QuitTime: " + DateTime.Now);
    }

}