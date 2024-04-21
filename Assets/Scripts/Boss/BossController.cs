using UnityEngine;

public class BossController : MonoBehaviour
{
    public GameObject handPrefab; // Prefab for the boss's summoned hand
    public GameObject projectilePrefab; // Prefab for the boss's ranged attack projectile
    public float rangedAttackCooldown = 5f; // Cooldown period between ranged attacks
    public float meleeAttackCooldown = 7f; // Cooldown period between melee attacks
    public float meleeAttackDuration = 2f; // Duration of the melee attack animation
    public float meleeAttackSpeed = 10f; // Speed of the melee attack projectiles
    public float meleeAttackDamage = 1f; // Damage inflicted by the melee attack
    public float handDamage = 1f; // Damage inflicted by the hand
    public float projectileDamage = 0f;
    public Transform meleeAttackSpawnPoint; // Point where melee attack projectiles spawn

    private Transform player; // Reference to the player's transform
    private Animator animator; // Reference to the boss's Animator component
    private bool isRangedAttacking = false; // Flag to track if the boss is currently performing a ranged attack
    private bool isMeleeAttacking = false; // Flag to track if the boss is currently performing a melee attack
    private float lastRangedAttackTime; // Time of the last ranged attack
    private float lastMeleeAttackTime; // Time of the last melee attack

    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
        animator = GetComponent<Animator>();
        lastRangedAttackTime = -rangedAttackCooldown; // Start with the boss ready to perform a ranged attack
        lastMeleeAttackTime = -meleeAttackCooldown; // Start with the boss ready to perform a melee attack
    }

    void Update()
    {
        // Check if it's time to perform a ranged attack
        if (!isRangedAttacking && Time.time - lastRangedAttackTime >= rangedAttackCooldown)
        {
            RangedAttack();
        }

        // Check if it's time to perform a melee attack
        if (!isMeleeAttacking && Time.time - lastMeleeAttackTime >= meleeAttackCooldown)
        {
            MeleeAttack();
        }
    }

    void RangedAttack()
    {
        // Set flag to indicate that the boss is performing a ranged attack
        isRangedAttacking = true;

        // Instantiate projectile at the player's position
        Vector2 targetPosition = player.position;
        GameObject projectile = Instantiate(projectilePrefab, targetPosition, Quaternion.identity);

        // Apply damage to player when projectile collides with them
        ProjectileCollision projectileCollision = projectile.GetComponent<ProjectileCollision>();
        projectileCollision.SetDamage(projectileDamage); // Adjust damage as needed
        Debug.Log("Projectile Hit");

        // Reset flag after a short delay
        Invoke("ResetRangedAttack", 1f);

        // Update last ranged attack time
        lastRangedAttackTime = Time.time;
    }

    void ResetRangedAttack()
    {
        // Reset flag after ranged attack
        isRangedAttacking = false;
    }

    void MeleeAttack()
    {
        // Set flag to indicate that the boss is performing a melee attack
        isMeleeAttacking = true;

        // Play melee attack animation
        animator.SetTrigger("Attack");

        // Instantiate projectile(s) for melee attack
        Invoke("SpawnMeleeProjectile", 0.5f);

        // Reset flag after melee attack duration
        Invoke("ResetMeleeAttack", meleeAttackDuration);

        // Update last melee attack time
        lastMeleeAttackTime = Time.time;
    }

    void SpawnMeleeProjectile()
    {
        // Instantiate melee attack projectile at spawn point
        GameObject projectile = Instantiate(projectilePrefab, meleeAttackSpawnPoint.position, Quaternion.identity);
        Rigidbody2D rb = projectile.GetComponent<Rigidbody2D>();

        // Apply damage to player when projectile collides with them
        ProjectileCollision projectileCollision = projectile.GetComponent<ProjectileCollision>();
        projectileCollision.SetDamage(meleeAttackDamage); // Adjust damage as needed

        // Calculate direction towards player and apply velocity
        Vector2 direction = (player.position - meleeAttackSpawnPoint.position).normalized;
        rb.velocity = direction * meleeAttackSpeed;
    }

    void ResetMeleeAttack()
    {
        // Reset flag after melee attack duration
        isMeleeAttacking = false;
    }

    // Method to be called from animation event for summoning hand
    public void SummonHand()
    {
        // Instantiate hand prefab at a specific position
        GameObject hand = Instantiate(handPrefab, player.position, Quaternion.identity);

        animator.SetTrigger("Cast");

        // Apply damage to player when hand collides with them
        HandCollision handCollision = hand.GetComponent<HandCollision>();
        handCollision.SetDamage(handDamage); // Adjust damage as needed
    }
}
