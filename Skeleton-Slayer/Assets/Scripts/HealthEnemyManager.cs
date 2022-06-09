using UnityEngine;
using System.Collections;

public class HealthEnemyManager : MonoBehaviour
{
    // Health System
    public int maxHealth;
    public int currentHealth;
    public Animator anim;
    public GameObject damageText;
    //public ParticleSystem hurtEffect;
    void Start()
    {
        currentHealth = maxHealth;
    }
    void Update()
    {

    }
    public void HurtEnemy(int damage)
    {
        //Instantiate(hurtEffect, gameObject.transform.position, Quaternion.identity);
        currentHealth -= damage;
        if (currentHealth <= 0)
        {
            //Debug.Log("Enemy Die");
            currentHealth = 0;
            anim.SetInteger("transition", 4);
        }
        else if (currentHealth > 0)
        {
            //Debug.Log("Hit Enemy");
            StartCoroutine(anim_hurt_enemy());
            DamageIndicator indicator = Instantiate(damageText, transform.position, Quaternion.identity).GetComponent<DamageIndicator>();
            indicator.SetDamageText(damage);
        }
    }
    public IEnumerator anim_hurt_enemy()
    {
        anim.SetInteger("hurt_enemy", 1); // muda pra animação do dano
        yield return new WaitForSeconds(1.033f); // espera a animação do dano acabar
        anim.SetInteger("hurt_enemy", 0); // tira da animação do dano
    }
}