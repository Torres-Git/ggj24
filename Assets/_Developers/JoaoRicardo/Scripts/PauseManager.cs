using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using UnityEngine.SceneManagement;

public class PauseManager : MonoBehaviour
{
    public RectTransform sliderPause;
    [SerializeField] private Animator animator;

    private bool isPaused = false;

    public void Pause()
    {
        if (!isPaused)
        {
            animator.Play("SlidingDown", 0, 0.25f);
            isPaused = true;
        }
        Time.timeScale = 0f;
    }

    public void Resume()
    {
        Time.timeScale = 1f;
        if (isPaused)
        {
            animator.Play("SlidingUp", 0, 0.25f);
            isPaused = false;
        }
    }

    public void Quit()
    {
        SceneManager.LoadScene("MainMenu");
    }

}
