using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mover : MonoBehaviour {

    private Rigidbody rb;
    public float speed;

    void Start() {
        rb = GetComponent<Rigidbody>();
        rb.velocity = transform.forward * speed;
	
    }
    void Update() {
        if (rb.gameObject.transform.position.z >= 20 || rb.gameObject.transform.position.z <=-5)
        {
            Destroy(rb.gameObject);
        }
    }
}
