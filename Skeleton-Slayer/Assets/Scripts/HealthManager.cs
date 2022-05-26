using UnityEngine;

public class HealthManager : MonoBehaviour
{

    MeshRenderer meshRenderer;
    Color origColor;
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
    // respawn
    public bool isRespawning;
    //public Transform respawnPoint;

    // Start is called before the first frame update
    void Start()
    {
        currentHealth = maxHealth;
        thePlayer = FindObjectOfType<PlayerController>();
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

    }
    public void HurtPlayer(int damage, Vector3 direction)
    {
        if (invicibilityCounter <= 0)
        {
            currentHealth -= damage;
            if (currentHealth <= 0)
            {
                Debug.Log("morto");
                anim.SetInteger("transition", 4);
                currentHealth = maxHealth;
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

    /*     private void OnTriggerEnter(Collider other)
        {
            if (currentHealth <= 0)
            {
                if (other.gameObject.tag == "Player")
                {
                    Debug.Log("Recuperando Vida");
                    anim.SetInteger("transition", 0);
                    currentHealth = maxHealth;

                }
            }

        } */
}