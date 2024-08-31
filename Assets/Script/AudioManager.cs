using System.Collections;
using System.Collections.Generic;
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

    [Header("#SFX")]
    public AudioClip[] sfxClips;
    public float sfxVolume;
    public int sfxChannels;
    AudioSource[] sfxPlayers;
    int channelIndex;
        
    public enum Bgm
    {
        Stage11, Stage12, Stage13, Stage14, Stage15
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
        //배경음 플레이어 초기화
        GameObject bgmObject = new GameObject("BgmPlayer");
        bgmObject.transform.parent = transform;
        bgmPlayers = new AudioSource[bgmChannels];

        for (int index = 0; index < bgmPlayers.Length; index++)
        {
            bgmPlayers[index] = bgmObject.AddComponent<AudioSource>();
            bgmPlayers[index].volume = sfxVolume;
            bgmPlayers[index].loop = true;
        }
        //bgmPlayer = bgmObject.AddComponent<AudioSource>();
        //bgmPlayer.playOnAwake = false;
        //bgmPlayer.loop = true;
        //bgmPlayer.volume = bgmVolume;
        //bgmPlayer.clip = bgmClip;

        //효과음 플레이어 초기화
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
    public void PlayBgm(Bgm bgm, bool isPlay)
    {
        for (int index = 0; index < sfxPlayers.Length; index++)
        {
            int loopindex = (index + channelIndex) % bgmPlayers.Length;

            if (sfxPlayers[loopindex].isPlaying)
            {
                continue;
            }

            channelIndex = loopindex;
            bgmPlayers[loopindex].clip = bgmClips[(int)bgm];
            bgmPlayers[loopindex].Play();

            break;
        }
    }


    // 효과음 재생
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
