using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TheaterManager : MonoBehaviour
{
    private int score = 0;


    public Text scoreText;
    public Text waveText;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

        if(Input.GetKeyUp(KeyCode.Space))
        {
            score += 100;
        }
        scoreText.text = "Score: " + score.ToString();
    }
}
