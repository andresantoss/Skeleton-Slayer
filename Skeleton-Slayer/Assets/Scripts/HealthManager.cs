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
    }
    public void HurtPlayer(int damage, Vector3 direction)
    {
        if (invicibilityCounter <= 0)
        {
            currentHealth -= damage;
            StartCoroutine(anim_hurt());
            if (currentHealth <= 0)
            {
                StartCoroutine(anim_death());
                StartCoroutine(respawn());
            }
            else
            {
                thePlayer.Knockback(direction);
                invicibilityCounter = invicibilityLength;
                bubble.SetActive(true);
            }
        }
    }

    public IEnumerator anim_hurt()
    {

        anim.SetInteger("transition", 3);
        yield return new WaitForSeconds(0.7f);
        anim.SetInteger("transition", 0);
    }

    public IEnumerator anim_death()
    {
        anim.SetInteger("transition", 4);
        yield return new WaitForSeconds(3.9f);
        anim.SetInteger("transition", 0);
    }

    public IEnumerator respawn()
    {
        Debug.Log("respawn");
        Player.transform.position = respawnPoint.transform.position;
        yield return new WaitForSeconds(10f);
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