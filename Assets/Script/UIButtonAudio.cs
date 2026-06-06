using UnityEngine;

[RequireComponent(typeof(AudioSource))]
public class UIButtonAudio : MonoBehaviour
{
    private AudioSource audioSource;

    private void Awake()
    {
        audioSource = GetComponent<AudioSource>();
    }

    public void PlayCurrentObjectAudio()
    {
        ARObjectAudio[] objects =
            FindObjectsOfType<ARObjectAudio>();

        ARObjectAudio trackedObject = null;

        foreach (ARObjectAudio obj in objects)
        {
            if (obj.isTracked)
            {
                trackedObject = obj;
                break;
            }
        }

        // Tidak ada marker terdeteksi
        if (trackedObject == null)
        {
            Debug.Log("Marker tidak terdeteksi.");
            audioSource.Stop();
            return;
        }

        // Audio kosong
        if (trackedObject.audioClip == null)
        {
            Debug.Log("Audio belum diisi.");
            return;
        }

        // Jika audio sama sedang diputar
        if (audioSource.isPlaying &&
            audioSource.clip == trackedObject.audioClip)
        {
            audioSource.Stop();
            return;
        }

        // Play audio baru
        audioSource.Stop();
        audioSource.clip = trackedObject.audioClip;
        audioSource.Play();
    }
}