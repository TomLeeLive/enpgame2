using UnityEngine;
using System.Collections;
using System.Collections.Generic;

namespace TGAME
{
    public class TAudioMgr : MonoBehaviour
    {
        private Dictionary<string, AudioSource> _audioPool = new Dictionary<string, AudioSource>();
        private static TAudioMgr _mInstance = null;
        private bool m_effectSound = true;
        private bool m_bgMusic = true;
        private string m_CurrentKey = string.Empty;
        public void EffectOn() { m_effectSound = true; }
        public void EffectOff() { m_effectSound = false; }
        public void BGOn() { m_bgMusic = true; }
        public void BGOff() { m_bgMusic = false; }

        private void Awake()
        {
            // 씬이 변경되어도 삭제하지 않는다.
            DontDestroyOnLoad(this);
        }
        public void Load()
        {
            Instance.AudioSet("bgm", "bgm/bgm1");
            Instance.AudioSet("shot1", "weapon/shot1");
            //Instance.AudioSet("bgm", "bgm");
            //Instance.AudioSet("go", "go");
            //Instance.AudioSet("ppo", "ppo");
            //Instance.AudioSet("ppu", "ppu");
            //Instance.AudioSet("Dead", "dead");
            //Instance.AudioSet("KeyGain", "KeyGain");
            //Instance.AudioSet("ItemGain", "ItemGain");
            //Instance.AudioSet("TimeItem", "TimeItem");
            //Instance.AudioSet("ScoreMultiply", "ScoreMultiply");
            //Instance.AudioSet("ScoreItem", "ScoreItem");
            //Instance.AudioSet("none", "EFFECT1/075");
            //Instance.AudioSet("jump", "EFFECT1/078");
            //Instance.AudioSet("succeed", "EFFECT1/succeed");
            //Instance.AudioSet("npcmove", "EFFECT1/npcball");
            //Instance.AudioSet("ItemSelect", "ItemSelect");
            //Instance.AudioSet("MenuSelect", "MenuSelect");
            //Instance.AudioSet("LevelSelect", "LevelSelect");
            //Instance.AudioSet("Swish", "Swish");
            //Instance.AudioSet("SNDTRK4", "SNDTRK4");
        }
        public static TAudioMgr Instance
        {
            get
            {
                if (_mInstance == null)
                {
                    GameObject obj = new GameObject("TAudioMgr");
                    _mInstance = obj.AddComponent<TAudioMgr>();
                }
                return _mInstance;
            }
        }

        public void AudioSet(string keyName, string path)
        {
            if (!_audioPool.ContainsKey(keyName))
            {
                AudioClip clip = Resources.Load("sound/" + path) as AudioClip;
                AudioSource source = gameObject.AddComponent<AudioSource>();
                source.clip = clip;
                _audioPool.Add(keyName, source);
            }
        }

        public void PlayEffect(string audioKey, bool isLoop = false, bool isAwake = false)
        {
            if (m_effectSound == false) return;
            AudioSource source = _audioPool[audioKey];

            source.loop = isLoop;
            source.playOnAwake = isAwake;

            source.Play();
        }
        public void Play(string audioKey, bool isLoop = false, bool isAwake = false)
        {
            if (m_bgMusic == false) return;
            if(m_CurrentKey != string.Empty)
            {
                if (audioKey == m_CurrentKey) return;
                Stop(m_CurrentKey);                
            }
            AudioSource source = _audioPool[audioKey];
            m_CurrentKey = audioKey;
            source.loop = isLoop;
            source.playOnAwake = isAwake;
            m_CurrentKey = audioKey;
            source.Play();
        }
        public void Stop(string key)
        {
            _audioPool[key].Stop();
        }
    }
}
