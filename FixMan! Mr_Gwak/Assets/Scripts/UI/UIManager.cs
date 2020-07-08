using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using System;

public class UIManager : MonoBehaviour
{

    private UILabel timeLabel;
    private UISlider staminaSlider;

    private float time = 100.0f;


   

    private IEnumerator Timer()
    {

        while (time >0)
        {
            float temp = 20.0f;
            time -= Time.deltaTime;
            //timeLabel.text = string.Format("{0:0.##", time);
            timeLabel.text = time.ToString("0.00");
            yield return null;
        }

 
    }
  
  

    public void ToggleWindow(GameObject _obj)
    {
        GameObject obj = _obj;
        Debug.Log(obj.name+ obj.activeSelf);
        obj.SetActive(!obj.activeSelf);
    }

    public void LoadScene(string sceneName)
    {
        SceneManager.LoadScene("PlayMode");
    }

    public void TimePause()
    {
        Time.timeScale = Time.timeScale == 1 ? 0 : 1;
    }



    public void ChangeHp(float hp)
    {
        //healthLabel.text = hp.ToString();
    }


    public void ChangeStaminaBar()
    {
        staminaSlider.value -= Mathf.Clamp01(Time.deltaTime / 5.0f );
    }
}
