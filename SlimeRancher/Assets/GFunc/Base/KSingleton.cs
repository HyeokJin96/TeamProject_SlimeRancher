using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KSingleton<T> : MonoBehaviour where T : KSingleton<T>
{
    private static T _instance;

    public static T Instance 
    {
        get
        {
            if(_instance == null)
            {
                _instance = FindObjectOfType<T>();

                if(_instance == null)
                {
                    GameObject obj = new GameObject(typeof(T).ToString());
                    _instance = obj.AddComponent<T>();
                    DontDestroyOnLoad(obj);
                }
            }       

            return _instance;
        }
    }

    protected virtual void Init()
    {
        /* Do something */
    }

    public void Awake()
    {
        if(_instance != null && _instance != this)
        {
            Destroy(gameObject);
            return;
        }

        _instance = this as T;
        DontDestroyOnLoad(gameObject);

        Init();
    }
}