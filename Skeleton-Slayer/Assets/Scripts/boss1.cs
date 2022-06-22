using UnityEngine;

public class boss1 : MonoBehaviour
{
    public Animator boss1Anim;
    public Transform target;
    public float boss1Speed;
    bool enableAtc;
    bool combate;
    int atkStep;
    public float lookRadius = 15f;
    public ParticleSystem AtkCEffect;
    // sound step
    int stepNumber;
    public AudioSource stepSoundSkeleton1;
    public AudioSource stepSoundSkeleton2;
    public AudioSource stepSoundSkeleton3;
    public AudioSource stepSoundSkeleton4;

    // door
    public GameObject door;

    public void Start()
    {
        Vector3 positionInitial = transform.position;
        boss1Anim = GetComponent<Animator>();
        enableAtc = true;
    }
    public void RotateBoss1()
    {
        Vector3 dir = target.position - transform.position;
        transform.localRotation =
            Quaternion.Slerp(transform.localRotation,
                Quaternion.LookRotation(dir), 5 * Time.deltaTime);
    }
    public void MoveBoss1()
    {
        float distance = Vector3.Distance(target.position, transform.position);
        if (distance <= lookRadius)
        {
            if ((target.position - transform.position).magnitude >= 2)
            {
                boss1Anim.SetInteger("transition", 2);
                transform.Translate(Vector3.forward * boss1Speed * Time.deltaTime, Space.Self);
            }
            if ((target.position - transform.position).magnitude < 2)
            {
                boss1Anim.SetInteger("transition", 0);
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
        if (boss1Anim.GetInteger("transition") != 4)
        {
            if (enableAtc)
            {
                RotateBoss1();
                MoveBoss1();
            }
        }
        else
        {
            door.SetActive(false);
        }
    }
    public void boss1Atk()
    {
        if ((target.position - transform.position).magnitude < 10)
        {
            switch (atkStep)
            {
                case 0:
                    atkStep += 1;
                    boss1Anim.Play("Boss1_AtkA");
                    break;
                case 1:
                    atkStep += 1;
                    boss1Anim.Play("Boss1_AtkB");
                    break;
                case 2:
                    atkStep = 0;
                    boss1Anim.Play("Boss1_AtkC");
                    break;
            }
        }
    }
    public void EffectAtkC()
    {
        Instantiate(AtkCEffect, transform.position, Quaternion.identity);
    }
    public void FreezeBoss1()
    {
        enableAtc = false;
    }
    public void UnFreezeBoss1()
    {
        enableAtc = true;
    }

    public void stepSoundSkeleton()
    {
        switch (stepNumber)
        {
            case 0:
                stepNumber += 1;
                stepSoundSkeleton1.Play();
                break;
            case 1:
                stepNumber += 1;
                stepSoundSkeleton2.Play();
                break;
            case 2:
                stepNumber += 1;
                stepSoundSkeleton3.Play();
                break;
            case 3:
                stepNumber = 0;
                stepSoundSkeleton4.Play();
                break;
        }
    }
}
