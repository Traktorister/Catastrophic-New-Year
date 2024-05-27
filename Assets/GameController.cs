using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{
    public Stats GameOverScreen;
    int maxGnoms = 0;
    public int gnomesSpawned = 0;
    public float time = 0;

    private void Update()
    {
        time = GetComponent<Stopwatch>().currentTime;
        gnomesSpawned = GetComponent<Infinite_Spawner>().gnomesSpawned;
    }

    public void GameOver()
    {   
        GameOverScreen.Gnoms(gnomesSpawned);
    }
}
