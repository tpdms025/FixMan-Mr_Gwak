using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TouchTap : MonoBehaviour
{
    private UIManager uIManager;
    private UILabel label;
    private Blink blink;

    private void Awake()
    {
        uIManager = GameObject.Find("UI Root").transform.Find("UI").GetComponent<UIManager>();
        label = transform.GetComponentInChildren<UILabel>();
        blink = GetComponent<Blink>();
    }

    public void TapStart()
    {
        StartCoroutine(blink.BlinkAnim(label));
        StartCoroutine(CheckTouch());
    }
    private IEnumerator CheckTouch()
    {
        yield return new WaitForSeconds(2.0f);
        while (Input.touchCount <= 0) { yield return null; }

        //Game Start
        uIManager.topPanel.StartTimer();
        this.gameObject.SetActive(false);
        //노드 시작
        //TODO:
    }
}
