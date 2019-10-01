using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PistolControl : MonoBehaviour
{
    public GameObject bulletSpawn;
    public GameObject Bullet;
    public GameObject pistolObj;
    public Transform bulletSpawned;
    public Renderer rend;
    private bool hasGun = false;
    public AudioSource soundPlayer;
    public float waitTime = 0.5f;

    // Start is called before the first frame update
    void Start()
    {
        rend = GetComponent<Renderer>();
        rend.enabled = false;
        soundPlayer = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {

        waitTime -= Time.deltaTime;

        if (Input.GetButtonDown("Fire1") && hasGun == true && waitTime <= 0)
        {
            Shoot();
            soundPlayer.Play();
            waitTime = 0.5f;
        }
    }

    public void PickedUp()
    {
        rend.enabled = true;
        hasGun = true;
    }

    void Shoot()
    {
        bulletSpawned = Instantiate(Bullet.transform, bulletSpawn.transform.position, Quaternion.identity);
        bulletSpawned.rotation = bulletSpawn.transform.rotation;
    }
}
