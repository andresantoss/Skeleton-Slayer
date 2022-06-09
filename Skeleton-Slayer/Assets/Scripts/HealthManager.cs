using UnityEngine;

public class HealthManager : MonoBehaviour
{
    // Health System
    public int maxHealth;
    public int currentHealth;
    public PlayerController thePlayer;
    public Animator anim;
    // invicibility
    public float invicibilityLength;
    private float invicibilityCounter;
    // invicibility effect


    public GameObject bubble;
    public ParticleSystem hurtEffect;

    // Start is called before the first frame update
    void Start()
    {
        currentHealth = maxHealth;
        thePlayer = FindObjectOfType<PlayerController>();
        FindObjectOfType<GameManager>().AddHealth(currentHealth, maxHealth);
    }
    // Update is called once per frame
    void Update()
    {
        if (invicibilityCounter > 0)
        {
            invicibilityCounter -= Time.deltaTime;
        }
        else
        {
            bubble.SetActive(false);
        }
        if (currentHealth > 0)
        {
            FindObjectOfType<GameManager>().AddHealth(currentHealth, maxHealth);
        }
        else
        {
            FindObjectOfType<GameManager>().AddHealth(0, maxHealth);
        }


    }
    public void HurtPlayer(int damage, Vector3 direction)
    {
        if (invicibilityCounter <= 0)
        {

            Instantiate(hurtEffect, thePlayer.transform.position, Quaternion.identity);
            currentHealth -= damage;

            if (currentHealth <= 0)
            {
                FindObjectOfType<GameManager>().AddHealth(0, maxHealth);
                anim.SetInteger("transition", 4);
            }

            else if (currentHealth > 0)
            {
                thePlayer.Knockback(direction);
                invicibilityCounter = invicibilityLength;
                bubble.SetActive(true);
            }

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