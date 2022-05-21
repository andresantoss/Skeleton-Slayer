using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
 public float moveSpeed;

 public float jumpForce;
 public CharacterController controller;

 private Vector3 moveDirection;
 public float gravityScale;

 public Animator anim; 
 public Transform pivot;
 public float rotateSpeeed;

 public GameObject playerModel;

 public float knockBackForce;
 public float knockBackTime;
 private float knockBackCounter;
 // Start is called before the first frame update
 void Start()
 {
  //theRB = GetComponent<Rigidbody>();
  controller = GetComponent<CharacterController>();
 }

 // Update is called once per frame
 void Update()
    {
        if(knockBackCounter <=0)
        {
            float yStore = moveDirection.y;
            moveDirection = ((transform.forward * Input.GetAxis("Vertical")) + (transform.right * Input.GetAxis("Horizontal")));
            moveDirection = moveDirection.normalized * moveSpeed;
            moveDirection.y = yStore;

            if (controller.isGrounded)
            {
                moveDirection.y = 0f;
                if (Input.GetButtonDown("Jump"))
                {
                    moveDirection.y = jumpForce;
                }
            }
        } else
        {
            knockBackCounter -= Time.deltaTime;
        }
    
        moveDirection.y = moveDirection.y + (Physics.gravity.y * gravityScale * Time.deltaTime); //gravidade
        controller.Move(moveDirection * Time.deltaTime);

        //Move player different directions based on camera look
        if (Input.GetAxis("Horizontal") != 0 || Input.GetAxis("Vertical") != 0)
        {
        transform.rotation = Quaternion.Euler(0f, pivot.rotation.eulerAngles.y, 0f);
        Quaternion newRotation = Quaternion.LookRotation(new Vector3(moveDirection.x, 0f, moveDirection.z));
        playerModel.transform.rotation = Quaternion.Slerp(playerModel.transform.rotation, newRotation, rotateSpeeed * Time.deltaTime);
        }
        anim.SetFloat ("speed", Mathf.Abs (Input.GetAxis ("Horizontal")));
        anim.SetFloat ("speed", Mathf.Abs (Input.GetAxis ("Vertical")));
        anim.SetBool("isGrounded", controller.isGrounded);
    }

    public void Knockback(Vector3 direction)
    {
        knockBackCounter = knockBackTime;

        moveDirection = direction * knockBackForce;
        moveDirection.y = knockBackForce;
    }
}
