using UnityEngine;

public class HandCollision : MonoBehaviour
{
    [SerializeField] private float damage = 0f;

    public void SetDamage(float amount)
    {
        damage = amount;
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            // Apply damage to the player
            PlayerHealth playerHealth = other.GetComponent<PlayerHealth>();
            if (playerHealth != null)
            {
                playerHealth.TakeDamage(damage);
                Debug.Log("Hand Hit");

            }
        }
    }
}
