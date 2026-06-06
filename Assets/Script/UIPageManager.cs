using UnityEngine;
using DG.Tweening;

public class UIPageManager : MonoBehaviour
{
    [Header("Current Page")]
    public RectTransform currentPage;

    [Header("Target Page")]
    public RectTransform targetPage;

    [Header("Animation")]
    public float duration = 0.3f;

    [Header("Back Direction")]
    public bool isBack;

    float width;

    void Start()
    {
        width = Screen.width;
    }

    public void SlidePage()
    {
        targetPage.gameObject.SetActive(true);

        if (isBack)
        {
            // BACK

            targetPage.anchoredPosition =
                new Vector2(-width, 0);

            currentPage.DOAnchorPosX(
                width,
                duration
            ).SetEase(Ease.Linear)
            .OnComplete(() =>
            {
                currentPage.gameObject.SetActive(false);
            });
        }
        else
        {
            // NEXT / DETAIL

            targetPage.anchoredPosition =
                new Vector2(width, 0);

            currentPage.DOAnchorPosX(
                -width,
                duration
            ).SetEase(Ease.Linear)
            .OnComplete(() =>
            {
                currentPage.gameObject.SetActive(false);
            });
        }

        targetPage.DOAnchorPosX(
            0,
            duration
        ).SetEase(Ease.Linear);
    }
}