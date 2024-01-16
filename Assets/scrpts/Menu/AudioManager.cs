using UnityEngine;
using UnityEngine.Audio;

public class AudioManager : MonoBehaviour
{
    public static AudioManager instance;

    [SerializeField] AudioMixer mixer;

    public const string MUSIC_KEY = "music_Volume";
    public const string SFX_KEY = "sfx_Volume";
    public const string MASTER_KEY = "master_Volume";

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;

        }
        else
        {
            Destroy(gameObject);
        }
        LoadVolume();
    }

    void LoadVolume()
    {
        float musicVolume = PlayerPrefs.GetFloat(MUSIC_KEY, 1.0f);
        float sfxVolume = PlayerPrefs.GetFloat(SFX_KEY, 1.0f);
        float masterVolume = PlayerPrefs.GetFloat(MASTER_KEY, 1.0f);

        mixer.SetFloat(VolumeController.MUSIC_MIXER, Mathf.Log10(musicVolume) * 20);
        mixer.SetFloat(VolumeController.SFX_MIXER, Mathf.Log10(sfxVolume) * 20);
        mixer.SetFloat(VolumeController.MASTER_MIXER, Mathf.Log10(masterVolume) * 20);
    }
}