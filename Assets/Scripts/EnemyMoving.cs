using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMoving : MonoBehaviour
{
    public AudioClip hit;
    private int pointsOnSlow = 10;
    private int pointsOnFast = 20;
    public GameObject Enemy;
    public Collider2D EnemyCollider;
    public static int points;
    void Update()
    {
        CheckPosition();
        EnemySpawn.spawnTimeSlow = Random.Range(PlayerController.lowEdgeSpawnSlow, PlayerController.highEdgeSpawnSlow);
        EnemySpawn.spawnTimeFast = Random.Range(PlayerController.lowEdgeSpawnFast, PlayerController.highEdgeSpawnFast);
        Moving();
    }
    void CheckPosition()
    {
        if (Enemy.transform.position.x < -10 || Enemy.transform.position.x > 10
            || Enemy.transform.position.y < -5 || Enemy.transform.position.y > 5)
        {
            EnemyCollider.isTrigger = true;
        }
        else
        {
            EnemyCollider.isTrigger = false;
        }
    }
    void OnCollisionEnter2D(Collision2D coll)
    {
        int prevCheck = EnemyMoving.points / 100;
        if (points / 100 > 1 && points > prevCheck)
        {
            PlayerController.lowEdgeSpawnSlow -= 0.01f;
            PlayerController.highEdgeSpawnSlow -= 0.01f;
            PlayerController.lowEdgeSpawnFast -= 0.01f;
            PlayerController.highEdgeSpawnFast -= 0.01f;
        }
        if (coll.gameObject.tag == "Bullet")
        {
            AudioSource.PlayClipAtPoint(hit, transform.position);
            Destroy(Enemy.gameObject);
        }

        if (gameObject.name == "EnemySlow(Clone)" && coll.gameObject.tag != "Player" && coll.gameObject.tag == "Bullet")
        {
            points += pointsOnSlow;
        }
        else if (gameObject.name == "EnemyFast(Clone)" && coll.gameObject.tag != "Player" && coll.gameObject.tag == "Bullet")
        {
            points += pointsOnFast;
        }
    }

    void Moving()
    {
        if (Enemy.gameObject.name == "EnemySlow(Clone)")
        {
            Enemy.transform.position = Vector3.MoveTowards(Enemy.transform.position, EnemySpawn.center, 5f * Time.deltaTime);
        }
        else
        {
            Enemy.transform.position = Vector3.MoveTowards(Enemy.transform.position, EnemySpawn.center, 10f * Time.deltaTime);
        }
        if (!GameController.isPaused)
        {
            Enemy.transform.Rotate(0, 0, 1);
        }
    }
}