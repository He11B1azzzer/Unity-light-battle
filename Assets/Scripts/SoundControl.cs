using UnityEngine;

public class SoundControl : MonoBehaviour
{
    void Update()
    {
        if (PlayerPrefs.GetInt("SoundOn") == 1)
        {
            AudioListener.pause = false;
        }
        else if (PlayerPrefs.GetInt("SoundOn") == 0)
        {
            AudioListener.pause = true;
        }
        else
        {
            AudioListener.pause = false;
        }
    }
}
