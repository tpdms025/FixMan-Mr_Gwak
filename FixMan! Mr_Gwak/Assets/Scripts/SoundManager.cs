using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{

    private static SoundManager instance;
    public static SoundManager Inst { get { return instance; } set { instance = value; } }


    private AudioSource BGM;

    [SerializeField] private AudioClip sndTitle;
    [SerializeField] private AudioClip sndPlayMode;
    [SerializeField] private AudioClip sndBoss;

    private void Awake()
    {
        if (Inst == null)
        {
            Inst = this;
        }
        else if (Inst != this)
        {
            Destroy(gameObject);
        }

        DontDestroyOnLoad(gameObject);

        sndTitle = Resources.Load("Sound/wikiki") as AudioClip;
        sndPlayMode = Resources.Load("Sound/_Funny Dream_ - Royalty-free Music - Background Music") as AudioClip;
        sndBoss = Resources.Load("Sound/pitter patter") as AudioClip;
    }

    private void Start()
    {
        BGM = GetComponent<AudioSource>();
    }

    #region PlaySound
    public void PlayTitle()
    {
        BGM.clip = sndTitle;
        BGM.Play();
    }

    public void PlayMode()
    {
        BGM.clip = sndPlayMode;
        BGM.Play();
    }

    #endregion
}
