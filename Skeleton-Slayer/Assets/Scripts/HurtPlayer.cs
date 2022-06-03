using UnityEngine;



public class HurtPlayer : MonoBehaviour
{
    public int damageToGive = 1;
    private Vector3 hitDirection;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            hitDirection = other.transform.position - transform.position;
            hitDirection = hitDirection.normalized;
            FindObjectOfType<HealthManager>().HurtPlayer(damageToGive, hitDirection);
        }
    }

}