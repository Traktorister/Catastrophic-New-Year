using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOver : MonoBehaviour
{
    [SerializeField] private float _maxHealth = 100;
    [SerializeField] private AudioClip damageSoundClip;
    private AudioSource audioSource;
    public GameObject sound;
    public GameObject coin;
    private float _currentHealth;
    private string currentSceneName;
    private int gnomes = 0;
    private float time = 0;
    public bool cheats;
    public int gnomdeath;

    [SerializeField] private Healthbar _healthbar;
    private void Start()
    {
        audioSource = GetComponent<AudioSource>();
        _currentHealth = _maxHealth;

        _healthbar.UpdateHealthBar(_maxHealth, _currentHealth);

        currentSceneName = SceneManager.GetActiveScene().name;

        gnomdeath = GetComponent<Explode>().gnomeDeath;
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.tag == "Gnom")
        {
            _currentHealth -= 10;
            _healthbar.UpdateHealthBar(_maxHealth, _currentHealth);
            GameObject spawnSound = Instantiate(sound);
        }    

        if (collision.collider.tag == "Coin")
        {
            GameObject sS = Instantiate(coin);
            Destroy(collision.collider.gameObject);
            cheats = true;
        }

        if (_currentHealth > 100)
        {
            _currentHealth = 100;
            _healthbar.UpdateHealthBar(_maxHealth, _currentHealth);
        }
        if (collision.collider.tag == "Bullet")
        {
            SceneManager.LoadScene("Main Menu");
        }
        if (_currentHealth <= 0)
        {
            if(currentSceneName == "Infinite Gamemode" || currentSceneName == "CP Death")
            {
                SceneManager.LoadScene("Game Over Goddammit");
            }
            else
            {
                SceneManager.LoadScene(currentSceneName);
            }
        }
    }

    void Update()
    {
        gnomdeath += GetComponent<Explode>().gnomeDeath;
    }
}
