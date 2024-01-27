using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class OptionsManager : MonoBehaviour
{
    public RectTransform sliderMenu;

    private bool isDown = false;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Settings()
    {
        if (isDown)
        {
            // Obt�m a posi��o atual do sliderMenu
            Vector2 currentPosition = sliderMenu.anchoredPosition;

            // Define o destino como 160 pixels abaixo da posi��o atual no eixo Y
            Vector2 targetPosition = currentPosition + new Vector2(0, 320);

            // Move o sliderMenu para o destino em 1 segundo
            sliderMenu.DOAnchorPos(targetPosition, 1f);
        }
        else
        {
            // Obt�m a posi��o atual do sliderMenu
            Vector2 currentPosition = sliderMenu.anchoredPosition;

            // Define o destino como 160 pixels abaixo da posi��o atual no eixo Y
            Vector2 targetPosition = currentPosition - new Vector2(0, 320);

            // Move o sliderMenu para o destino em 1 segundo
            sliderMenu.DOAnchorPos(targetPosition, 1f);
        }

        isDown = !  isDown;
    }
}
