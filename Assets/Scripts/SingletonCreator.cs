using UnityEngine;

public class SingletonCreator : MonoBehaviour
{
    private void Awake()
    {
        if (!SingletonEnlister.Enlister.AlreadyASingleton(gameObject.name))
        {
            SingletonEnlister.Enlister.AddSingleton(gameObject.name);
            DontDestroyOnLoad(gameObject);
        }
        else { Destroy(gameObject); }
        
    }
}
