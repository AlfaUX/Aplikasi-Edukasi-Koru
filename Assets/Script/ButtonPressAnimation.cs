using UnityEngine;
using UnityEngine.EventSystems;
using DG.Tweening;

public class ButtonPressAnimation : MonoBehaviour,
    IPointerDownHandler,
    IPointerUpHandler
{
    [Header("Scale")]
    public float pressedScale = 1.1f;

    [Header("Duration")]
    public float pressDuration = 0.1f;
    public float releaseDuration = 0.15f;

    public void OnPointerDown(PointerEventData eventData)
    {
        transform
            .DOScale(pressedScale, pressDuration)
            .SetEase(Ease.OutQuad);
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        transform
            .DOScale(1f, releaseDuration)
            .SetEase(Ease.OutBack);
    }
}