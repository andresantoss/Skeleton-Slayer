using UnityEngine;

public class boss3 : MonoBehaviour
{
    public Animator boss3Anim;
    public Transform target;
    public float boss3Speed;
    bool enableAtc;
    int atkStep;
    public float lookRadius = 15f;
    public GameObject prefab;
    public GameObject fire;

    // door
    public GameObject door;

    public void Start()
    {
        Vector3 positionInitial = transform.position;
        boss3Anim = GetComponent<Animator>();
        enableAtc = true;

    }
    public void RotateBoss3()
    {
        Vector3 dir = target.position - transform.position;
        transform.localRotation =
            Quaternion.Slerp(transform.localRotation,
                Quaternion.LookRotation(dir), 5 * Time.deltaTime);
    }
    public void MoveBoss3()
    {
        float distance = Vector3.Distance(target.position, transform.position);
        if (distance <= lookRadius)
        {
            if ((target.position - transform.position).magnitude >= 2)
            {
                boss3Anim.SetInteger("transition", 2);
                transform.Translate(Vector3.forward * boss3Speed * Time.deltaTime, Space.Self);
            }
            if ((target.position - transform.position).magnitude < 2)
            {
                boss3Anim.SetInteger("transition", 1);
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
        if (boss3Anim.GetInteger("transition") != 4)
        {
            if (enableAtc)
            {
                RotateBoss3();
                MoveBoss3();
            }
        }
        else
        {
            door.SetActive(false);
        }
    }
    public void boss3Atk()
    {
        if ((target.position - transform.position).magnitude < 20)
        {
            switch (atkStep)
            {
                case 0:
                    atkStep += 1;
                    boss3Anim.Play("Boss3_AtkA");
                    Instantiate(prefab, transform.position, Quaternion.identity);
                    break;
                case 1:
                    atkStep += 1;
                    boss3Anim.Play("Boss3_AtkB");
                    break;
                case 2:
                    atkStep = 0;
                    boss3Anim.Play("Boss3_AtkC");
                    Instantiate(fire, transform.position, Quaternion.identity);
                    break;
            }
        }
    }
    public void FreezeBoss()
    {
        enableAtc = false;
    }
    public void UnFreezeBoss()
    {
        enableAtc = true;
    }

}
