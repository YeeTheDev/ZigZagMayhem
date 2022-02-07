using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TutorialScreen : MonoBehaviour
{
    SceneLoader sceneLoader;

    private void Awake()
    {
        sceneLoader = GetComponent<SceneLoader>();
    }

    void Update()
    {
        if (Input.anyKeyDown) { sceneLoader.LoadGame(2); }
    }
}
