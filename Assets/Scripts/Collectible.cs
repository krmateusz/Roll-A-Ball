using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using JetBrains.Annotations;
using static UnityEngine.ParticleSystem;

public class Collectible : MonoBehaviour
{

    private AudioSource audiosource;
    public ParticleSystem ps, destroyps;
    void Start()
    {
        audiosource = GameObject.Find("pickup").GetComponent<AudioSource>();
    }

    void Update()
    {
        transform.Rotate(100 * Time.deltaTime, 50 * Time.deltaTime, 150 * Time.deltaTime);
    }


    void OnTriggerEnter(Collider collision)
    {
       collision.gameObject.GetComponent<MovementController>().CollectScore();
       audiosource.Play();
       gameObject.SetActive(false);
       destroyparticle();
    }

    void destroyparticle()
    {
        destroyps.transform.parent = null;
        destroyps.Play();
    }

}
