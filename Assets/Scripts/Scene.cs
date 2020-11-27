using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class Scene : MonoBehaviour
{
    [SerializeField] string SceneName;

    void Start()
    {
        Invoke("ChangeScene", 0.8f);
    }

    void ChangeScene()
    {
        SceneManager.LoadScene(SceneName);
    }
}
