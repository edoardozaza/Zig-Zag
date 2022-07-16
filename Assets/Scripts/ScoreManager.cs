using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreManager : MonoBehaviour
{
    public static ScoreManager current;
    int score;
    int highScore;
    bool highScorePlayed;
    public AudioClip highScoreFx;
    //public AudioClip diamondFx;

    void Awake()
    {
        if (current == null)
            current = this;
    }

    // Start is called before the first frame update
    void Start()
    {
        score = 0;
        highScorePlayed = false;

    }

    // Update is called once per frame
    void Update()
    {

    }

    void IncrementaScore()
    {
        score += 1;
        UiManager.current.punteggioLabelText.text = score.ToString();
        //controllo se ha superato l'high score e in caso mostro l'animazione
        if (PlayerPrefs.HasKey("highScore") && !highScorePlayed)
        {

            if (score > PlayerPrefs.GetInt("highScore"))
            {

                UiManager.current.highScoreText.SetActive(true);
                AudioManager.current.PlaySound(highScoreFx);

                highScorePlayed = true;
            }
        }
    }
    public void DiamondScore()
    {
        //estraggo numero random da 0 a 5
        int rand = Random.Range(0, 6);
        score += rand;

        UiManager.current.punteggioLabelText.text = score.ToString();
        //controllo se ha superato l'high score e in caso mostro l'animazione
        if (PlayerPrefs.HasKey("highScore") && !highScorePlayed)
        {

            if (score > PlayerPrefs.GetInt("highScore"))
            {

                UiManager.current.highScoreText.SetActive(true);
                AudioManager.current.PlaySound(highScoreFx);
                highScorePlayed = true;
            }
        }
    }

     public void StartScore()
    {
        InvokeRepeating("IncrementaScore", 0.1f, 0.5f);
    }

    public void StopScore()
    {
        CancelInvoke("IncrementaScore");

        //registro l'ultimo score ottenuto
        PlayerPrefs.SetInt("score", score);
        //registro l'high score
        if (PlayerPrefs.HasKey("highScore"))
        {

            if (score > PlayerPrefs.GetInt("highScore"))
                PlayerPrefs.SetInt("highScore", score);
        }

        else
            PlayerPrefs.SetInt("highScore", score);
    }
}


