using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Title : MonoBehaviour
{
    private UIManager uiManager;
    private GameObject panel;
    private UIPlayTween tween;
    
    private void Awake()
    {
        panel = transform.Find("Panel").gameObject;
        tween = panel.transform.Find("PlayButton").GetComponent<UIPlayTween>();

        uiManager = transform.GetComponentInParent<UIManager>();
    }

    //Reverse
    public void ReversePlay()
    {
        panel.SetActive(false);
        StartCoroutine(Reverse_LeafMove());
    }

    private IEnumerator Reverse_LeafMove()
    {
        yield return null;

        tween.playDirection = AnimationOrTween.Direction.Reverse;
        yield return new WaitForSeconds(1.0f);

        tween.Play();
        tween.onFinished.Clear();
        tween.onFinished.Add(new EventDelegate(this, "DisablePanel"));
        tween.onFinished.Add(new EventDelegate(uiManager.tapPanel, "TapStart"));
        tween.onFinished.Add(new EventDelegate(SoundManager.Inst, "PlayMode"));
    }

    private void DisablePanel()
    {
        this.gameObject.SetActive(false);
    }

}
