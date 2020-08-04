using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour
{
    public AudioSource background;
    public AudioSource enemyHit;
    public static float lowEdgeSpawnSlow = 1.5f;
    public static float highEdgeSpawnSlow = 2.5f;
    public static float lowEdgeSpawnFast = 0.5f;
    public static float highEdgeSpawnFast = 2f;
    private bool display;
    public GameObject gameIntObject;
    public Text pointsText;
    private int HitPoints = 3;
    public Image[] HPs;
    private int counter;
    public GameObject gameCanvasDisplay;
    public GameObject gameCanvasJoysticks;
    public Joystick joystickLeftDisplay;
    public Joystick joystickRightDisplay;
    public Joystick joystickLeft;
    public Joystick joystickRight;
    public Rigidbody2D rb;
    public static Vector3 angles;
    void Start()
    {
        if (SceneManager.GetActiveScene().name == "GameScene")
        {
            background.Play();
            lowEdgeSpawnSlow = 1.5f;
            highEdgeSpawnSlow = 2.5f;
            lowEdgeSpawnFast = 0.5f;
            highEdgeSpawnFast = 2f;
            EnemyMoving.points = 0;
            counter = 0;
            gameIntObject.SetActive(true);
            CheckSettings(PlayerPrefs.GetInt("DisplayController"), gameCanvasDisplay, gameCanvasJoysticks);
        }
        else
        {
            gameIntObject.SetActive(false);
            gameCanvasDisplay.SetActive(false);
            gameCanvasJoysticks.SetActive(false);
        }
    }
    void Update()
    {
        if (PlayerPrefs.GetInt("DisplayController") == 1)
        {
            Moving(joystickLeftDisplay, joystickRightDisplay);
        }
        else
        {
            Moving(joystickLeft, joystickRight);
        }
        pointsText.text = EnemyMoving.points.ToString();
        DisableJoysticks(PlayerPrefs.GetInt("DisplayController"), gameCanvasDisplay, gameCanvasJoysticks);
        if (HitPoints <= 0)
        {
            SceneManager.LoadScene("GameOverScene");
        }

    }

    void DisableJoysticks(int display, GameObject disp, GameObject joy)
    {
        if (GameController.isPaused)
        {
            if (display == 1)
            {
                disp.SetActive(false);
            }
            else
            {
                joy.SetActive(false);
            }
        }
        else
        {
            if (display == 1)
            {
                disp.SetActive(true);
            }
            else
            {
                joy.SetActive(true);
            }
        }
    }


    void CheckSettings(int display, GameObject disp, GameObject joy)
    {
        if (display == 1)
        {
            disp.SetActive(true);
            joy.SetActive(false);
        }
        else if (display == 0)
        {
            disp.SetActive(false);
            joy.SetActive(true);
        }
        else
        {
            PlayerPrefs.SetInt("DisplayController", 1);
            disp.SetActive(true);
            joy.SetActive(false);
        }
    }

    void Moving(Joystick left, Joystick right)
    {
        rb.transform.position = new Vector3(Mathf.Clamp(rb.transform.position.x, -8.5f, 8.5f),
                                                        Mathf.Clamp(transform.position.y, -4.5f, 4.5f), rb.transform.position.z);
        rb.velocity = new Vector2(left.Horizontal * 20f + Input.GetAxis("Horizontal") * 20f,
                                    left.Vertical * 20f + Input.GetAxis("Vertical") * 20f);
        angles = rb.transform.eulerAngles;
        if (right.Horizontal != 0 || Input.GetAxis("Joystick X") != 0)
        {
            Shoting.isActiveRight = true;
            rb.transform.eulerAngles = new Vector3(0, 0, Mathf.Atan2(right.Vertical + Input.GetAxis("Joystick Y"),
                                                right.Horizontal + Input.GetAxis("Joystick X")) * 180 / Mathf.PI);
        }
        else
        {
            Shoting.isActiveRight = false;
            rb.transform.eulerAngles = rb.transform.eulerAngles;
        }
    }

    void OnCollisionEnter2D(Collision2D coll)
    {
        enemyHit.Play();
        if (coll.gameObject.tag == "Enemy")
        {
            HPs[counter].enabled = false;
            counter += 1;
            HitPoints -= 1;
            Destroy(coll.gameObject);
        }
    }
}