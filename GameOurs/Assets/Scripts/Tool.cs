using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class Tool : MonoBehaviour {
    public static bool choose(double possiblity)
    {
        System.Random r = new System.Random();
        if (r.NextDouble() <= possiblity)
            return true;
        else
            return false;
    }
    public static GameObject CreatePrefabAtPath(string path)
    {
        GameObject gameObj = Resources.Load(path) as GameObject;
        return Instantiate(gameObj);
    }
}
