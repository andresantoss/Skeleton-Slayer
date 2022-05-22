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
   bubble.SetActive(true);
   anim.SetInteger("hurt", 1);
   currentHealth -= damage;
   thePlayer.Knockback(direction);
   invicibilityCounter = invicibilityLength;
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
