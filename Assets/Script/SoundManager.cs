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
        // 배경음 플레이어 초기화

<<<<<<< Updated upstream
        // 효과음 플레이어 초기화
    }





















    // 타이핑
    public void Typing()
    { 
    
    }

    // 정답 
    public void SuccessTyping()
    { 

    }

    // 오답
    public void FailTyping()
    {

    }

    // 지우기
    public void DeleteTyping()
    {

    }

    // 타자 완성
    public void Completion()
    {

    }

    // UI 클릭
    public void UIClick()
    {

    }

    // 전체적으로 깔리는 배경음악
    public void BackGroundMusic()
    { 

    }

    //  환경마다 달라지는 배경음악
    public void EnviromentMusic()
    { 
    
    }
}
=======
        // 효과음 플레이어 초기화 
    }
>>>>>>> Stashed changes
