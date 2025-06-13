using UnityEngine;

public class Singleton<T> : MonoBehaviour where T : MonoBehaviour
{
    private static T _instance;
    private static object _lock = new object();
    private static bool applicationIsQuitting = false;

    public static T Instance
    {
        get
        {
            if (applicationIsQuitting)
            {
                Debug.LogWarning("[Singleton] Instance '" + typeof(T) +
                                 "' already destroyed on application quit. Won't create again - returning null.");
                return null;
            }

            lock (_lock)
            {
                if (_instance == null)
                {
                    // 🔄 Use the new API here
                    T[] objects = FindObjectsByType<T>(FindObjectsSortMode.None);

                    if (objects.Length > 1)
                    {
                        Debug.LogError("[Singleton] More than one instance of " + typeof(T) +
                                       " found! This should never happen.");
                        _instance = objects[0];
                        return _instance;
                    }

                    if (objects.Length == 1)
                    {
                        _instance = objects[0];
                    }

                    if (_instance == null)
                    {
                        GameObject singleton = new GameObject();
                        _instance = singleton.AddComponent<T>();
                        singleton.name = typeof(T).ToString() + " (Singleton)";
                        DontDestroyOnLoad(singleton);
                        Debug.Log("[Singleton] An instance of " + typeof(T) +
                                  " was created with DontDestroyOnLoad.");
                    }
                    else
                    {
                        Debug.Log("[Singleton] Using existing instance: " + _instance.gameObject.name);
                    }
                }

                return _instance;
            }
        }
    }

    public void OnDestroy()
    {
        applicationIsQuitting = true;
    }
}
