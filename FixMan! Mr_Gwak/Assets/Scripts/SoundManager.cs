using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{

    private static SoundManager instance;
    public static SoundManager Inst { get { return instance; } set { instance = value; } }


    private AudioSource BGM;
    public AudioClip sndTitle;
    public AudioClip sndPlayMode;
    public AudioClip sndBoss;

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

    }

    private void Start()
    {
        BGM = GetComponent<AudioSource>();
    }
}
