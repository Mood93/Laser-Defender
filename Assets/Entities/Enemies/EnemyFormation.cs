using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyFormation : MonoBehaviour {

    public GameObject projectile;

    public float health = 150;
    public float projectileSpeed = -10f;
    public float shotsPerSeconds = 0.5f;
    public int scoreValue = 150;

    private ScoreKeeper scoreKeeper;

    void Start() {
        scoreKeeper = GameObject.Find("Score").GetComponent<ScoreKeeper>();
    }

    void Update() {

        float probability = Time.deltaTime * shotsPerSeconds;

        if (Random.value < probability) {
            Fire();
        }

    }

    void Fire() {
        Vector3 startPosition = transform.position + new Vector3(0f, -1f, 0f);
        GameObject missle = Instantiate(projectile, startPosition, Quaternion.identity) as GameObject;
        missle.GetComponent<Rigidbody2D>().velocity = new Vector2(0, projectileSpeed);
    }

    void OnTriggerEnter2D(Collider2D collider) {
        Projectile missle = collider.gameObject.GetComponent<Projectile>();

        if (missle) {
            health -= missle.GetDamage();
            missle.Hit();
            if (health <= 0) {
                Destroy(gameObject);
                scoreKeeper.Score(scoreValue);
            }
        }
    }
}
