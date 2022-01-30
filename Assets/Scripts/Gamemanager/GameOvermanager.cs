using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

public class GameOvermanager : MonoBehaviour
{
    public static GameOvermanager Goinstance;
    public GameObject gameOverpanel;
    private Animator gameoveranim;
    private Button playagainBtn , backBtn;
    private Text score;
    public GameObject test;
  

    private void Awake() 
    {
        Goinstance = this;

        //gameOverpanel = GameObject.Find("GameOverpanelholder");    
        gameoveranim = gameOverpanel.GetComponent<Animator>();

        playagainBtn = GameObject.Find("Restart").GetComponent<Button>();
        backBtn = GameObject.Find("Back").GetComponent<Button>();

       // scoretext = GameObject.Find("ScoreinLevel").GetComponent<TextMeshPro>();
        score = GameObject.Find("Score_number").GetComponent<Text>();
        
        gameOverpanel.SetActive(false);
    }

    public void showGameOverPanel()
    {
        test.SetActive(false);
        gameOverpanel.SetActive(true);
        score.text = Scoremanager.scoreinstance.getScore(); 
        gameoveranim.Play("FadeIn");
    }

    public void playAgain()
    {
        SceneManager.LoadScene("GameScene");
    }

    public void backtoMenu()
    {
        SceneManager.LoadScene("MainMenu");
    }
}