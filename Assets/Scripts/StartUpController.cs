using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
public class StartUpController : MonoBehaviour
{
    public AudioSource introSound;
    void Start()
    {
        introSound.Play();
        StartCoroutine(StartUpWaiting());
    }

    IEnumerator StartUpWaiting()
    {
        yield return new WaitForSeconds(4f);
        SceneManager.LoadScene("MainMenuScene");
    }
}
