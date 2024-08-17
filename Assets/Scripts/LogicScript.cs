using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class LogicScript : MonoBehaviour
{
    public int playerScore;
    public Text scoreText;
    public GameObject gameOverScreen;
    public GameObject bird;
    public AudioClip dingClip;
    public AudioClip gameOverClip;
    private AudioSource audioSource;

    public void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }
    public void addScore(int scoreToAdd)
    {
        if (bird.GetComponent<BirdScript>().birdIsAlive)
        {
            playerScore += scoreToAdd;
            scoreText.text = playerScore.ToString();
            audioSource.clip = dingClip;
            audioSource.Play();
        }

    }

    public void restartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void startGame()
    {
        SceneManager.LoadScene("Game");
    }

    public void gameOver()
    {
        Debug.Log("Died");
        gameOverScreen.SetActive(true);
        audioSource.clip = gameOverClip;
        audioSource.Play();
    }
}
