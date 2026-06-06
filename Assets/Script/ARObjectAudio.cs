using UnityEngine;
using Vuforia;

public class ARObjectAudio : MonoBehaviour
{
    [Header("Audio Objek")]
    public AudioClip audioClip;

    [HideInInspector]
    public bool isTracked;

    private ObserverBehaviour observer;

    private void Start()
    {
        observer = GetComponent<ObserverBehaviour>();

        if (observer != null)
        {
            observer.OnTargetStatusChanged += OnStatusChanged;
        }
    }

    private void OnStatusChanged(ObserverBehaviour behaviour, TargetStatus status)
    {
        isTracked =
            status.Status == Status.TRACKED ||
            status.Status == Status.EXTENDED_TRACKED;
    }

    private void OnDestroy()
    {
        if (observer != null)
        {
            observer.OnTargetStatusChanged -= OnStatusChanged;
        }
    }
}