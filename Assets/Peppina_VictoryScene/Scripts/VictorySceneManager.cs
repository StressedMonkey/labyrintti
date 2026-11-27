using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using System.Collections;

public class VictorySceneManager : MonoBehaviour
{


    public GameObject victoryText;
    public GameObject restartButton;
    public GameObject mainMenuButton;
    public Animator victoryTextAnimator;


    public Animator whiteFadeAnimator;
    public Animator restartButtonAnimator;
    public Animator mainMenuButtonAnimator;

 

   //Lisättävä Labyrintti skenen nimi
    public string gameSceneName = "GameScene";
     //Lisättävä Main Menun nimi
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
        restartButtonAnimator.Play("RestartButton_FadeIn");
        mainMenuButtonAnimator.Play("MainMenuButton_FadeIn");

        restartButton.SetActive(true);
        mainMenuButton.SetActive(true);
    }


   //Lisättävä Labyrintti skenen nimi
    public void RestartGame()
    {
        SceneManager.LoadScene(gameSceneName);
    }

   //Lisättävä Main Menun nimi
    public void MainMenu()
    {
        SceneManager.LoadScene(mainMenuSceneName);
    }



    // Update is called once per frame
   // void Update()
   // {
        

}