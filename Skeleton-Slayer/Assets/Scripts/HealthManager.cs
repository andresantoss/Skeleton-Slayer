using UnityEngine;
using System.Collections;

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
    [SerializeField] private Transform Player;
    [SerializeField] private Transform respawnPoint;

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
        if (currentHealth <= 0)
        {
            StartCoroutine(respawn());
        }
    }
    public void HurtPlayer(int damage, Vector3 direction)
    {
        if (invicibilityCounter <= 0)
        {
            currentHealth -= damage;
            if (currentHealth <= 0)
            {
            }
            else
            {
                StartCoroutine(anim_hurt());
                thePlayer.Knockback(direction);
                invicibilityCounter = invicibilityLength;
                bubble.SetActive(true);
            }
        }
    }

    public IEnumerator anim_hurt()
    {

        anim.SetInteger("hurt", 1);
        yield return new WaitForSeconds(0.7f);
        anim.SetInteger("hurt", 0);
    }
    public IEnumerator respawn()
    {
        Player.transform.position = respawnPoint.transform.position;
        yield return new WaitForSeconds(2f);
        currentHealth = maxHealth;
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
