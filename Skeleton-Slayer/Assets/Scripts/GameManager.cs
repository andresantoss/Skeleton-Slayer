using UnityEngine;
using TMPro;

public class GameManager : MonoBehaviour
{
    public int currentPotion;
    public TMP_Text potionText;
    public int currentHealth;
    public TMP_Text HealthText;
    public TMP_Text maxHealthText;
    public AudioSource audioSourcePickUp;

    public void AddPotion(int potionToAdd)
    {
        audioSourcePickUp.Play();
        currentPotion += potionToAdd;
        potionText.text = "" + currentPotion;
    }

    public void AddHealth(int Health, int maxHealth)
    {
        currentHealth = Health;
        HealthText.text = "" + currentHealth;
        maxHealthText.text = "  / " + maxHealth;
    }
}
