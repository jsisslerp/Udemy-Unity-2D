
using UnityEngine;

public class PersistentGameObjectSingleton<T> : MonoBehaviour where T : MonoBehaviour
{
    public static PersistentGameObjectSingleton<T> Instance { get; private set; }

    void Awake()
    {
        // If no Instance yet exists, assign and preserve across scenes.
        if (!Instance)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
            Debug.Log("created singleton instance of type " + name);
        }
        // Otherwise, if an Instance already exists, destroy the new instance.
        else if (Instance != this)
        {
            Debug.Log("destroying new instance of " + name + " singleton");
            DestroyImmediate(gameObject);
        }
    }
}
