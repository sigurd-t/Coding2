using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public AudioClip explodeClip;
    public GameObject particles;

    public void KillEnemy()
    {
        GetComponent<AudioSource>().PlayOneShot(explodeClip);
        GameObject particle = Instantiate(particles);
        particle.transform.position = transform.position;
        GetComponent<BoxCollider2D>().enabled = false;
        Destroy(gameObject, explodeClip.length + 0.5f);
    }
}