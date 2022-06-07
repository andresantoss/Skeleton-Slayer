using UnityEngine;

public class HealthEnemyManager : MonoBehaviour
{
    // Health System
    public int maxHealth;
    public int currentHealth;
    public Animator anim;
    //public ParticleSystem hurtEffect;
    void Start()
    {
        currentHealth = maxHealth;
        //FindObjectOfType<GameManager>().(, );
    }
    // Update is called once per frame
    void Update()
    {

    }
    public void HurtEnemy(int damage)
    {
        //Instantiate(hurtEffect, gameObject.transform.position, Quaternion.identity);
        currentHealth -= damage;
        if (currentHealth <= 0)
        {
            currentHealth = 0;
            Debug.Log("Enemy Die");
            //anim.SetInteger("transition", x);
        }
        else if (currentHealth > 0)
        {
            Debug.Log("Hit Enemy");
            //anim.SetInteger("transition", x);
        }
    }
    public void HealPlayer(int healAmount)
    {
        currentHealth += healAmount;
        if (currentHealth > maxHealth)
        {
            currentHealth = maxHealth;
        }
    }
}