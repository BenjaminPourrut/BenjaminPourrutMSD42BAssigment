using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Level : MonoBehaviour
{
    [SerializeField] float delayInSeconds = 2f;

    IEnumerator WaitAndLoad()
    {
        yield return new WaitForSeconds(delayInSeconds);
        SceneManager.LoadScene("GameOver");
    }
    public void LoadStartMenu()
    {
        //This will load the first scene in this project
        SceneManager.LoadScene(0);
    }
    public void LoadGame()
    {
        //This will load the game with the scene name of 2DCarGame
        SceneManager.LoadScene("2DCarGame");
        print("test 1");
        //This will restart the game setion with the points included
        FindObjectOfType<GameSession>().ResetGame();
        print("test 2");
    }
    public void LoadGameOver()
    {
        //This will load the Game Over scene
        SceneManager.LoadScene("GameOver");
    }
    public void LoadWinner()
    {
        SceneManager.LoadScene("Winner");
    }
    public void QuitGame()
    {
        print("Qutting Game");
        Application.Quit();
    }
}
