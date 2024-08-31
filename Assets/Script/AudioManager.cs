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
    public AudioClip bgmClip;
    public float bgmVolume;
    public int bgmChannels;
    AudioSource bgmPlayer;


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
    }

    void Init()
    {
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

    // 배경�악 �생
    public void PlayBGM(bool isPlay)
    {
        if (isPlay)
        {
            bgmPlayer.Play();
        }
        else
        {
            bgmPlayer.Stop();
        }
    }


    // �경�악 �생
    public void PlayEnvirBgm(EnvirBgm envirBgm)
    {
        for (int index = 0; index < sfxPlayers.Length; index++)
        {
            int loopindex = (index + channelIndex) % envirBgmPlayers.Length;

            if (envirBgmPlayers[loopindex].isPlaying)
            {
                continue;
            }

            channelIndex = loopindex;
            envirBgmPlayers[loopindex].clip = envirBgmClips[(int)envirBgm];
            envirBgmPlayers[loopindex].Play();

            break;
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
