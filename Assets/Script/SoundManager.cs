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

    // Ÿ���� ȿ����
    [Header("#SFX")]
<<<<<<< Updated upstream
    public AudioClip [] sfxClip;
    public float sfxVolume;
    public int channels;
    AudioSource [] sfxPlayer;
=======
    public AudioClip[] sfxClip;
    public float sfxVolume;
    public int channels;
    AudioSource[] sfxPlayer;
>>>>>>> Stashed changes
    public int channelIndex;

    void Awake()
    {
        instance = this;
        Init();
    }

    void Init()
    {
        // ����� �÷��̾� �ʱ�ȭ

<<<<<<< Updated upstream
        // ȿ���� �÷��̾� �ʱ�ȭ
    }





















    // Ÿ����
    public void Typing()
    { 
    
    }

    // ���� 
    public void SuccessTyping()
    { 

    }

    // ����
    public void FailTyping()
    {

    }

    // �����
    public void DeleteTyping()
    {

    }

    // Ÿ�� �ϼ�
    public void Completion()
    {

    }

    // UI Ŭ��
    public void UIClick()
    {

    }

    // ��ü������ �򸮴� �������
    public void BackGroundMusic()
    { 

    }

    //  ȯ�渶�� �޶����� �������
    public void EnviromentMusic()
    { 
    
    }
}
=======
        // ȿ���� �÷��̾� �ʱ�ȭ 
    }
>>>>>>> Stashed changes
