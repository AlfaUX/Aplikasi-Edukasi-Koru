using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

public class SettingsMenu : MonoBehaviour
{
    [Header("Space between menu items")]
    [SerializeField] Vector2 spacing;

    [Space]
    [Header("Main button rotation")]
    [SerializeField] float rotationDuration;
    [SerializeField] Ease rotationEase;

    [Space]
    [Header("Animation")]
    [SerializeField] float expandDuration;
    [SerializeField] float collapseDuration;
    [SerializeField] Ease expandEase;
    [SerializeField] Ease collapseEase;

    [Space]
    [Header("Fading")]
    [SerializeField] float expandFadeDuration;
    [SerializeField] float collapseFadeDuration;

    Button mainButton;
    SettingsMenuItem[] menuItems;

    int itemsCount;

    bool isExpanded = false;

    Vector2 mainButtonPosition;

    void Start()
    {
        itemsCount = transform.childCount - 1;

        menuItems = new SettingsMenuItem[itemsCount];

        for (int i = 0; i < itemsCount; i++)
        {
            menuItems[i] =
                transform.GetChild(i + 1)
                .GetComponent<SettingsMenuItem>();
        }

        mainButton =
            transform.GetChild(0)
            .GetComponent<Button>();

        mainButton.onClick.AddListener(ToggleMenu);

        mainButton.transform.SetAsLastSibling();

        mainButtonPosition = mainButton.transform.position;

        ResetPosition();
    }

    void ResetPosition()
    {
        for (int i = 0; i < itemsCount; i++)
        {
            menuItems[i].trans.position =
                mainButtonPosition;

            menuItems[i].img.color =
                new Color(1, 1, 1, 0);
        }
    }

    void ToggleMenu()
    {
        isExpanded = !isExpanded;

        if (isExpanded)
        {
            for (int i = 0; i < itemsCount; i++)
            {
                menuItems[i].trans.DOMove(
                    mainButtonPosition + spacing * (i + 1),
                    expandDuration
                ).SetEase(expandEase);

                menuItems[i].img
                    .DOFade(1f, expandFadeDuration)
                    .From(0f);
            }
        }
        else
        {
            for (int i = 0; i < itemsCount; i++)
            {
                menuItems[i].trans.DOMove(
                    mainButtonPosition,
                    collapseDuration
                ).SetEase(collapseEase);

                menuItems[i].img
                    .DOFade(0f, collapseFadeDuration);
            }
        }

        // Rotate main button
        mainButton.transform.DORotate(
            Vector3.forward * 180f,
            rotationDuration
        )
        .From(Vector3.zero)
        .SetEase(rotationEase);
    }

    void OnDestroy()
    {
        mainButton.onClick.RemoveListener(ToggleMenu);
    }
}