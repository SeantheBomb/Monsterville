using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoserTreasureChest : MonoBehaviour
{

    public GameObject[] enemies;
    public int spawnCount = 10;
    public float spawnDelay = 1f;
    public float range = 5f;

    bool triggered = false;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (triggered) return;

        if (collision.CompareTag("Player") == false) return;

        StartCoroutine(SpawnEnemies());
    }


    IEnumerator SpawnEnemies()
    {
        triggered = true;

        for (int i = 0; i < spawnCount; i++)
        {
            yield return new WaitForSeconds(spawnDelay);
            GameObject go = enemies[Random.Range(0, enemies.Length)];
            Vector2 pos = (Vector2)transform.position + (Random.insideUnitCircle * range);
            Instantiate(go, pos, Quaternion.identity);
        }
    }
}
