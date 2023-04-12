using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public TextMeshProUGUI gameOverText;
    public bool isGameActive;
    public Button restartButton;
    public GameObject titleScreen;
    public List<GameObject> targets;
    private float spawnRate = 1.0f;

    public TextMeshProUGUI scoreText;
    private int score = 0;

    public TextMeshProUGUI livesText;
    private int lives = 3;

    public GameObject pauseScreen;
    private bool paused;

    // Start is called before the first frame update
    void Start()
    {

    }

    void ChangePaused()
    {
        if (!paused)
        {
            paused = true;
            isGameActive = false;
            pauseScreen.SetActive(true);
            Time.timeScale = 0;
        }
        else
        {
            paused = false;
            isGameActive = true;
            pauseScreen.SetActive(false);
            Time.timeScale = 1;
        }
    }

    public void StartGame(int difficulty)
    {
        spawnRate /= difficulty;
        livesText.text = "Lives: " + lives;
        titleScreen.SetActive(false);
        isGameActive = true;
        StartCoroutine(SpawnTarget());
        UpdateScore(0);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.P))
        {
            ChangePaused();
        }
    }

    IEnumerator SpawnTarget()
    {
        while (isGameActive)
        {
            yield return new WaitForSeconds(spawnRate);

            Instantiate(targets[Random.Range(0, targets.Count)]);
        }
    }

    public void UpdateScore(int scoreToAdd)
    {
        score += scoreToAdd;
        scoreText.text = "Score: " + score;
    }

    public void LoseLife()
    {
        if (isGameActive)
        {
            lives--;
            livesText.text = "Lives: " + lives;

            if (lives <= 0)
            {
                GameOver();
            }
        }
    }

    public void GameOver()
    {
        gameOverText.gameObject.SetActive(true);
        isGameActive = false;
        restartButton.gameObject.SetActive(true);
    }

    public void RestartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
