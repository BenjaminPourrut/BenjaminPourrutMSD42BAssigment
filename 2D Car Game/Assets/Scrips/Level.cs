using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

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
        SceneManager.LoadScene("StartMenu");
    }
    public void LoadGame()
    {
        //This will load the game with the scene name of 2DCarGame
        SceneManager.LoadScene("2DCarGame");

        //This will restart the game setion with the points included
        FindObjectOfType<GameSession>().ResetGame();
    }

    public void LoadGame2()
    {
        //This will load the game with the scene name of 2DCarGame
        SceneManager.LoadScene("2DCarGame");
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
        Application.Quit();
    }

    //int scoreText = 100;
    GameSession gameSession;

    // Start is called before the first frame update
    void Start()
    {
        gameSession = FindObjectOfType<GameSession>();
    }

    // Update is called once per frame
    void Update()
    {
        int scoreText = gameSession.GetScore();

        if (scoreText >= 100)
        {
            LoadWinner();
        }
    }
}
