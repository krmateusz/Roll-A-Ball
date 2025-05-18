using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    public Transform player;
    Vector3 offset;
    

    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
        offset = player.transform.position - transform.position;
    }

   
    void Update()
    {
        transform.position = player.transform.position - offset;
    }
}