using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shoting : MonoBehaviour
{
    public AudioSource shoot;
    public static bool isActiveRight;
    public GameObject bullet;
    public GameObject player;
    void Start()
    {
        StartCoroutine(shoting());
    }
    IEnumerator shoting()
    {
        while (true)
        {
            if (isActiveRight)
            {
                shoot.Play();
                Instantiate(bullet, new Vector2(player.transform.position.x, player.transform.position.y), Quaternion.identity);
            }
            yield return new WaitForSeconds(0.2f);
        }
    }
}
