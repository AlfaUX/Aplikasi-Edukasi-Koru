using UnityEngine;
using DG.Tweening;

public class PanelSwitcher : MonoBehaviour
{
    public RectTransform panel1;
    public RectTransform panel2;

    public float duration = 0.4f;

    Vector2 center = Vector2.zero;
    Vector2 left = new Vector2(-1500, 0);
    Vector2 right = new Vector2(1500, 0);

    void Start()
    {
        panel1.anchoredPosition = center;
        panel2.anchoredPosition = right;
    }

    public void Next()
    {
        panel1.DOAnchorPos(left, duration).SetEase(Ease.InOutCubic);
        panel2.DOAnchorPos(center, duration).SetEase(Ease.OutBack);
    }

    public void Back()
    {
        panel1.DOAnchorPos(center, duration).SetEase(Ease.OutBack);
        panel2.DOAnchorPos(right, duration).SetEase(Ease.InOutCubic);
    }
}