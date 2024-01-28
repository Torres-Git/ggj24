using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuManager : MonoBehaviour
{
    public RectTransform howToSlider;

    private bool isDown = false;

    public void Play()
    {
        SceneManager.LoadScene("Theater");
    }

    public void HowTo()
    {
        if (isDown)
        {
            Vector2 currentPosition = howToSlider.anchoredPosition;

            Vector2 targetPosition = currentPosition + new Vector2(0, 320);

            howToSlider.DOAnchorPos(targetPosition, 1f);
        }
        else
        {
            Vector2 currentPosition = howToSlider.anchoredPosition;

            Vector2 targetPosition = currentPosition - new Vector2(0, 320);

            howToSlider.DOAnchorPos(targetPosition, 1f);
        }

        isDown = !isDown;
    }
}
