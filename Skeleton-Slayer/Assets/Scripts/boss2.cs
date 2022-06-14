using UnityEngine;

public class boss2 : MonoBehaviour
{
    public Animator boss2Anim;
    public Transform target;
    public float boss1Speed;
    bool enableAtc;
    int atkStep;
    public float lookRadius = 15f;

    public void Start()
    {
        Vector3 positionInitial = transform.position;
        boss2Anim = GetComponent<Animator>();
        enableAtc = true;

    }
    public void RotateBoss2()
    {
        Vector3 dir = target.position - transform.position;
        transform.localRotation =
            Quaternion.Slerp(transform.localRotation,
                Quaternion.LookRotation(dir), 5 * Time.deltaTime);
    }
    public void MoveBoss2()
    {
        if (boss2Anim.GetInteger("transition") != 4)
        {
            float distance = Vector3.Distance(target.position, transform.position);
            if (distance <= lookRadius)
            {
                if ((target.position - transform.position).magnitude >= 2)
                {
                    boss2Anim.SetInteger("transition", 1);
                    transform.Translate(Vector3.forward * boss1Speed * Time.deltaTime, Space.Self);
                }
                if ((target.position - transform.position).magnitude < 2)
                {
                    boss2Anim.SetInteger("transition", 0);
                }
            }
        }
    }

    public void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, lookRadius);
    }

    public void Update()
    {

        if (enableAtc)
        {
            RotateBoss2();
            MoveBoss2();
        }
    }
    public void boss2Atk()
    {
        if ((target.position - transform.position).magnitude < 10)
        {
            switch (atkStep)
            {
                case 0:
                    atkStep += 1;
                    boss2Anim.Play("Boss2_AtkA");
                    break;
                case 1:
                    atkStep = 0;
                    boss2Anim.Play("Boss2_AtkB");
                    break;
            }
        }
    }
    public void FreezeBoss2()
    {
        enableAtc = false;
    }
    public void UnFreezeBoss2()
    {
        enableAtc = true;
    }
}
