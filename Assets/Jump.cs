using UnityEngine;
using static UnityEngine.GraphicsBuffer;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using System.Diagnostics;

public class GnomeFollow : MonoBehaviour
{
    public float followSpeed = 5f;
    private GameObject player;
    private string currentSceneName;
    public bool hardcore;
    public float hardcoreSpeed = 10f;
    public float time;

    private void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        currentSceneName = SceneManager.GetActiveScene().name;
    }

    private void Update()
    {
        if (player != null)
        {
            Vector3 direction = (player.transform.position - transform.position).normalized;
            Quaternion lookRotation = Quaternion.LookRotation(direction);
            transform.rotation = Quaternion.Slerp(transform.rotation, lookRotation, Time.deltaTime * followSpeed);
            transform.position = Vector3.MoveTowards(transform.position, player.transform.position, followSpeed * Time.deltaTime);
        }

        if (currentSceneName == "Actual Infinite Gamemode")
        {
            if (hardcore == false)
            {
                followSpeed = GetComponent<ActualInfinieSpawner>().gnomeSpeed;
            }
            else
            {
                followSpeed *= 1.2f;
            }

        if (currentSceneName == "CP Death")
            {
                if (hardcore == false)
                {
                    followSpeed = 5;
                }
                else
                {
                    followSpeed *= 1.2f;
                }
            }
        }
  
        if (currentSceneName == "LVL1")
        {
            followSpeed = 3;
        }

        if (currentSceneName == "LVL2")
        {
            followSpeed = 3.3f;
        }

        if (currentSceneName == "LVL3")
        {
            followSpeed = 3.6f;
        }

        if (currentSceneName == "LVL4")
        {
            followSpeed = 4f;
        }

        if (currentSceneName == "LVL5")
        {
            followSpeed = 4.3f;
        }

        if (currentSceneName == "LVL6")
        {
            followSpeed = 4.6f;
        }

        if (currentSceneName == "LVL7")
        {
            followSpeed = 5f;
        }

        if (currentSceneName == "LVL8")
        {
            followSpeed = 6f;
        }

        if (currentSceneName == "LVL9")
        {
            followSpeed = 7f;
        }

        if (currentSceneName == "LVL10")
        {
            followSpeed = 8f;
        }
    }
}
