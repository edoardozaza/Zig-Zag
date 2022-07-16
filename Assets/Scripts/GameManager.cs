using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager current;

    void Awake()
    {
        if (current == null)
            current = this;
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void StartGame()
    {

        UiManager.current.GameStart();
        ScoreManager.current.StartScore();
    }
    public void GameOver()
    {

        UiManager.current.GameOver();
        ScoreManager.current.StopScore();
    }

}
