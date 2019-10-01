using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WallShooter : MonoBehaviour
{
    public int health = 2;
    public float waitTime = 4f;
    public GameObject bulletSpawn;
    public GameObject Bullet;
    public Transform bulletSpawned;
    public GameObject child1;
    public GameObject child2;

    public AudioSource soundPlayer;
    public ParticleSystem deathEff;
    public Renderer rending;
    private bool partPlay = false;

    void Start()
    {
        deathEff = GetComponent<ParticleSystem>();
        rending = GetComponent<Renderer>();
        soundPlayer = GetComponent<AudioSource>();
    }


    void Update()
    {
        waitTime -= Time.deltaTime;

        if(waitTime <= 0)
        {
            Shoot();
            soundPlayer.Play();
            waitTime += Random.Range(1.5f, 3.5f);
        }

        if (health <= 0 && partPlay == false)
        {
            waitTime += 20;
            rending.enabled = false;
            child1.GetComponent<Renderer>().enabled = false;
            child2.GetComponent<Renderer>().enabled = false;
            deathEff.Play();
            partPlay = true;
            StartCoroutine("Death");
        }
    }

    IEnumerator Death()
    {
        yield return new WaitForSeconds(1f);
        Destroy(this.gameObject);
    }

    void Shoot()
    {
        bulletSpawned = Instantiate(Bullet.transform, bulletSpawn.transform.position, Quaternion.identity);
        bulletSpawned.rotation = bulletSpawn.transform.rotation;
    }
}
