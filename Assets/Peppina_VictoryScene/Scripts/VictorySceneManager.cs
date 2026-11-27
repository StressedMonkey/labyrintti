using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using System.Collections;
using System;

public class VictorySceneManager : MonoBehaviour
{

    public GameObject victoryText;
    public GameObject restartButton;
    public GameObject mainMenuButton;
    public Animator victoryTextAnimator;


    public Animator whiteFadeAnimator;
    public Animator restartButtonAnimator;
    public Animator mainMenuButtonAnimator;

 

   // Labyrintti skenen nimi
    public string gameSceneName = "MainScene";
     
   //Lisättävä Main Menu-valikon nimi
    public string mainMenuSceneName = "MainMenu";



    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        whiteFadeAnimator.Play("WhiteFade_Out");
        victoryTextAnimator.Play("VictoryText_FadeIn");

        restartButton.SetActive(false);
        mainMenuButton.SetActive(false);

        StartCoroutine(ShowVictoryButtons());
        
    }


     IEnumerator ShowVictoryButtons()
    {
        yield return new WaitForSeconds(2f);
        restartButton.SetActive(true);
        mainMenuButton.SetActive(true);

        restartButtonAnimator.Play("RestartButton_FadeIn");
        mainMenuButtonAnimator.Play("MainMenuButton_FadeIn");

    }



    public void RestartGame()
    {
        SceneManager.LoadScene(gameSceneName);
         Debug.Log("Game restarted!");
    }

    public void MainMenu()
    {
        SceneManager.LoadScene(mainMenuSceneName);
    }


    // Update is called once per frame
   // void Update()
   // {
        

}