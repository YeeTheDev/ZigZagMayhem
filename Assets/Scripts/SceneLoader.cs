using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoader : MonoBehaviour
{
    public void LoadGame(int sceneToLoad) { SceneManager.LoadScene(sceneToLoad); }
}
