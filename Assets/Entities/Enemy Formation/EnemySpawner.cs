using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour {

    public GameObject enemyPrefab;
    public float width = 10f;
    public float height = 5f;
    public float speed = 1f;

    private bool movingRight = false;
    private float xMin = -5;
    private float xMax = 5;

    // Use this for initialization
    void Start () {
        // Formation movement
        float distance = transform.position.z - Camera.main.transform.position.z;
        Vector3 leftmost = Camera.main.ViewportToWorldPoint(new Vector3(0, 0, distance));
        Vector3 rightmost = Camera.main.ViewportToWorldPoint(new Vector3(1, 0, distance));

        xMin = leftmost.x;
        xMax = rightmost.x;

        // Enemy spawning
        foreach (Transform child in transform) {
            GameObject enemy = Instantiate(enemyPrefab, child.transform.position, Quaternion.identity) as GameObject;
            enemy.transform.parent = child;
        }
	}

    public void OnDrawGizmos() {
        Gizmos.DrawWireCube(transform.position, new Vector3(width, height, 0));
    }
	
	// Update is called once per frame
	void Update () {
		if(movingRight) {
            transform.position += Vector3.left * speed * Time.deltaTime;
        } else {
            transform.position += Vector3.right * speed * Time.deltaTime;
        }

        float rightEdgeOfFormation = transform.position.x + (width / 2) - (float)0.25;
        float leftEdgeOfFormation = transform.position.x - (width / 2) + (float)0.25;
        if (leftEdgeOfFormation < xMin || rightEdgeOfFormation > xMax) {
            movingRight = !movingRight;
        }
    }
}
