using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TheaterManager : MonoBehaviour
{
    private int score = 0;

    [SerializeField] WaveManager waveManager;

    public Text scoreText;
    public Text waveText;

    // Start is called before the first frame update
    void Start()
    {
        waveManager.StartFirstWave();
    }

    // Update is called once per frame
    void Update()
    {
        scoreText.text = "Score: " + score.ToString();
        waveText.text = "Wave: " + waveManager.WaveNumber.ToString();
    }
}
