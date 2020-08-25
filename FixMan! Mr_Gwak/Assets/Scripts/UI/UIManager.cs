using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using System;

public class UIManager : MonoBehaviour
{
    public TouchTap tapPanel;
    public TopPanel topPanel;

    public ResultWindow resultWindow;
    public GridManager gridManager;

    private void Awake()
    {
        tapPanel = transform.Find("TapPanel").GetComponent<TouchTap>();
        topPanel = transform.Find("TopPanel").GetComponent<TopPanel>();

        resultWindow = transform.Find("ResultWindow").GetComponent<ResultWindow>();
        resultWindow.gameObject.SetActive(false);
        gridManager = GameObject.Find("UI Root").transform.Find("GridManager").GetComponent<GridManager>();

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

    public void OpenResult(bool isSuccess)
    {
        Player player = gridManager.player.GetComponent<Player>();
        resultWindow.gameObject.SetActive(true);
        resultWindow.OnResult(isSuccess,GameManager.Inst.currentScore, topPanel.curTime, player.health, player.combo);
    }

    //수정중
    public void Vibrate()
    {
        Vibration.Vibrate();
    }

}
