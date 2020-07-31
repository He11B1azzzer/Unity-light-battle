using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class GameOverController : MonoBehaviour
{
    public AudioSource gameOverTheme;
    public Text scoreText;
    public Text highScoreText;
    public GameObject gameOverObject;
    public GameObject quitObject;
    private GameObject previousObject;
    private GameObject previousObjectBefore;
    void Start()
    {
        if (SceneManager.GetActiveScene().name == "GameOverScene")
        {
            scoreText.text = EnemyMoving.points.ToString();
            if (EnemyMoving.points > PlayerPrefs.GetInt("HighScore"))
            {
                PlayerPrefs.SetInt("HighScore", EnemyMoving.points);
                highScoreText.text = EnemyMoving.points.ToString();
            }
            else
            {
                highScoreText.text = PlayerPrefs.GetInt("HighScore").ToString();
            }
            gameOverObject.SetActive(true);
            gameOverTheme.Play();
        }
    }
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (gameOverObject.activeSelf)
            {
                gameOverObject.SetActive(false);
                previousObject = gameOverObject;
                quitObject.SetActive(true);
                previousObjectBefore = quitObject;
            }
            else
            {
                previousObjectBefore.SetActive(false);
                previousObject.SetActive(true);
            }
        }
    }
    public void Retry()
    {
        SceneManager.LoadScene("GameScene");
    }
    public void Menu()
    {
        SceneManager.LoadScene("MainMenuScene");
    }
    public void Quit()
    {
        gameOverObject.SetActive(false);
        previousObject = gameOverObject;
        quitObject.SetActive(true);
        previousObjectBefore = quitObject;
    }

    public void Yes()
    {
        Application.Quit();
    }

    public void No()
    {
        quitObject.SetActive(false);
        gameOverObject.SetActive(true);
    }
}
