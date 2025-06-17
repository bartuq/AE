using System;
using System.Collections.Generic;
using UnityEngine;

namespace AE
{
    public class AudioManager : MonoBehaviour
    {
        [SerializeField] private AudioSource _musicSource;
        [SerializeField] private AudioSource _sfxSource;

        [Header("Music")]
        [SerializeField] private AudioClip _level01Music;

        [Header("SFX")]
        [SerializeField] private AudioClip _footstepsSfx;
        [SerializeField] private AudioClip _pickupSfx;
        [SerializeField] private AudioClip _torchSfx;
        [SerializeField] private AudioClip _whisperSfx;
        [SerializeField] private AudioClip _throwSfx;
        [SerializeField] private AudioClip _crateHitSfx;

        private Dictionary<string, AudioClip> _musicClips;
        private Dictionary<string, AudioClip> _sfxClips;

        private void Awake()
        {
            SetupMusicDictionary();
            SetupSfxDictionary();
        }

        private void Start()
        {
            PlayMusic(_level01Music);
        }

        public void PlayMusic(AudioClip clip, bool loop = true)
        {
            if (!_musicSource) return;
            _musicSource.clip = clip;
            _musicSource.loop = loop;
            _musicSource.Play();
        }

        public void PlaySfx(AudioClip clip)
        {
            if (!_sfxSource || !clip) return;
            _sfxSource.PlayOneShot(clip);
        }

        public void PlaySfxLoop(AudioClip clip)
        {
            if (!_sfxSource || clip == null) return;

            _sfxSource.clip = clip;
            _sfxSource.loop = true;
            _sfxSource.Play();
        }

        public void PlayMusicByKey(string clipName, Action callback = null)
        {
            if (!_musicSource || string.IsNullOrEmpty(clipName)) return;
            if (_musicClips.TryGetValue(clipName, out AudioClip clip) && clip != null)
            {
                _musicSource.PlayOneShot(clip);
                callback?.Invoke();
            }
        }

        public void PlaySfxByKey(string clipName, Action callback = null)
        {
            if (!_sfxSource || string.IsNullOrEmpty(clipName)) return;
            if (_sfxClips.TryGetValue(clipName, out AudioClip clip) && clip != null)
            {
                _sfxSource.PlayOneShot(clip);
                callback?.Invoke();
            }
        }

        public void PlaySfxLoopByKey(string clipName, Action callback = null)
        {
            if (!_sfxSource) return;

            if (string.IsNullOrEmpty(clipName))
            {
                _sfxSource.Stop();
                _sfxSource.clip = null;
                _sfxSource.loop = false;
                return;
            }

            if (_sfxClips.TryGetValue(clipName, out AudioClip clip) && clip != null)
            {
                _sfxSource.clip = clip;
                _sfxSource.loop = true;
                _sfxSource.Play();
                callback?.Invoke();
            }
        }

        private void SetupMusicDictionary()
        {
            _musicClips = new Dictionary<string, AudioClip>
            {
                { "Level_01", _footstepsSfx }
            };
        }

        private void SetupSfxDictionary()
        {
            _sfxClips = new Dictionary<string, AudioClip>
            {
                { "Footsteps", _footstepsSfx },
                { "Pickup", _pickupSfx },
                { "Torch", _torchSfx },
                { "Whisper", _whisperSfx },
                { "Throw", _throwSfx },
                { "CrateHit", _crateHitSfx }
            };
        }
    }
}
