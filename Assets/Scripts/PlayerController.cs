using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {

    public float speed = 13.0f;
    public float padding = 0.1f;
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

        if (Input.GetKey("up"))
        {
            transform.position += Vector3.up * speed * Time.deltaTime;
        }

        if (Input.GetKey("down"))
        {
            transform.position += Vector3.down * speed * Time.deltaTime;
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
}
