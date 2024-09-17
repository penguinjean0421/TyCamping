// using Default.Scripts.Util;
// using Default.Scripts.Util.StatePattern;
using static UnityEngine.GraphicsBuffer;

using UnityEngine;
using UnityEditor;
using UnityEngine.Rendering;

namespace Default.Scripts.Sound
{

#if UNITY_EDITOR
    [CustomEditor(typeof(SoundManager))]
    public class SoundManagerInspector : Editor
    {
        public override void OnInspectorGUI()
        {
            base.OnInspectorGUI();
            var sm = (SoundManager)target;
            sm.channels = sm.GetComponentsInChildren<Channel>();
        }
    }
#endif

    public class SoundManager : Singleton<SoundManager>
    {
        public void Awake()
        {
            DontDestroyOnLoad(gameObject);
            channels = GetComponentsInChildren<Channel>();
        }

        public void Start()
        {
            if (PlayerPrefs.HasKey("SFX"))
            {
                var sfxValue = PlayerPrefs.GetFloat("SFX");
                SetVolume(sfxValue, 0);
            }

            if (PlayerPrefs.HasKey("BGM"))
            {
                var bgmValue = PlayerPrefs.GetFloat("BGM");
                SetVolume(bgmValue, 1);
                SetVolume(bgmValue, 2);
            }
        }

        public SoundListAsset asset;
        [HideInInspector] public Channel[] channels;

        public static void Play(string name, int channel)
        {
            Instance.channels[channel].Play(Instance.asset.GetSoundByName(name).clip);
        }
        public static void PlayOneShot(string name)
        {
            Instance.channels[0].PlayOneShot(Instance.asset.GetSoundByName(name).clip);
        }
        public static void SetLoop(bool loop, int channel)
        {
            Instance.channels[channel].SetLoop(loop);
        }

        public static void Stop(int channel)
        {
            Instance.channels[channel].Stop();
        }

        public static void Pause(int channel)
        {
            Instance.channels[channel].Pause();
        }

        public static void SetVolume(float volume,int channel)
        {
            Instance.channels[channel].SetVolume(volume);
        }
    }
}
