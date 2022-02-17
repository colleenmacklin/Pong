using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class GameManager : MonoBehaviour
{
    public Ball ball;
    public int winningScore;

    public Text playerScoreText;
    public Text computerScoreText;

    private int _playerScore;
    private int _computerScore;

    public int trialNum;
    public string trialName;
    public List<string> trials;

    void Start()
    {
        trialNum = GlobalControl.Instance.trialNum;
        trialName = GlobalControl.Instance.trialName;
        trials = GlobalControl.Instance.trials;
    }

    public void SaveGame()
    {
        print("saving game, trial: " + trialNum);
        GlobalControl.Instance.trialNum = trialNum;
        GlobalControl.Instance.trialName = trialName;
        GlobalControl.Instance.trials = trials;
    }


    public void PlayerScores()
    {
        //Tinylytics.AnalyticsManager.LogCustomMetric("Player Score", _playerScore.ToString());
        _playerScore++;
        this.playerScoreText.text = _playerScore.ToString();
        ResetRound();
    }

    public void ComputerScores()
    {
        //Tinylytics.AnalyticsManager.LogCustomMetric("Computer Score", _computerScore.ToString());
        _computerScore++;
        this.computerScoreText.text = _computerScore.ToString();
        ResetRound();
    }


    private void ResetRound()
    {
        if (_playerScore == winningScore || _computerScore == winningScore)
        {
            newTrial();
        }
        else {
            print("keep playing");
        this.ball.ResetPosition();
        this.ball.AddStartingForce();
    }
    }

    void newTrial()
    {
        trialNum = trialNum + 1;
        print("trialnum: " + trialNum);
        if (trialNum >= trials.Count)
        {
            //tinyLytics post ending time

            SceneManager.LoadScene("ending");

        }else

        {
            //increase trial num
            trialName = trials[trialNum];
            SaveGame();

            SceneManager.LoadScene("trial_indicator");
        }
    }
}
