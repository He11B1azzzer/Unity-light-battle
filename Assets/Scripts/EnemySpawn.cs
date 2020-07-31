using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
public class EnemySpawn : MonoBehaviour
{
    public GameObject player;
    public GameObject EnemySlow;
    public GameObject EnemyFast;
    public static Vector3 center;
    public static float spawnTimeSlow = 1.75f;
    public static float spawnTimeFast = 1f;
    private float radius = 5f;
    void Start()
    {
        center = player.transform.position;
        StartCoroutine(Spawn(EnemySlow, spawnTimeSlow));
        StartCoroutine(Spawn(EnemyFast, spawnTimeFast));
    }
    void Update()
    {
        center = player.transform.position;
    }
    Vector3 RandomCircle(Vector3 center)
    {
        float ang = Random.value * 360;
        Vector3 pos = new Vector3(center.x + radius * 4f * Mathf.Sin(ang * Mathf.Deg2Rad), center.y + radius * 2f * Mathf.Cos(ang * Mathf.Deg2Rad), 0);
        return pos;
    }
    IEnumerator Spawn(GameObject Enemy, float spawnTime)
    {
        while (true)
        {
            Instantiate(Enemy, RandomCircle(center), Quaternion.identity);
            yield return new WaitForSeconds(spawnTime);
        }
    }
}
