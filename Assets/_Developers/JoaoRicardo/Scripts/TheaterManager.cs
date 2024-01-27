using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TheaterManager : MonoBehaviour
{
    private int score = 0;

    public Text scoreText;
    public Text waveText;
    
    
    [SerializeField] private WaveManager waveManager;
    // Start is called before the first frame update
    void Start()
    {
        waveManager.StartFirstWave();
        scoreText.text = "Score: " + score.ToString();
    }

    // Update is called once per frame
    void Update()
    {
        waveText.text = waveManager.WaveNumber.ToString();
    }
}
