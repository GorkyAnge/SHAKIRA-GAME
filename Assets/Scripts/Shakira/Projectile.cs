using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    [SerializeField] private float speed;
    [SerializeField] public float lifeTime;
    private BoxCollider2D boxCollider2D;

    void Start()
    {
        boxCollider2D = GetComponent<BoxCollider2D>();
        Destroy(gameObject, lifeTime);
    }

    void Update()
    {
        transform.Translate(Vector2.right * speed * Time.deltaTime);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Enemy"))
        {
            // Restar vida al enemigo
            other.GetComponent<Health>().TakeDamage(1);

            // Destruir el proyectil
            Destroy(gameObject);
        }
    }
}
