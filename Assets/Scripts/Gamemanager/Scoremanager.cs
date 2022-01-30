using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Scoremanager : MonoBehaviour
{
    public static Scoremanager scoreinstance;
    public Text scoretext;
    private int score = 0;

    private void Awake()
    {
        scoreinstance = this; 
        //scoretext = GameObject.Find("ScoreinLevel").GetComponent<Text>();
    }

    public void addScore()
    {
        score++;
        scoretext.text =  score.ToString();
    }

    public string getScore()
    {
        return score.ToString();
    }
}
