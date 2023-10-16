using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SceneLoader : MonoBehaviour
{
    [SerializeField] private string _sceneName;

    public void Load()
    {
        UnityEngine.SceneManagement.SceneManager.LoadSceneAsync(_sceneName);
    }
}
