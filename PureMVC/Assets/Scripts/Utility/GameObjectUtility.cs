﻿using UnityEngine;

public class GameObjectUtility {

    public static GameObject CreateGameObject (string name, Transform parent = null) {
        Debug.Log (name);
        GameObject obj = GameObject.Instantiate(Resources.Load (name)) as GameObject;
        if (obj == null) {
            Debug.LogError("無法創建游戲對象，名字為:" + name);
            return null;
        }

        obj.transform.position = Vector3.zero;
        obj.transform.localScale = Vector3.one;
        if (parent != null) {
            obj.transform.SetParent (parent);
        }
        obj.SetActive (false);

        return obj;
    }

    public static GameObject CreateGameObject (GameObject target, Transform parent = null) {
        if (target == null) {
            Debug.LogError("無法創建空游戲對象");
            return null;
        }
        
        GameObject obj = GameObject.Instantiate (target);
        obj.transform.position = Vector3.zero;
        obj.transform.localScale = Vector3.one;
        if (parent != null) {
            obj.transform.SetParent (parent);
        }
        obj.SetActive (false);

        return obj;
    }
    
}
