using System.Collections;
using System.Collections.Generic;
using System.Runtime.Serialization.Json;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Rendering;
using static AudioManager;

public class AudioManager : MonoBehaviour
{
    public static AudioManager instance;

    [Header("#BGM")]
    public AudioClip[] bgmClips;
    public float bgmVolume;
    public int bgmChannels;
    AudioSource[] bgmPlayers;


    [Header("#ENVIRBGM")]
    public AudioClip[] envirBgmClips;
    public float envirBgmVolume;
    public int envirBgmChannels;
    AudioSource[] envirBgmPlayers;
    int channelIndex;

    [Header("#SFX")]
    public AudioClip[] sfxClips;
    public float sfxVolume;
    public int sfxChannels;
    AudioSource[] sfxPlayers;


    public enum Bgm
    {
        Menu, CutScene, Stage
    }


    public enum EnvirBgm
    {
        Stage11, Stage12, Stage21, Stage22, Stage31, Stage32
    }


    public enum Sfx
    {
        Typing, EnterHit, BackSpaceHit, Button
    }


    void Awake()
    {
        instance = this;
        Init();
        DontDestroyOnLoad(gameObject);
    }

    void Init()
    {
        // 메인 BGM 초기화
        GameObject bgmObject = new GameObject("BgmObject");
        bgmObject.transform.parent = transform;
        bgmPlayers = new AudioSource[bgmChannels];

        for (int index = 0; index < bgmPlayers.Length; index++)
        {
            bgmPlayers[index] = bgmObject.AddComponent<AudioSource>();
            bgmPlayers[index].playOnAwake = false;
            bgmPlayers[index].volume = bgmVolume;
        }


        // 환경BGM 초기화
        GameObject envirBgmObject = new GameObject("EnvirBgmObject");
        envirBgmObject.transform.parent = transform;
        envirBgmPlayers = new AudioSource[envirBgmChannels];

        for (int index = 0; index < envirBgmPlayers.Length; index++)
        {
            envirBgmPlayers[index] = envirBgmObject.AddComponent<AudioSource>();
            envirBgmPlayers[index].playOnAwake = false;
            envirBgmPlayers[index].volume = sfxVolume;
        }

        // 효과음 초기화
        GameObject sfxObject = new GameObject("SfxObject");
        sfxObject.transform.parent = transform;
        sfxPlayers = new AudioSource[sfxChannels];

        for (int index = 0; index < sfxPlayers.Length; index++)
        {
            sfxPlayers[index] = sfxObject.AddComponent<AudioSource>();
            sfxPlayers[index].playOnAwake = false;
            sfxPlayers[index].volume = sfxVolume;
        }
    }

    // 배경음악 재생
    public void PlayBGM(Bgm bgm, bool isPlay)
    {
        for (int index = 0; index < bgmPlayers.Length; index++)
        {
            int loopindex = (index + channelIndex) % bgmPlayers.Length;

            if (bgmPlayers[loopindex].isPlaying)
            {
                continue;
            }

            channelIndex = loopindex;
            bgmPlayers[loopindex].clip = bgmClips[(int)bgm];
            bgmPlayers[loopindex].Play();

            if (isPlay)
            {
                bgmPlayers[loopindex].Play();
            }
            else
            {
                bgmPlayers[loopindex].Stop();
            }
        }
    }


    // �경�악 �생
    public void PlayEnvirBgm(EnvirBgm envirBgm, bool isPlay)
    {
        for (int index = 0; index < envirBgmPlayers.Length; index++)
        {
            int loopindex = (index + channelIndex) % envirBgmPlayers.Length;

            if (envirBgmPlayers[loopindex].isPlaying)
            {
                continue;
            }

            channelIndex = loopindex;
            envirBgmPlayers[loopindex].clip = envirBgmClips[(int)envirBgm];
            envirBgmPlayers[loopindex].Play();

            if (isPlay)
            {
                envirBgmPlayers[loopindex].Play();
            }
            else
            {
                envirBgmPlayers[loopindex].Stop();
            }
        }
    }


    // �과�생
    public void PlaySfx(Sfx sfx)
    {
        for (int index = 0; index < sfxPlayers.Length; index++)
        {
            int loopindex = (index + channelIndex) % sfxPlayers.Length;

            if (sfxPlayers[loopindex].isPlaying)
            {
                continue;
            }

            channelIndex = loopindex;
            sfxPlayers[loopindex].clip = sfxClips[(int)sfx];
            sfxPlayers[loopindex].Play();
            
            break;
        }
    }
}
