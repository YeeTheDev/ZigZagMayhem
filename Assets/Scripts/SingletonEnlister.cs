using System.Collections.Generic;

public sealed class SingletonEnlister
{
    private static SingletonEnlister instance;
    private List<string> singletons = new List<string>();

    public static SingletonEnlister Enlister
    {
        get
        {
            if (instance == null) { instance = new SingletonEnlister(); }
            return instance;
        }
    }

    public void AddSingleton(string name) { singletons.Add(name); }
    public void RemoveSingleton(string name) { singletons.RemoveAt(singletons.IndexOf(name)); }
    public bool AlreadyASingleton(string nameToCheck) { return singletons.Contains(nameToCheck); }
}
