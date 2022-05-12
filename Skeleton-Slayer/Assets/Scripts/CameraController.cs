using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    public Transform target;
    public Vector3 offset;
    public bool useOffsetvalues;
    public float rotateSpeed;

    // Start is called before the first frame update
    void Start()
    {
        if(!useOffsetvalues)
        {
            offset = target.position - transform.position;
        }
        
    }

    // Update is called once per frame
    void Update()
    {
        float horizontal = Input.GetAxis("Mouse X") * rotateSpeed;
        target.Rotate(0, horizontal,0);
        
        float vertical = Input.GetAxis("Mouse Y") * rotateSpeed;
        target.Rotate(-vertical,0,0);


        float desiredYAngle = target.eulerAngles.y;
        float desiredXAngle = target.eulerAngles.x;

        Quaternion rotation = Quaternion.Euler(desiredXAngle,desiredYAngle,0);
        transform.position = target.position - (rotation * offset);

        //transform.position = target.position - offset;

        transform.LookAt(target);
    }
}
