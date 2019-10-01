using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PlayerControl : MonoBehaviour
{
    public GameObject pistol;
    public AudioSource soundPlayer;
    public int health = 3;
    private bool invincible = false;

    public Image hearts3;
    public Image hearts2;
    public Image hearts1;

    Rigidbody body;

    float horizontal;
    float vertical;
    float moveLimiter = 0.7f;

    public float runSpeed = 5.0f;

    void Start()
    {
        body = GetComponent<Rigidbody>();
        soundPlayer = GetComponent<AudioSource>();
    }

    void Update()
    {
        horizontal = Input.GetAxisRaw("Horizontal"); // -1 is left
        vertical = Input.GetAxisRaw("Vertical"); // -1 is down

        if (Input.GetButtonDown("Fire3"))
        {
            runSpeed = 10.0f;
        }
        if (Input.GetButtonUp("Fire3"))
        {
            runSpeed = 5.0f;
        }

        if (health == 2)
        {
            hearts3.GetComponent<Image>().enabled = false;
            hearts2.GetComponent<Image>().enabled = true;
        }
        if (health == 1)
        {
            hearts2.GetComponent<Image>().enabled = false;
            hearts1.GetComponent<Image>().enabled = true;
        }
        if (health <= 0)
        {
            hearts1.GetComponent<Image>().enabled = false;
            SceneManager.LoadScene(0);
            Destroy(this.gameObject);
        }

    }

    void FixedUpdate()
    {
        if (horizontal != 0 && vertical != 0) // Check for diagonal movement
        {
            // limit movement speed diagonally, so you move at 70% speed
            horizontal *= moveLimiter;
            vertical *= moveLimiter;
        }

        body.velocity = new Vector2(horizontal * runSpeed, vertical * runSpeed);
    }

    public void OnTriggerEnter(Collider other)
    {
        if(other.tag == "PistolPickup")
        {
            soundPlayer.Play();
            pistol.GetComponent<PistolControl>().PickedUp();
            Destroy(other.gameObject);
        }
        if(other.tag == "FatalHazard")
        {
            health -= 3;
        }
        if (other.tag == "Hazard" && invincible == false)
        {
            health -= 1;
            invincible = true;
            StartCoroutine("DamageTake");
        }
    }

    IEnumerator DamageTake()
    {
        yield return new WaitForSeconds(1.5f);
        invincible = false;
    }
}
