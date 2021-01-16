using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SwapScene : MonoBehaviour
{
    public void SwapToScene(string sceneName)
    {
        SceneManager.LoadScene(sceneName);
    }
}