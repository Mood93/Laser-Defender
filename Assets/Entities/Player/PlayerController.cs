using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {

    public float speed = 13.0f;
    public GameObject projectile;
    public float projectileSpeed;
    public float firingRate;
    float padding = 0.5f;
    float xMin = -5;
    float xMax = 5;

    void Start() {
        float distance = transform.position.z - Camera.main.transform.position.z;
        Vector3 leftmost = Camera.main.ViewportToWorldPoint(new Vector3(0,0,distance));
        Vector3 rightmost = Camera.main.ViewportToWorldPoint(new Vector3(1, 0, distance));
        xMin = leftmost.x + padding;
        xMax = rightmost.x - padding;
    }

    // Update is called once per frame
    void Update()
    {
        Movement();

        // Projectiles
        if (Input.GetKeyDown(KeyCode.Space) && !IsInvoking("Fire")) {
            InvokeRepeating("Fire", 0.00001f, firingRate);
        }

        if (Input.GetKeyUp(KeyCode.Space)) {
            CancelInvoke("Fire");
        }



    }

    void Movement() {
        if (Input.GetKey("up"))
        {
            //transform.position += Vector3.up * speed * Time.deltaTime;
        }

        if (Input.GetKey("down"))
        {
            //transform.position += Vector3.down * speed * Time.deltaTime;
        }

        if (Input.GetKey("left"))
        {
            transform.position += Vector3.left * speed * Time.deltaTime;
        }

        if (Input.GetKey("right"))
        {
            transform.position += Vector3.right * speed * Time.deltaTime;
        }

        float newX = Mathf.Clamp(transform.position.x, xMin, xMax);

        transform.position = new Vector3(newX, transform.position.y, transform.position.z);
    }

    void Fire () {
        GameObject beam = Instantiate(projectile, transform.position, Quaternion.identity);
        beam.GetComponent<Rigidbody2D>().velocity = new Vector3(0, projectileSpeed);
    }

}
