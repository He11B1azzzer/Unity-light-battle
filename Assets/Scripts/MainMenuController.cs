using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class MainMenuController : MonoBehaviour
{
    public AudioSource mainMenuTheme;
    public GameObject mainMenuObject;
    public GameObject optionsObject;
    public GameObject quitObject;
    private GameObject previousObject;
    private GameObject previousObjectBefore;
    public Text helpFieldText;

    void Start()
    {
        if (SceneManager.GetActiveScene().name == "MainMenuScene")
        {
            mainMenuTheme.Play();
        }
        mainMenuObject.SetActive(true);
        helpFieldText.text = "";
    }
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (mainMenuObject.activeSelf)
            {
                mainMenuObject.SetActive(false);
                previousObject = mainMenuObject;
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

    public void Play()
    {
        SceneManager.LoadScene("GameScene");
    }

    public void Options()
    {
        mainMenuObject.SetActive(false);
        previousObject = mainMenuObject;
        optionsObject.SetActive(true);
        previousObjectBefore = optionsObject;
    }

    public void SoundOn()
    {
        PlayerPrefs.SetInt("SoundOn", 1);
        PlayerPrefs.SetInt("SoundOff", 0);
        helpFieldText.text = "SOUND IN GAME IS ENABLED";
    }

    public void SoundOff()
    {
        PlayerPrefs.SetInt("SoundOn", 0);
        PlayerPrefs.SetInt("SoundOff", 1);
        helpFieldText.text = "SOUND IN GAME IS DISABLED";
    }

    public void DisplayAsController()
    {
        PlayerPrefs.SetInt("DisplayController", 1);
        PlayerPrefs.SetInt("JoystickController", 0);
        helpFieldText.text = "DISPLAY IS DIVIDED BY TWO PARTS\nLEFT FOR MOVEMENT AND RIGHT FOR AIMING";
    }

    public void JoysticksAsController()
    {
        PlayerPrefs.SetInt("DisplayController", 0);
        PlayerPrefs.SetInt("JoystickController", 1);
        helpFieldText.text = "TWO VISIBLE JOYSTICKS\nLEFT FOR MOVEMENT AND RIGHT FOR AIMING";
        
    }
    public void Quit()
    {
        mainMenuObject.SetActive(false);
        previousObject = mainMenuObject;
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
        mainMenuObject.SetActive(true);
    }   
}