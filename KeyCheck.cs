using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeyCheck : MonoBehaviour
{
    public GameObject playerObj;
    public GameObject door;

    public void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Player")
        {
            playerObj = other.gameObject;
            if(playerObj.GetComponent<PlayerControl>().keys >= 1)
            {
                playerObj.GetComponent<PlayerControl>().keys -= 1;
                Destroy(door.gameObject);
            }
        }
    }
}
