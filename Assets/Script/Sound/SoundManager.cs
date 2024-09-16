// using Default.Scripts.Util;
// using Default.Scripts.Util.StatePattern;
using static UnityEngine.GraphicsBuffer;

using UnityEngine;
using UnityEditor;

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
        }

        public SoundListAsset asset;
        [HideInInspector] public Channel[] channels;

        public static void Play(string name, int channel)
        {
            Instance.channels[channel].Play(Instance.asset.GetSoundByName(name).clip);
        }

        public static void SetLoop(bool loop, int channel)
        {
            Instance.channels[channel].SetLoop(loop);
        }

        public static void Play(string name)
        {
            Instance.channels[0].Play(Instance.asset.GetSoundByName(name).clip);
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
