using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float speed;
    public float lifetime;
    public int damage;

    private GameObject triggerEnemy;

    void Update()
    {
        transform.Translate(Vector2.up * Time.deltaTime * speed);

        lifetime -= 1 * Time.deltaTime;

        if (lifetime <= 0)
        {
            Destroy(this.gameObject);
        }
    }

    public void OnCollisionEnter(Collision collision)
    {
        if(collision.collider.tag == "Wall")
        {
            Destroy(this.gameObject);
        }
    }

    public void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Hazard")
        {
            Debug.Log("Enemy Hit");
            triggerEnemy = other.gameObject;
            triggerEnemy.GetComponent<Thwomp>().health -= damage;
            Destroy(this.gameObject);
        }
    }
}
