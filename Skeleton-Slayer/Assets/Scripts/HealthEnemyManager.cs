using UnityEngine;

public class HealthEnemyManager : MonoBehaviour
{
    // Health System
    public int maxHealth;
    public int currentHealth;
    public Animator anim;
    public GameObject damageText;
    void Start()
    {
        currentHealth = maxHealth;
    }
    public void HurtEnemy(int damage)
    {
        currentHealth -= damage;
        if (currentHealth <= 0)
        {
            anim.SetInteger("transition", 4);
            currentHealth = 0;
        }
        else if (currentHealth > 0)
        {
            DamageIndicator indicator = Instantiate(damageText, transform.position, Quaternion.identity).GetComponent<DamageIndicator>();
            indicator.SetDamageText(damage);
        }
    }
}