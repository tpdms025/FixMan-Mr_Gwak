using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TouchTap : MonoBehaviour
{
    private UILabel label;
    private Blink blink;

    private void Awake()
    {
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
        while (Input.touchCount <= 0) { yield return null; }

        //Game Start
        //노드 시작
        this.gameObject.SetActive(false);
    }
}
