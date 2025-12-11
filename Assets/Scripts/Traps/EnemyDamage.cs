using UnityEngine;

public class EnemyDamage : MonoBehaviour
{
    [SerializeField] protected float damage;

    protected void OnTriggerEnter2D(Collider2D collision)
    {
        // If the object is the player
        if (collision.tag == "Player")

            // Apply damage to the player's health (if they have a Health component)
            collision.GetComponent<Health>()?.TakeDamage(damage);
    }
}