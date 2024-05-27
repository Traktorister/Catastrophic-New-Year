using System.Collections;
using System.Collections.Generic;
using System.Xml.Serialization;
using Unity.Properties;
using UnityEngine;
using UnityEngine.Rendering;

public class ActualInfinieSpawner : MonoBehaviour
{
    public GameObject gnomePrefab;
    public int sameRoundAmount = 30;
    public float spawnRadius = 10f;
    public int gnomesSpawned = 0;
    public int gnomesAtATime = 5;
    public float gnomeSpeed = 3f;
    public float speedIncreasePerScene = 1f;
    private int totalGnomes = 0;
    public float secondsBeforeGnomesSpawning = 5f;
    public float spawnDelay = 1f;
    private float timeSinceStart = 0f;
    public float multiTime = 0.8f;
    public int spawnCount = 0;
    public Stats GameOverScreen;
    public float time = 0;
    private int gnomDeath;
    public float gnomDecraseTime = 5f;

    private float timeSinceLastKill = 0f;
    private List<GameObject> spawnedGnomes = new List<GameObject>();

    private void Start()
    {
        StartCoroutine(SpawnGnomesEverySecond());
        gnomDeath = GetComponent<Explode>().gnomeDeath;
        time += Time.deltaTime;
    }

    private void Update()
    {
        gnomDeath = GetComponent<Explode>().gnomeDeath;
        time += Time.deltaTime;
    }

    private IEnumerator SpawnGnomesEverySecond()
    {
        while (true)
        {
            for (int i = 0; i < gnomesAtATime; i++)
            {
                Vector3 spawnPos = transform.position + Random.insideUnitSphere * spawnRadius;
                spawnPos.y = 0;
                Instantiate(gnomePrefab, spawnPos, Quaternion.identity);
                gnomesSpawned++;
            }
            spawnCount++;
            yield return new WaitForSeconds(spawnDelay);

            timeSinceStart += Time.deltaTime;

            if (spawnCount % 5 == 0)
            {
                spawnDelay *= multiTime;
            }

            if (spawnCount % 25 == 0)
            {
                spawnDelay /= (multiTime/2);
                gnomeSpeed *= 1.2f;
            }
        }
    }

    void SpawnGnomes()
    {
        if (gnomesSpawned >= sameRoundAmount * gnomesAtATime)
        {
            gnomesAtATime += 1;
            gnomesSpawned = 0;
        }

        if (gnomesSpawned >= gnomesAtATime)
        {
            gnomesSpawned = 0;
        }

        for (int i = 0; i < gnomesAtATime; i++)
        {
            Vector3 spawnPos = transform.position + Random.insideUnitSphere * spawnRadius;
            spawnPos.y = 0;
            Instantiate(gnomePrefab, spawnPos, Quaternion.identity);

            gnomesSpawned++;
            totalGnomes++;
        }

        if (gnomesSpawned - gnomDeath <= 5)
        {

        }

        gnomeSpeed += speedIncreasePerScene;
    }

    Vector3 GetRandomPosition()
    {
        Vector3 randomPosition;
        bool validPosition = false;

        do
        {
            randomPosition = new Vector3(Random.Range(-10f, 10f), 1f, Random.Range(-10f, 10f));
            validPosition = ValidatePosition(randomPosition);
        } while (validPosition);

        return randomPosition;
    }

    bool ValidatePosition(Vector3 position)
    {
        foreach (GameObject gnome in GameObject.FindGameObjectsWithTag("Gnom"))
        {
            if (Vector3.Distance(gnome.transform.position, position) <1f)
            {
                return false;
            }
        }

        return true;
    }
}
