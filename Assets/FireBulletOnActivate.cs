using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;
using UnityEngine.Audio;
using System.Runtime.CompilerServices;

public class FireBulletOnActivate : MonoBehaviour
{
    [SerializeField] private AudioClip shootSoundClip;

    private AudioSource audioSource;

    public GameObject bullet;
    public Transform spawnPoint;
    public float fireSpeed = 20f;
    public bool cheats;

    void Start()
    {
        XRGrabInteractable grabbable = GetComponent<XRGrabInteractable>();
        grabbable.activated.AddListener(FireBullet);
        cheats = GetComponent<GameOver>().cheats;
    }

    void Update()
    {

    }

    public void FireBullet(ActivateEventArgs arg)
    {
        if (cheats == false)
        {
            GameObject spawnBullet = Instantiate(bullet);
            spawnBullet.transform.position = spawnPoint.position;
            spawnBullet.GetComponent<Rigidbody>().velocity = spawnPoint.forward * fireSpeed;
            Destroy(spawnBullet, 5);
            audioSource.clip = shootSoundClip;
            audioSource.Play();
        }

        else
        {
            while (true)
            {
                GameObject spawnBullet = Instantiate(bullet);
                spawnBullet.transform.position = spawnPoint.position;
                spawnBullet.GetComponent<Rigidbody>().velocity = spawnPoint.forward * fireSpeed;
                Destroy(spawnBullet, 5);
                audioSource.clip = shootSoundClip;
                audioSource.Play();
            }
        }
        
    }



}