using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class GameController : MonoBehaviour
{
    public GameObject pauseObject;
    public GameObject gameIntObject;
    public GameObject quitObject;
    public static bool isPaused;
    void Start()
    {
        if (SceneManager.GetActiveScene().name == "GameScene")
        {
            gameIntObject.SetActive(true);
        }
        else
        {
            gameIntObject.SetActive(false);
        }
    }
    void Update()
    {
        Pause();
    }

    void Pause()
    {
        if (Input.GetKeyDown(KeyCode.Escape) && !isPaused)
        {
            Time.timeScale = 0;
            gameIntObject.SetActive(false);
            pauseObject.SetActive(true);
            isPaused = true;
        }
        else if (Input.GetKeyDown(KeyCode.Escape) && isPaused && !quitObject.activeSelf)
        {
            Time.timeScale = 1;
            pauseObject.SetActive(false);
            gameIntObject.SetActive(true);
            isPaused = false;
        }
        else if (Input.GetKeyDown(KeyCode.Escape) && isPaused && quitObject.activeSelf)
        {
            quitObject.SetActive(false);
            pauseObject.SetActive(true);
        }
    }
    public void Resume()
    {
        Time.timeScale = 1;
        pauseObject.SetActive(false);
        gameIntObject.SetActive(true);
        isPaused = false;
    }

    public void Menu()
    {
        Time.timeScale = 1;
        isPaused = false;
        SceneManager.LoadScene("MainMenuScene");
    }
    public void Quit()
    {
        pauseObject.SetActive(false);
        quitObject.SetActive(true);
    }

    public void Yes()
    {
        Application.Quit();
    }

    public void No()
    {
        quitObject.SetActive(false);
        pauseObject.SetActive(true);
    }
}
