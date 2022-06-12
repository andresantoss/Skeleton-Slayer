using UnityEngine;


public class HurtPlayer : MonoBehaviour
{
    public int damageToGive = 1;
    private Vector3 hitDirection;
    public Animator playerAnim;

    void Start()
    {
    }
    void Update()
    {
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            playerAnim.Play("Impact");
            hitDirection = other.transform.position - transform.position;
            hitDirection = hitDirection.normalized;
            FindObjectOfType<HealthManager>().HurtPlayer(damageToGive, hitDirection);
            FindObjectOfType<Combo>().ResetCombo();
        }
    }
}