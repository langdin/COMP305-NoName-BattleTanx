﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Stage2MenuController : MonoBehaviour
{
    private Animator anim; // board animation after level completed
    public Text txtScore;
    public static int score;

    void Start () 
    {
        anim = (GameObject.FindWithTag("levelCompleted")).GetComponent<Animator>();
    }

    void Update()
    {
        txtScore.text = "SCORE: " + score.ToString();

        if (score >= 70)
        {
            anim.SetBool("isFinished", true);
        }
    }

    public void NextGame()
    {
        Stage3MenuController.score = score;
        SceneManager.LoadScene("Stage3");
    }

    // What happens when I click the quit button?
    public void QuitGame()
    {
        HomingMissileScript.score = 0;
        // Preprocessor Directives
        #if UNITY_EDITOR
            UnityEditor.EditorApplication.isPlaying = false;
        #else
             Application.Quit();
        #endif
    }
}
