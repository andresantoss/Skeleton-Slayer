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
    private float rot;
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
        if (knockBackCounter <= 0)
        {

            //moveDirection = ((transform.forward * Input.GetAxis("Vertical")) + (transform.right * Input.GetAxis("Horizontal")));
            //moveDirection = moveDirection.normalized * moveSpeed;
            //moveDirection.y = yStore;
            float yStore = moveDirection.y;
            float xDirection = Input.GetAxis("Horizontal");
            float zDirection = Input.GetAxis("Vertical");
            moveDirection = new Vector3(xDirection, 0.0f, zDirection);
            moveDirection = moveDirection.normalized * moveSpeed;
            moveDirection.y = yStore;
            moveDirection = transform.TransformDirection(moveDirection);
            rot += Input.GetAxis("Horizontal") * rotateSpeeed * Time.deltaTime;
            transform.eulerAngles = new Vector3(0f, rot, 0f);

            if (controller.isGrounded)
            {
                moveDirection.y = 0f;
                transform.position += transform.forward * moveSpeed;
                if (Input.GetButtonDown("Jump"))
                {
                    moveDirection.y = jumpForce;
                }
            }
        }
        else
        {
            knockBackCounter -= Time.deltaTime;
        }
        moveDirection.y = moveDirection.y + (Physics.gravity.y * gravityScale * Time.deltaTime); //gravidade
        controller.Move(moveDirection * Time.deltaTime);

        //Move player different directions based on camera look
        if (Input.GetAxis("Horizontal") != 0 || Input.GetAxis("Vertical") != 0)
        {
            anim.SetInteger("speed", 1);
            /*             transform.rotation = Quaternion.Euler(0f, pivot.rotation.eulerAngles.y, 0f);
                        Quaternion newRotation = Quaternion.LookRotation(new Vector3(moveDirection.x, 0f, moveDirection.z));
                        transform.rotation = Quaternion.Slerp(transform.rotation, newRotation, rotateSpeeed * Time.deltaTime); */
        }
        else
        {
            anim.SetInteger("speed", 0);
        }


        anim.SetBool("isGrounded", controller.isGrounded);
    }

    public void Knockback(Vector3 direction)
    {
        knockBackCounter = knockBackTime;

        moveDirection = direction * knockBackForce;
        moveDirection.y = knockBackForce;
    }
}