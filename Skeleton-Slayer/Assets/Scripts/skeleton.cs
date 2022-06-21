using UnityEngine;

public class skeleton : MonoBehaviour
{
    public Animator skeletonAnim;
    public Transform target;
    public float skeletonSpeed;
    bool enableAtc;
    int atkStep;
    public float lookRadius = 5f;

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
