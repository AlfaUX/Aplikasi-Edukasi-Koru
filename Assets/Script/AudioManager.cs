using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public static AudioManager instance;

    AudioSource audioSource;

    public bool isMuted;

    void Awake()
    {
        if (instance == null)
        {
            instance = this;

            DontDestroyOnLoad(gameObject);

            audioSource = GetComponent<AudioSource>();

            // Load setting
            isMuted = PlayerPrefs.GetInt("Music", 1) == 0;

            audioSource.mute = isMuted;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public void ToggleMusic()
    {
        isMuted = !isMuted;

        audioSource.mute = isMuted;

        PlayerPrefs.SetInt("Music", isMuted ? 0 : 1);
    }
}