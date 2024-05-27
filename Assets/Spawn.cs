using UnityEngine;
using UnityEngine.SceneManagement;

public class GnomeSpawner : MonoBehaviour
{
    public GameObject gnomePrefab;
    public int totalGnomesToSpawn = 30;
    public float spawnRadius = 10f;
    private int gnomesSpawned = 0;
    public int gnomesAtATime = 5;
    private int nextSceneToLoad;
    private float gnomeSpeed = 5f;
    private float speedIncreasePerScene = 1f;
    private void Start()
    {
        nextSceneToLoad = SceneManager.GetActiveScene().buildIndex + 1;
    }

    void Update()
    {
        if (GameObject.FindGameObjectsWithTag("Gnom").Length == 0)
        {
            SpawnGnomes();
        }
    }

    void SpawnGnomes()
    {
        if (gnomesSpawned >= totalGnomesToSpawn)
        {
            Destroy(gameObject);
            SceneManager.LoadScene(nextSceneToLoad);
            return;
        }

        for (int i = 0; i < gnomesAtATime; i++)
        {
            Vector3 spawnPos = transform.position + Random.insideUnitSphere * spawnRadius;
            spawnPos.y = 0;
            Instantiate(gnomePrefab, spawnPos, Quaternion.identity);

            gnomesSpawned++;
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
