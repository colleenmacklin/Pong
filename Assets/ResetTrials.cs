using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class ResetTrials : MonoBehaviour
{
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
        GlobalControl.Instance.trialNum = trialNum;
        GlobalControl.Instance.trialName = trialName;
        GlobalControl.Instance.trials = trials;
    }

    void Update()
    {
        if (Input.GetKeyDown("space"))
        {
            newPlayer();
        }

    }


    void newPlayer()
    {

        Tinylytics.AnalyticsManager.LogCustomMetric("game ended: ", "time:" + System.DateTime.Now);

        Destroy(GlobalControl.Instance); // this destroys the global trial list we initiated at game opening

        SceneManager.LoadScene("Opening_Scene");

    }
}
