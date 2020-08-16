using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using System;

public class UIManager : MonoBehaviour
{
    public TouchTap tapPanel;
    public TopPanel topPanel;

    private void Awake()
    {
        tapPanel = transform.Find("TapPanel").GetComponent<TouchTap>();
        topPanel = transform.Find("TopPanel").GetComponent<TopPanel>();
    }

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
        Debug.Log(Time.timeScale.ToString());
        Time.timeScale = Time.timeScale == 1 ? 0 : 1;
    }

    //수정중
    public void Vibrate()
    {
        Vibration.Vibrate();
    }

}
