using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Singleton<T> : MonoBehaviour where T : MonoBehaviour
{
    private static T instance;
    public static T Instance
    {
        get
        {
            if (instance == null)
            {
                var objs = Object.FindObjectsByType<T>(FindObjectsSortMode.None);
                if (objs.Length > 0)
                {
                    instance = objs[0];
                }

                if (objs.Length > 1)
                {
                    Debug.LogWarning("There are more than one " + typeof(T).Name + " in the scene.");
                }
            }
            return instance;
        }
    }
}
