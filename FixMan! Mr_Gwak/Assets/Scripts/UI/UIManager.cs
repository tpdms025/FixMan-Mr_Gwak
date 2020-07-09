using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using System;

public class UIManager : MonoBehaviour
{

    public void ToggleWindow(GameObject _obj)
    {
        GameObject obj = _obj;
        Debug.Log(obj.name+ obj.activeSelf);
        obj.SetActive(!obj.activeSelf);
    }

    public void LoadScene(string sceneName)
    {
        SceneManager.LoadScene(sceneName);
    }

    public void TimePause()
    {
        Time.timeScale = Time.timeScale == 1 ? 0 : 1;
    }

}
