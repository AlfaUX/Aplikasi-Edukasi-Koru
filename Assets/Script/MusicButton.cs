using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

public class MusicButton : MonoBehaviour
{
    public Image icon;

    public Sprite musicOn;
    public Sprite musicOff;

    void Start()
    {
        UpdateIcon();
    }

    public void ToggleMusic()
    {
        AudioManager.instance.ToggleMusic();

        UpdateIcon();

        transform.DOPunchScale(
            Vector3.one * 0.2f,
            0.2f,
            10,
            1
        );
    }

    void UpdateIcon()
    {
        if (AudioManager.instance.isMuted)
        {
            icon.sprite = musicOff;
        }
        else
        {
            icon.sprite = musicOn;
        }
    }
}