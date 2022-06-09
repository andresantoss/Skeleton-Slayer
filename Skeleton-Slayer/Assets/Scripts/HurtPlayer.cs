using UnityEngine;
using System.Collections;


public class HurtPlayer : MonoBehaviour
{
    public int damageToGive = 1;
    private Vector3 hitDirection;
    public Animator anim;

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
            StartCoroutine(anim_hurt());
            hitDirection = other.transform.position - transform.position;
            hitDirection = hitDirection.normalized;
            FindObjectOfType<HealthManager>().HurtPlayer(damageToGive, hitDirection);
            FindObjectOfType<Combo>().ResetCombo();
        }
    }
    public IEnumerator anim_hurt()
    {
        anim.SetInteger("hurt", 1); // muda pra animação do dano
        yield return new WaitForSeconds(0.7f); // espera a animação do dano acabar
        anim.SetInteger("hurt", 0); // tira da animação do dano
    }
}