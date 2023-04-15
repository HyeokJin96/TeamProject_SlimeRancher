using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KSingleton<T> : GComponent where T : KSingleton<T>
{
    private static T _instance = default;

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

    public override void Awake()
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

    public void Create()
    {
        this.Init();
    }

    public virtual void Init()
    {
        /* Do something */
    }
}