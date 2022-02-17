using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;


public class Interstitial : MonoBehaviour
{
    public int trialNum;
    public string trialName;
    public List<string> trials;

    public TextMeshProUGUI message;

    void Start()
    {
        trialNum = GlobalControl.Instance.trialNum;
        trialName = GlobalControl.Instance.trialName;
        trials = GlobalControl.Instance.trials;

        MessagePlayer();
    }

    public void SaveGame()
    {
        GlobalControl.Instance.trialNum = trialNum;
        GlobalControl.Instance.trialName = trialName;
        GlobalControl.Instance.trials = trials;
    }

    void Update()
    {
        if (Input.GetKeyDown("space"))
        {
            newTrial();
        }

    }

    void MessagePlayer()
    {
        message.text = "trial " + trialNum + "\n"+"Press Space to play again";
    }

    void newTrial()
    {

        Tinylytics.AnalyticsManager.LogCustomMetric("New Trial Number: ", trialNum.ToString());
        Tinylytics.AnalyticsManager.LogCustomMetric("New Trial Name: ", trialName);

        SceneManager.LoadScene(trialName);

    }
}
