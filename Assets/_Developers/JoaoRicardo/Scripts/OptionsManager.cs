using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using UnityEngine.UI;
using TMPro;

public class OptionsManager : MonoBehaviour
{
    public RectTransform sliderMenu;

    [SerializeField] private Slider musicS, soundS;

    private bool isDown = false;

    public void Settings()
    {
        if (isDown)
        {
            Vector2 currentPosition = sliderMenu.anchoredPosition;

            Vector2 targetPosition = currentPosition + new Vector2(0, 320);

            sliderMenu.DOAnchorPos(targetPosition, 1f);
        }
        else
        {
            Vector2 currentPosition = sliderMenu.anchoredPosition;

            Vector2 targetPosition = currentPosition - new Vector2(0, 320);

            sliderMenu.DOAnchorPos(targetPosition, 1f);
        }

        isDown = !  isDown;
    }
}
