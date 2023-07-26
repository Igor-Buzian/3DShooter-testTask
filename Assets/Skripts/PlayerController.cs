using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [Header("Components")]
    [SerializeField] Transform groundChecker;
    private Animator animator;
    private CharacterController characterController;

    [Header("values")]
    public float rotationspeed = 10f;
    public float speed = 5f;
    public float runSpeed = 10f;
    public float JumpFose = 7f;
    public LayerMask groundLayer;

    private bool isJumping;
    private float verticalVelocity;

    void Start()
    {
        animator = GetComponent<Animator>();
        characterController = GetComponentInChildren<CharacterController>();

    }

    void Update()
    {
        float horizontalInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");

        bool isRunning = Input.GetKey(KeyCode.LeftShift); // Проверяем, нажата ли клавиша Shift

        // Рассчитываем движение с учетом выбранной скорости (обычной или беговой)
        float currentSpeed = isRunning ? runSpeed : speed;

        Vector3 movement = transform.TransformDirection(new Vector3(horizontalInput, 0, verticalInput)) * currentSpeed;

        animator.SetFloat("speed", Vector3.ClampMagnitude(movement, 1).magnitude);
        Vector3 moveDir = Vector3.ClampMagnitude(movement, 1) * currentSpeed;
        characterController.SimpleMove(moveDir);

        if (movement.magnitude > Mathf.Abs(0.1f))
        {
            transform.rotation = Quaternion.Lerp(transform.rotation, Quaternion.LookRotation(movement), Time.deltaTime * rotationspeed);
        }

        if (Input.GetKeyDown(KeyCode.Space) && Physics.CheckSphere(groundChecker.position, .3f, groundLayer))
        {
            StartJump();
        }

        if (isJumping)
        {
            HandleJump();
        }

        if (Physics.CheckSphere(groundChecker.position, .3f, groundLayer))
        {
            animator.SetBool("IsInAir", false);

        }
        else
        {
            animator.SetBool("IsInAir", true);
        }
    }

    void StartJump()
    {
        isJumping = true;
        verticalVelocity = Mathf.Sqrt(JumpFose * 2f * -Physics.gravity.y);
        animator.SetTrigger("Jump");
    }

    void HandleJump()
    {
        verticalVelocity += Physics.gravity.y * Time.deltaTime;
        characterController.Move(Vector3.up * verticalVelocity * Time.deltaTime);

        if (characterController.isGrounded)
        {
            isJumping = false;
            verticalVelocity = 0f;
        }
    }
}


/*using UnityEngine;
using System.Collections;
using System.Collections.Generic;


public class PlayerController : MonoBehaviour
{
    [Header("Components")]
    [SerializeField] Transform groundChecker;
    private Animator animator;
    //private Rigidbody rb;
    public LayerMask groundLayer;
    private CharacterController characterController;

    [Header("values")]
    public float rotationspeed = 10f;
    public float speed = 5f;
    public float JumpFose = 7f;
    public float Sensitivity = 1f;
    private bool isLanding;


    void Start()
    {
        animator = GetComponent<Animator>();
        //rb = GetComponent<Rigidbody>();
        characterController = GetComponentInChildren<CharacterController>();
    }
    void Update()
    {
        float horizontalInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");
        Vector3 movement = transform.TransformDirection(new Vector3(horizontalInput, 0, verticalInput)) * speed;

        animator.SetFloat("speed", Vector3.ClampMagnitude(movement, 1).magnitude);
        Vector3 moveDir = Vector3.ClampMagnitude(movement, 1) * speed;
        //rb.velocity = new Vector3(moveDir.x, rb.velocity.y, moveDir.z);
        //rb.angularVelocity = Vector3.zero;

        characterController.SimpleMove(movement);

        // Поворот в сторону мыши
        if (Camera.main != null)
        {
            Plane playerPlane = new Plane(Vector3.up, transform.position);
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            float hitDist = 0.0f;

            if (playerPlane.Raycast(ray, out hitDist))
            {
                Vector3 targetPoint = ray.GetPoint(hitDist);
                Quaternion targetRotation = Quaternion.LookRotation(targetPoint - transform.position);
                transform.rotation = Quaternion.RotateTowards(transform.rotation, targetRotation, 100 * Time.deltaTime);
            }

            if (Input.GetKeyDown(KeyCode.Space))
            {
                Jump();
            }

            if (Physics.CheckSphere(groundChecker.position, .3f, groundLayer))
            {
                //StartCoroutine(SpeedOff());
                animator.SetBool("IsInAir", false);
            }
            else
            {
                animator.SetBool("IsInAir", true);
                isLanding = true;
            }
        }

        void Jump()
        {
            if (Physics.CheckSphere(groundChecker.position, .3f, groundLayer))
            {
                animator.SetTrigger("Jump");
                characterController.Move(Vector3.up * JumpFose * Time.deltaTime);
            }
        }*/

        /*    IEnumerator SpeedOff() //использую для того, чтобы отключить возможность передвижения во время анимации
            {
                if (isLanding == true)
                {
                    speed = 0f;
                    yield return new WaitForSeconds(1);
                    speed = 5f;
                }

            }*/
 
