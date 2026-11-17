using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using System.Collections;

public class VictorySceneManager : MonoBehaviour
{

    [Header("Victory UI")]
    public GameObject victoryText;
    public GameObject restartButton;
    public GameObject mainMenuButton;
    public Animator victoryTextAnimator;

    [Header("Fade Animation")]
    public Animator whiteFadeAnimator;
    public Animator restartButtonAnimator;
    public Animator mainMenuButtonAnimator;

    [Header("Scenes")]


    public string gameSceneName = "GameScene";
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