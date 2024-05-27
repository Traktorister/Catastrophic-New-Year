using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections.Generic;
using System.Collections;
using UnityEngine.UIElements.Experimental;

public class Infinite_Spawner : MonoBehaviour
{
    public GameObject gnomePrefab;
    public float spawnRadius = 10f;
    public int gnomesSpawned = 0;
    public int gnomesAtATime = 5;
    public float timer = 0;
    public int gnomesDeath = 0;
    public float timeSinceLastKill = 0;

    public float spawnDelay = 2.0f;
    public float nextSpawnTime = 20f;
    public int maxGnomes = 8;
    public float nextCheckTime = 5f;

    private void Start()
    {
        StartCoroutine(SpawnGnomes());
        gnomesDeath = GetComponent<Explode>().gnomeDeath;
        timeSinceLastKill = GetComponent<Explode>().timeSinceLastKill;
        nextCheckTime += Time.deltaTime;
    }


    private void Update()
    {
        timer += Time.deltaTime;

        if (timer >= nextSpawnTime)
        {
            StartCoroutine(SpawnGnomes());
            nextSpawnTime *= (4 / 5);
        }

        if (timer >= nextCheckTime)
        {
            if (GameObject.FindGameObjectsWithTag("Gnome").Length <= maxGnomes)
            {
                spawnDelay /= (4 / 5);
            }
            nextCheckTime = 0;
        }
    }

    private IEnumerator SpawnGnomes()
    {
        for (int i = 0; i < gnomesAtATime; i++)
        {
            Vector3 spawnPos = transform.position + Random.insideUnitSphere * spawnRadius;
            spawnPos.y = 0;
            Instantiate(gnomePrefab, spawnPos, Quaternion.identity);
            gnomesSpawned++;
            yield return new WaitForSeconds(spawnDelay);
        }
    }

    Vector3 GetRandomPosition()
    {
        Vector3 randomPosition;
        bool validPosition = false;

        do
        {
            randomPosition = new Vector3(Random.Range(-10f, 10f), 1f, Random.Range(-10f, 10f));
            validPosition = ValidatePosition(randomPosition);
        } while (!validPosition);

        return randomPosition;
    }

    bool ValidatePosition(Vector3 position)
    {
        foreach (GameObject gnome in GameObject.FindGameObjectsWithTag("Gnom"))
        {
            if (Vector3.Distance(gnome.transform.position, position) < 1f)
            {
                return false;
            }
        }
        return true;
    }
}
