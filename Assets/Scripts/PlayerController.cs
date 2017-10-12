using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Boundary {
    public float xMin, xMax, zMin, zMax;

}

public class PlayerController : MonoBehaviour {
    public Rigidbody rb;
    public float speed;
    public Boundary boundary;
    public float tilt;

    public GameObject shot;
    private GameObject shot2;
    public Transform shotSpawn;
    public float fireRate;
    private float nextFire;


    void Start() {
        rb = GetComponent<Rigidbody>();
        nextFire = 0;
        shot2 = shot;
    }
    void Update() {
       if (Input.GetButton("Fire1") && Time.time > nextFire) {
            shot = Instantiate(shot2) as GameObject;
            shot.transform.position = shotSpawn.transform.position;
            nextFire = fireRate + Time.time;
            GetComponent<AudioSource>().Play();
        }
    }
    void FixedUpdate() {
        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");

        Vector3 movement = new Vector3(moveHorizontal, 0.0f, moveVertical);
        rb.velocity = movement*speed;

        rb.position = new Vector3
        (
            Mathf.Clamp(rb.position.x, boundary.xMin, boundary.xMax),
            0.0f,
            Mathf.Clamp(rb.position.z, boundary.zMin, boundary.zMax)
        );

        rb.rotation = Quaternion.Euler
        (
            rb.velocity.z * 0.3f*tilt,
            0.0f,
            rb.velocity.x * -tilt
        );
    }

}
 