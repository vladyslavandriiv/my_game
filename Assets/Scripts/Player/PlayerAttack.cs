using UnityEngine;

public class PlayerAttack : MonoBehaviour
{
    [SerializeField] private float attackCooldown;
    [SerializeField] private Transform firePoint;
    [SerializeField] private GameObject[] fireballs;
    [SerializeField] private AudioClip fireballSound;

    private Animator anim;
    private PlayerMovement playerMovement;
    private float cooldownTimer = Mathf.Infinity;

    private void Awake()
    {
        anim = GetComponent<Animator>();
        playerMovement = GetComponent<PlayerMovement>();
    }

    private void Update()
    {
        // Check for attack input
        if ((Input.GetMouseButton(0) || Input.GetKey(KeyCode.Return))
            && cooldownTimer > attackCooldown
            && playerMovement.canAttack()
            && Time.timeScale > 0)
        {
            Attack();
        }

        // Update cooldown timer
        cooldownTimer += Time.deltaTime;
    }

    private void Attack()
    {
        // Play sound and trigger animation
        SoundManager.instance.PlaySound(fireballSound);
        anim.SetTrigger("attack");
        cooldownTimer = 0;

        // Find an available fireball and set its position and direction
        int fireballIndex = FindFireball();
        fireballs[fireballIndex].transform.position = firePoint.position;
        fireballs[fireballIndex].GetComponent<Projectile>().SetDirection(Mathf.Sign(transform.localScale.x));
    }

    private int FindFireball()
    {
        // Return the index of the first inactive fireball
        for (int i = 0; i < fireballs.Length; i++)
        {
            if (!fireballs[i].activeInHierarchy)
                return i;
        }

        // If all fireballs are active, fallback to the first one
        Debug.LogWarning("No inactive fireballs found, reusing the first one.");
        return 0;
    }
}
