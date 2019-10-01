using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Thwomp : MonoBehaviour
{
    public ParticleSystem deathEff;
    public Animator animate;
    public int health = 3;
    public Renderer rending;
    private bool partPlay = false;

    // Start is called before the first frame update
    void Start()
    {
        animate = GetComponent<Animator>();
        deathEff = GetComponent<ParticleSystem>();
        rending = GetComponent<Renderer>();
    }

    // Update is called once per frame
    void Update()
    {
        if(health <= 0 && partPlay == false)
        {
            rending.enabled = false;
            animate.enabled = false;
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
}
