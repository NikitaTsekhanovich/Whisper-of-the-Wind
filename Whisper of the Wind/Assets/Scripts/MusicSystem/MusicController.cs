using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

namespace MusicSystem
{
    public class MusicController : MonoBehaviour
    {
        [SerializeField] private Image _musicOnImage;
        [SerializeField] private Image _musicOffImage;
        [SerializeField] private Image _effectsOnImage;
        [SerializeField] private Image _effectsOffImage;
        [SerializeField] private AudioMixer _mixer;
        private ModeMusic _musicIsOn;
        private ModeMusic _effectsIsOn;
        private const int volumeOn = 0;
        private const int volumeOff = -80;
        private const string musicMixerName = "Music";
        private const string effectsMixerName = "SoundEffects";

        public static MusicController Instance;

        private void Start()
        {
            if (Instance == null)
                Instance = this;
            else
                Destroy(this);

            LoadState();
        }

        private void LoadState()
        {
            _musicIsOn = (ModeMusic)PlayerPrefs.GetInt(MusicDataKeys.MusicIsOnKey);
            _effectsIsOn = (ModeMusic)PlayerPrefs.GetInt(MusicDataKeys.EffectsIsOnKey);

            ChangeVolume(_musicIsOn, musicMixerName, _musicOnImage,
                _musicOffImage);
            ChangeVolume(_effectsIsOn, effectsMixerName, _effectsOnImage,
                _effectsOffImage);
        }

        public void CheckMusicState()
        {
            ChangeState(ref _musicIsOn, MusicDataKeys.MusicIsOnKey);
            ChangeVolume(_musicIsOn, musicMixerName, _musicOnImage,
                _musicOffImage);
        }

        public void CheckSoundEffectsState()
        {
            ChangeState(ref _effectsIsOn, MusicDataKeys.EffectsIsOnKey);
            ChangeVolume(_effectsIsOn, effectsMixerName, _effectsOnImage,
                _effectsOffImage);
        }

        private void ChangeState(ref ModeMusic mode, string key)
        {
            mode = (ModeMusic)(((int)mode + (int)ModeMusic.Off) % 2);
            PlayerPrefs.SetInt(key, (int)mode);
        }

        private void ChangeVolume(ModeMusic isOn, string mixerName, Image onImage, Image offImage)
        {
            if (isOn == ModeMusic.On)
            {
                _mixer.SetFloat(mixerName, volumeOn);
                onImage.enabled = true;
                offImage.enabled = false;
            }
            else
            {
                _mixer.SetFloat(mixerName, volumeOff);
                onImage.enabled = false;
                offImage.enabled = true;
            }
        }
    }
}