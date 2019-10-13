using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Timer : MonoBehaviour {
    public Text timerLabel, timeleft, money;


    public float time;
    public bool goal = false, start = false;
    bool scoreReceived = false;
    GameObject results;
    private static float addToMain;

    private void Start()
    {
        results = GameObject.Find("ResultsCanvas");
        results.SetActive(false);
    }

    void Update()
    {
        if ((time > 0) && (start == true))
        {
            time -= Time.deltaTime;
        }
        var seconds = time;
        timerLabel.text = string.Format("Time Remaining : {0:00}", seconds);
        if ((seconds <= 0 || goal == true) && scoreReceived == false)
        {
            float timeLeft = time;
            float moneyEarned = time * 35;
            scoreReceived = true;
            results.SetActive(true);
            timeleft.text = string.Format("{0}", timeLeft);
            money.text = string.Format("{0}", moneyEarned);
            Money.currentMoney += moneyEarned;
        }
    }
}
