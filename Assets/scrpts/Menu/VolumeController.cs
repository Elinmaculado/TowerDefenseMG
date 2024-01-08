using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class VolumeController : MonoBehaviour
{
    [SerializeField] AudioMixer audioMixer;
    [SerializeField] Slider musicSlider;
    [SerializeField] Slider sfxSlider;
    [SerializeField] Slider masterSlider;

    public const string MUSIC_MIXER = "Music";
    public const string SFX_MIXER = "SFX";
    public const string MASTER_MIXER = "Master";

    private void Awake()
    {
        musicSlider.onValueChanged.AddListener(SetMusicVolume);
        sfxSlider.onValueChanged.AddListener(SetSFXVolume);
        masterSlider.onValueChanged.AddListener(SetMasterVolume);
    }

    private void Start()
    {
        musicSlider.value = PlayerPrefs.GetFloat(AudioManager.MUSIC_KEY, 1.0f);
        sfxSlider.value = PlayerPrefs.GetFloat(AudioManager.SFX_KEY, 1.0f);
        masterSlider.value = PlayerPrefs.GetFloat(AudioManager.MASTER_KEY, 1.0f);
    }
    void SetMusicVolume(float volume)
    {
        audioMixer.SetFloat(MUSIC_MIXER, Mathf.Log10(volume) * 20);
        PlayerPrefs.SetFloat(AudioManager.MUSIC_KEY, musicSlider.value);
    }
    void SetSFXVolume(float volume)
    {
        audioMixer.SetFloat(SFX_MIXER, Mathf.Log10(volume) * 20);
        PlayerPrefs.SetFloat(AudioManager.SFX_KEY, sfxSlider.value);
    }
    void SetMasterVolume(float volume)
    {
        audioMixer.SetFloat(MASTER_MIXER, Mathf.Log10(volume) * 20);
        PlayerPrefs.SetFloat(AudioManager.MASTER_KEY, masterSlider.value);
    }

}
