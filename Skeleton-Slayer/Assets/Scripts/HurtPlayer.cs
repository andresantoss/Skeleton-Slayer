using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HurtPlayer : MonoBehaviour
{
    public int damageToGive = 1;
    public Animator anim;
    public float CooldownDuration = 1f;
    public bool IsAvailable = true;

    // Start is called before the first frame update
    void Start()
    {
    
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (IsAvailable == false)
        {
            return;
        }
        else if(other.gameObject.tag == "Player")
        {
            FindObjectOfType<HealthManager>().HurtPlayer(damageToGive);
            anim.SetInteger("hurt", 1);
            StartCoroutine(StartCooldown());
        }
    }
    public IEnumerator StartCooldown()
    {
        IsAvailable = false;
        yield return new WaitForSeconds(CooldownDuration);
        anim.SetInteger("hurt", 0);
        IsAvailable = true;
    }
}
