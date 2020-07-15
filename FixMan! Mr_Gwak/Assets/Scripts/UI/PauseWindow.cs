using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseWindow : MonoBehaviour
{
    /// <summary>
    /// Home Button
    /// </summary>
    public void LoadHomeScene()
    {
        SceneManager.LoadScene("HomeScene");
    }

    public void RePlay()
    {
        SceneManager.LoadScene("PlayScene");
    }
    
}
