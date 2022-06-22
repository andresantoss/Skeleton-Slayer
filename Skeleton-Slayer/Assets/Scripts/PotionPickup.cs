using UnityEngine;

public class PotionPickup : MonoBehaviour
{
    public int value;
    public ParticleSystem pickupEffect;

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            FindObjectOfType<GameManager>().AddPotion(value);
            Instantiate(pickupEffect, transform.position, Quaternion.identity);
            Destroy(gameObject);
        }
    }
}
