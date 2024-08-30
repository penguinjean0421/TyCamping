using UnityEngine;
using UnityEngine.Audio;

public class SoundManager
{
    public static SoundManager instance;

    // �������
    [Header("#BGM")]
    public AudioClip bgmClip;
    public float bgmVolume;
    AudioSource bgmPlayer;

    // ȿ����
    [Header("#SFX")]
    public AudioClip[] sfxClip;
    public float sfxVolume;
    public int channels;
    AudioSource[] sfxPlayer;
    public int channelIndex;

    void Awake()
    {
        instance = this;
        Init();
    }

    void Init()
    {
        // ����� �÷��̾� �ʱ�ȭ

        // ȿ���� �÷��̾� �ʱ�ȭ
    }
}
