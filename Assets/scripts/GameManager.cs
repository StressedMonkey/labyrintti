using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public void LostGame()
    {
        Debug.Log("Peli hävitty");
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
        SceneManager.LoadScene("defeat_scene");
    }

  public void WonGame()
    {
        Debug.Log("Peli voitettu");
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
        SceneManager.LoadScene("VictoryScene");
    }


    public void RestartGame()
    {
        Debug.Log("restart painettu");
        SceneManager.LoadScene("MainScene");
    }
}
