using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using UnityEngine.SceneManagement;

public class PauseManager : MonoBehaviour
{
    public RectTransform sliderPause, sliderOpt;
    [SerializeField] private Animator animatorMain, animatorOpt;

    private bool isPaused = false;

    public void Pause()
    {
        if (!isPaused)
        {
            animatorMain.Play("SlidingDown", 0, 0.25f);
            animatorOpt.Play("GoDown", 0, 0.25f);
            isPaused = true;
        }
        Time.timeScale = 0f;
    }

    public void Resume()
    {
        Time.timeScale = 1f;
        if (isPaused)
        {
            animatorMain.Play("SlidingUp", 0, 0.25f);
            animatorOpt.Play("GoUp", 0, 0.25f);
            isPaused = false;
        }
    }

    public void Restart()
    {
        SceneManager.LoadScene("Theater");
    }
    public void Quit()
    {
        SceneManager.LoadScene("MainMenu");
    }

}
