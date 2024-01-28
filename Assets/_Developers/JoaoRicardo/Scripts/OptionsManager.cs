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
    [SerializeField] private TextMeshProUGUI soundV, musicV;

    private bool isDown = false;

    // Start is called before the first frame update
    void Start()
    {
        musicS.onValueChanged.AddListener((v) =>
        {
            musicV.text = v.ToString();
        });

        soundS.onValueChanged.AddListener((v) =>
        {
            soundV.text = v.ToString();
        });
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Settings()
    {
        if (isDown)
        {
            // Obtém a posição atual do sliderMenu
            Vector2 currentPosition = sliderMenu.anchoredPosition;

            // Define o destino como 160 pixels abaixo da posição atual no eixo Y
            Vector2 targetPosition = currentPosition + new Vector2(0, 320);

            // Move o sliderMenu para o destino em 1 segundo
            sliderMenu.DOAnchorPos(targetPosition, 1f);
        }
        else
        {
            // Obtém a posição atual do sliderMenu
            Vector2 currentPosition = sliderMenu.anchoredPosition;

            // Define o destino como 160 pixels abaixo da posição atual no eixo Y
            Vector2 targetPosition = currentPosition - new Vector2(0, 320);

            // Move o sliderMenu para o destino em 1 segundo
            sliderMenu.DOAnchorPos(targetPosition, 1f);
        }

        isDown = !  isDown;
    }
}
