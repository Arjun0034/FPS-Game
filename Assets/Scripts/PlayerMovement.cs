
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{

    public float speed = 15f;
    public float jumpHeight = 0.5f;
    public float groundDistance;
    public float gravity = -9.81f;

    public CharacterController characterController;
    public Transform groundCheck;
    public LayerMask groundMask;

    public bool isGrounded;

    Vector3 velocity;

  

    // Start is called before the first frame update
    void Start()
    {
        //making sure my mouse doesn't leave the game window
        Cursor.lockState = CursorLockMode.Locked;
    }

    // Update is called once per frame
    void Update()
    {
        isGrounded = Physics.CheckSphere(groundCheck.position, groundDistance, groundMask);

        if (isGrounded && velocity.y < 0)
        {
            velocity.y = -2f;
        }

        float z =  Input.GetAxis("Vertical");
        float x = Input.GetAxis("Horizontal");

        Vector3 move = transform.right * x + transform.forward * z ;
        characterController.Move(move * speed * Time.deltaTime);


        velocity.y += gravity * Time.deltaTime;
        characterController.Move(velocity * Time.deltaTime);

        if (Input.GetButtonDown("Jump") && isGrounded)
        {
            velocity.y = Mathf.Sqrt(jumpHeight * -2 * gravity);
        }

     
    }
}
