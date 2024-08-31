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
        // 배경�악 초기
        GameObject bgmObject = new GameObject("BgmPlayer");
        bgmObject.transform.parent = transform;
        bgmPlayer = bgmObject.AddComponent<AudioSource>();
        bgmPlayer.playOnAwake = false;
        bgmPlayer.loop = true;
        bgmPlayer.volume = bgmVolume;
        bgmPlayer.clip = bgmClip;

        //�경�레�어 초기
        GameObject envirBgmObject = new GameObject("EnvirBgmPlayer");
        envirBgmObject.transform.parent = transform;
        envirBgmPlayers = new AudioSource[envirBgmChannels];

        for (int index = 0; index < envirBgmPlayers.Length; index++)
        {
            envirBgmPlayers[index] = envirBgmObject.AddComponent<AudioSource>();
            envirBgmPlayers[index].volume = sfxVolume;
            envirBgmPlayers[index].playOnAwake = false;
            envirBgmPlayers[index].loop = true;
        }
    
        //�과�레�어 초기
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
