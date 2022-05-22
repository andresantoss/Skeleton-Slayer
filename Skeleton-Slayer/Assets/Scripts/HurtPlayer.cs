using System.Collections;
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
  else if (other.gameObject.tag == "Player")
  {
   Vector3 hitDirection = other.transform.position - transform.position;
   hitDirection = hitDirection.normalized;

   FindObjectOfType<HealthManager>().HurtPlayer(damageToGive, hitDirection);
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
