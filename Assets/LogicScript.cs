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
    [SerializeField] private AudioClip dingClip;
    private AudioSource audioSource;

    [ContextMenu("Increase Score")]

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

    public void gameOver()
    {
        gameOverScreen.SetActive(true);
    }
}
