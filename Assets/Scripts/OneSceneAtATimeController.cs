using UnityEngine;
using UnityEngine.SceneManagement;
public class OneSceneAtATimeController : MonoBehaviour
{
    void Start()
    {
        SceneManager.LoadScene("StartUpScene");
    }
}
