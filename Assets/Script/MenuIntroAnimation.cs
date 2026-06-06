using UnityEngine;
using DG.Tweening;

public class MenuIntroAnimation : MonoBehaviour
{
    [Header("Buttons")]
    public RectTransform[] buttons;

    [Header("Animation")]
    public float startX = -1200f;
    public float duration = 0.6f;
    public float delayBetween = 0.12f;

    [Header("Scale Effect")]
    public float startScale = 0.6f;

    void Start()
    {
        AnimateButtons();
    }

    void AnimateButtons()
    {
        for (int i = 0; i < buttons.Length; i++)
        {
            RectTransform btn = buttons[i];

            Vector2 targetPos = btn.anchoredPosition;

            // Posisi awal di kiri
            btn.anchoredPosition =
                new Vector2(startX, targetPos.y);

            // Scale awal kecil
            btn.localScale =
                Vector3.one * startScale;

            // Fade awal
            CanvasGroup cg =
                btn.GetComponent<CanvasGroup>();

            if (cg == null)
            {
                cg = btn.gameObject.AddComponent<CanvasGroup>();
            }

            cg.alpha = 0f;

            float delay = i * delayBetween;

            // Move
            btn.DOAnchorPos(
                targetPos,
                duration
            )
            .SetEase(Ease.OutBack)
            .SetDelay(delay);

            // Scale pop
            btn.DOScale(
                1f,
                duration
            )
            .SetEase(Ease.OutBack)
            .SetDelay(delay);

            // Fade
            cg.DOFade(
                1f,
                duration * 0.8f
            )
            .SetDelay(delay);
        }
    }
}