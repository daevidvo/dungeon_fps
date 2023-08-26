using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBehavior : MonoBehaviour
{
    public int damagePerShot = 20;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("PlayerBullet"))
        {
            // Get the EnemyHealth script and deal damage to the enemy
            EnemyHealth enemyHealth = GetComponent<EnemyHealth>();
            if (enemyHealth != null)
            {
                enemyHealth.TakeDamage(damagePerShot);
            }

            // Destroy the bullet that hit the enemy
            Destroy(other.gameObject);
        }
    }
}
