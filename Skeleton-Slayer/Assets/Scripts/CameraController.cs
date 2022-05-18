using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
 public Transform target;
 public Vector3 offset;
 public bool useOffsetvalues;
 public float rotateSpeed;
 public Transform pivot;


 // Start is called before the first frame update
 void Start()
 {
  if (!useOffsetvalues)
  {
   offset = target.position - transform.position;
  }
  pivot.transform.position = target.transform.position;
  //pivot.transform.parent = target.transform;
  pivot.transform.parent = null;

  Cursor.lockState = CursorLockMode.Locked;
 }

 // Update is called once per frame
 void LateUpdate()
 {

  pivot.transform.position = target.transform.position;

  //Get the X position of the mouse & rotate the target
  float horizontal = Input.GetAxis("Mouse X") * rotateSpeed;
  pivot.Rotate(0, horizontal, 0);

  // Move the camera based on the current rotation of the target & the original offset
  float desiredYAngle = pivot.eulerAngles.y;
  float desiredXAngle = pivot.eulerAngles.x;
  Quaternion rotation = Quaternion.Euler(desiredXAngle, desiredYAngle, 0);
  transform.position = target.position - (rotation * offset);

  //transform.position = target.position - offset;

  if (transform.position.y < target.position.y)
  {
   transform.position = new Vector3(transform.position.x, target.position.y - .5f, transform.position.z);
  }
  transform.LookAt(target);
 }
}
