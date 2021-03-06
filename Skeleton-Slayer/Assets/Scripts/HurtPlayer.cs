using UnityEngine;


public class HurtPlayer : MonoBehaviour
{
    public int damageToGive = 1;
    private Vector3 hitDirection;
    public Animator playerAnim;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            if (playerAnim.GetInteger("transition") != 4)
            {
                playerAnim.Play("Impact");
                hitDirection = other.transform.position - transform.position;
                hitDirection = hitDirection.normalized;
                FindObjectOfType<HealthManager>().HurtPlayer(damageToGive, hitDirection);
                FindObjectOfType<Combo>().ResetCombo();
            }
        }
    }
}