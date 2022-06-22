using UnityEngine;

public class HealthEnemyManager : MonoBehaviour
{
    // Health System
    public int maxHealth;
    public int currentHealth;
    public Animator anim;
    public GameObject damageText;
    public GameObject prefab;
    public GameObject EnemeyObj;

    void Start()
    {
        currentHealth = maxHealth;
    }
    public void HurtEnemy(int damage)
    {
        currentHealth -= damage;
        if (currentHealth <= 0)
        {
            int probability = Random.Range(0, 101);
            bool dropOk = true;
            if (dropOk)
            {
                if (probability >= 50)
                {
                    dropOk = false;
                    Instantiate(prefab, transform.position, Quaternion.identity);
                }
            }
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