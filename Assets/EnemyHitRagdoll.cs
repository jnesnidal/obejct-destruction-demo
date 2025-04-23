using UnityEngine;

public class EnemyHitRagdoll : MonoBehaviour
{
    public GameObject animatedEnemy; // The normal animated enemy
    public GameObject ragdollEnemy;  // The ragdoll version

    private bool isDead = false;

    private void Start()
    {
        // Make sure only the animated version is active at start
        animatedEnemy.SetActive(true);
        ragdollEnemy.SetActive(false);
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (isDead) return;

        if (collision.gameObject.CompareTag("Bullet"))
        {
            // Switch to ragdoll
            animatedEnemy.SetActive(false);
            ragdollEnemy.SetActive(true);

            isDead = true;
        }
    }
}