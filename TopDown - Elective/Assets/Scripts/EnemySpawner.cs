using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public Enemy enemyPrefab;
    public float trajVariance = 15.0f;
    public float spawnRate = 1.0f;
    public float spawnDistance = 10.0f;
    public int spawnAmount = 1;
    private void Start()
    {
        InvokeRepeating(nameof(Spawn), spawnRate, spawnRate);
    }

    private void Spawn()
    {
        for (int i = 0; i <spawnAmount; i++)
        {
            Vector3 spawnDirection = Random.insideUnitCircle.normalized * spawnDistance;
            Vector3 spawnPoint = this.transform.position + spawnDirection;

            float variance = Random.Range(trajVariance, trajVariance); 
            Quaternion rotation =Quaternion.AngleAxis(variance, Vector3.forward);

            Enemy enemy = Instantiate(enemyPrefab, spawnPoint, rotation);
            Rigidbody2D enemyRB = enemy.GetComponent<Rigidbody2D>();

            Destroy(enemy, 30);
            Vector2 trajectory = rotation * -spawnDirection;
            enemy.SetTrajectory(trajectory);
        }
    }
}
