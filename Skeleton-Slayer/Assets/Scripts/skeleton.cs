using UnityEngine;

public class skeleton : MonoBehaviour
{
    public Animator skeletonAnim;
    public Transform target;
    public float skeletonSpeed;
    bool enableAtc;
    public float lookRadius = 5f;
    int stepNumber;
    public AudioSource stepSoundSkeleton1;
    public AudioSource stepSoundSkeleton2;
    public AudioSource stepSoundSkeleton3;
    public AudioSource stepSoundSkeleton4;

    public void Start()
    {
        Vector3 positionInitial = transform.position;
        skeletonAnim = GetComponent<Animator>();
        enableAtc = true;
    }
    public void RotateSkeleton()
    {
        Vector3 dir = target.position - transform.position;
        transform.localRotation =
            Quaternion.Slerp(transform.localRotation,
                Quaternion.LookRotation(dir), 5 * Time.deltaTime);
    }
    public void MoveSkeleton()
    {
        float distance = Vector3.Distance(target.position, transform.position);
        if (distance <= lookRadius)
        {
            if ((target.position - transform.position).magnitude >= 2)
            {
                skeletonAnim.SetInteger("transition", 1);
                transform.Translate(Vector3.forward * skeletonSpeed * Time.deltaTime, Space.Self);
            }
            if ((target.position - transform.position).magnitude < 2)
            {
                skeletonAnim.SetInteger("transition", 0);
            }
        }
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

    public void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, lookRadius);
    }

    public void Update()
    {
        if (skeletonAnim.GetInteger("transition") != 4)
        {
            if (enableAtc)
            {
                RotateSkeleton();
                MoveSkeleton();
            }
        }
    }
    public void skeletonAtk()
    {
        if ((target.position - transform.position).magnitude < 10)
        {
            skeletonAnim.Play("Skeleton_Atk");
        }
    }

    public void FreezeSkeleton()
    {
        enableAtc = false;
    }
    public void UnFreezeSkeleton()
    {
        enableAtc = true;
    }
}
