using UnityEngine;
using System.Collections;
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
    // respawn
    public Transform respawnPoint;
    public GameObject mainMenu;
    public GameObject youDie;
    public GameObject youDieRawImage;
    public GameObject hud;
    public GameObject cpWarning;
    // Start is called before the first frame update
    void Start()
    {
        controller = GetComponent<CharacterController>();
    }
    [System.Obsolete]
    void Update()
    {
        if (mainMenu.active == false)
        {
            if (anim.GetInteger("transition") != 4)
            {
                if (knockBackCounter <= 0)
                {

                    float yStore = moveDirection.y;
                    float zDirection = Input.GetAxis("Vertical");
                    moveDirection = new Vector3(0.0f, 0.0f, zDirection);
                    moveDirection = moveDirection.normalized * moveSpeed; // normaliza a velocidade
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
                //animação
                if (Input.GetAxis("Horizontal") != 0 || Input.GetAxis("Vertical") != 0)
                {
                    anim.SetInteger("transition", 1);
                }
                else
                {
                    anim.SetInteger("transition", 0);
                }
                anim.SetBool("isGrounded", controller.isGrounded);


            }
            else
            {
                StartCoroutine(resetRespawn());

            }
        }
    }
    public void SetSpawnPoint(Transform newPosition)
    {
        if (newPosition != respawnPoint)
        {
            StartCoroutine(checkpointWarning());
            respawnPoint = newPosition;
        }
    }
    public IEnumerator resetRespawn()
    {
        youDie.SetActive(true);
        youDieRawImage.SetActive(true);
        hud.SetActive(true);
        yield return new WaitForSeconds(4f);
        youDie.SetActive(false);
        youDieRawImage.SetActive(false);
        hud.SetActive(false);
        mainMenu.SetActive(true);
        controller.transform.position = respawnPoint.transform.position;
        anim.SetInteger("transition", 0);
        FindObjectOfType<HealthManager>().HealPlayer(9999);
    }
    public IEnumerator checkpointWarning()
    {
        cpWarning.SetActive(true);
        yield return new WaitForSeconds(1f);
        cpWarning.SetActive(false);
    }
    public void Knockback(Vector3 direction, float knockBackForce)
    {
        knockBackCounter = knockBackTime;
        moveDirection = direction * knockBackForce;
        moveDirection.y = knockBackForce;
    }
}