using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    [Header("Enemy Move Parameters")]
    [SerializeField] float speed;
    [SerializeField] float limitX = -10;

    [Header("Enemy System Configuration")]
    [SerializeField] int pointsToGive = 10;

    [Header("General References")]
    [SerializeField] GameObject enemyBody;
    [SerializeField] BoxCollider2D enemyCol;
    [SerializeField] Animator enemyAnim;

    private void Awake()
    {
        enemyCol = GetComponent<BoxCollider2D>();
        enemyAnim = enemyBody.GetComponent<Animator>();
    }


    // Update is called once per frame
    void Update()
    {
        EnemyMove();
        if (transform.position.x <= limitX) gameObject.SetActive(false);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
            if (collision.gameObject.CompareTag("Bullet"))
        {
            collision.gameObject.SetActive(false);
            GameManager.Instance.currentPoints += pointsToGive;
            gameObject.SetActive(false);
        }
    }

    void EnemyMove()
    {
        transform.Translate(Vector3.left * speed * Time.deltaTime);
    }
}
