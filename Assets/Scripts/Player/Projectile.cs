using UnityEngine;

public class Projectile : MonoBehaviour
{
    [SerializeField] private float speed;
    private float direction;
    private bool hit;
    private float lifetime;

    private Animator anim;
    private BoxCollider2D boxCollider;

    private void Awake()
    {
        anim = GetComponent<Animator>();
        boxCollider = GetComponent<BoxCollider2D>();
    }

    private void Update()
    {
        if (hit) return;

        // Move the projectile in the direction
        float movementSpeed = speed * Time.deltaTime * direction;
        transform.Translate(movementSpeed, 0, 0);

        // Deactivate after 5 seconds
        lifetime += Time.deltaTime;
        if (lifetime > 5)
            gameObject.SetActive(false);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        hit = true;
        boxCollider.enabled = false;
        anim.SetTrigger("explode");

        // Deal damage to enemies
        if (collision.CompareTag("Enemy"))
            collision.GetComponent<Health>()?.TakeDamage(1);
    }

    public void SetDirection(float _direction)
    {
        lifetime = 0;
        direction = _direction;
        gameObject.SetActive(true);
        hit = false;
        boxCollider.enabled = true;

        // Flip the projectile's scale based on direction
        Vector3 scale = transform.localScale;
        scale.x = Mathf.Abs(scale.x) * _direction; // Ensure correct flipping
        transform.localScale = scale;
    }

    private void Deactivate()
    {
        gameObject.SetActive(false);
    }
}
