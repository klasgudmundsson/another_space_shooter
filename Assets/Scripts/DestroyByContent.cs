﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyByContent : MonoBehaviour {
    public GameObject explosion;
    public GameObject playerExplosion;

    void OnTriggerEnter(Collider other) {
        Instantiate(explosion,transform.position, transform.rotation);
        if(other.tag == "Player") {
            Instantiate(playerExplosion, other.transform.position, other.transform.rotation);
        }
        Destroy(gameObject);
        Destroy(other.gameObject);
    }
}
