using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class UiManager : MonoBehaviour
{
    public GameObject startPanel;
    public GameObject gameOverPanel;
    public GameObject cliccaText;
    public GameObject punteggioText;
    public GameObject highScoreText;
    public Text score;
    public Text punteggioLabelText;
    public Text highScore1;
    public Text highScore2;
    public static UiManager current;

    void Awake()
    {
        if (current == null)
            current = this;
    }



    // Start is called before the first frame update
    void Start()
    {
        if (PlayerPrefs.HasKey("highScore"))
            highScore1.text = "High Score: " + PlayerPrefs.GetInt("highScore");
        else
            highScore1.text = "High Score: 0";
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void GameStart()
    {
        cliccaText.GetComponent<Animator>().Play("textDisappear");
        startPanel.GetComponent<Animator>().Play("startPanelDisappear");

        punteggioText.SetActive(true);

    }

    public void GameOver()
    {
        score.text = PlayerPrefs.GetInt("score").ToString();
        highScore2.text = PlayerPrefs.GetInt("highScore").ToString();

        gameOverPanel.SetActive(true);

        punteggioText.SetActive(false);
    }

    public void Riparti()
    {
       SceneManager.LoadScene(0);
    }

}
