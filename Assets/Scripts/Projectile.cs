using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    [SerializeField] private float speed;
    [SerializeField] private float lifeTime;
    private BoxCollider2D boxCollider2D;

    void Update()
    {

        transform.Translate(Vector2.right * speed * Time.deltaTime);

    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Enemy"))
        {
            boxCollider2D.enabled = false;
            Destroy(gameObject);
        }
    }

}
