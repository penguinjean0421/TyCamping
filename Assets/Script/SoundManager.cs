using UnityEngine;
using UnityEngine.Audio;

public class SoundManager
{
    public static SoundManager instance;

    // 배경음악
    [Header("#BGM")]
    public AudioClip bgmClip;
    public float bgmVolume;
    AudioSource bgmPlayer;

    // 타이핑 효과음
    [Header("#SFX")]
    public AudioClip [] sfxClip;
    public float sfxVolume;
    public int channels;
    AudioSource [] sfxPlayer;
    public int channelIndex;

    void Awake()
    {
        instance = this;
        Init();
    }

    void Init()
    {
        // 배경음 플레이어 초기화

        // 효과음 플레이어 초기화 
    }
