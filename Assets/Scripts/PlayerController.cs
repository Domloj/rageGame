using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float speed;     // Prędkość poruszania edytowalna w Unity
    public float jumpForce;

    private Rigidbody2D body;
    private float xInput;
    private float yInput;
    private bool grounded;  // Czy stoi na platformie
    private Animator animator;

    void Start()
    {
        body = GetComponent<Rigidbody2D>();
        animator = GetComponentInChildren<Animator>();
    }

    void Update()
    {
        xInput = Input.GetAxis("Horizontal");   // A, D
        yInput = Input.GetAxis("Vertical");     // W, S

        // obrót postaci lewo-prawo
        if (xInput > 0.01f)
            transform.localScale = new Vector3(1f, 1f, 1);
        else if (xInput < -0.01f)
            transform.localScale = new Vector3(-1f, 1f, 1);

        // Skakanie W
        if (Input.GetKey(KeyCode.W) && grounded)
            Jump();

        // Opadanie S
        if (Input.GetKey(KeyCode.S) && grounded == false)
        {
            body.gravityScale = 7;
        }
        else body.gravityScale = 2;

        // animacje
        animator.SetBool("isRunning", xInput != 0);
        animator.SetBool("grounded", grounded);

    }

    void FixedUpdate()
    {
        // Poruszanie na boki
        body.linearVelocity = new Vector2(xInput * speed, body.linearVelocity.y);
    }

    void Jump()
    {
        animator.SetTrigger("takeOf");
        body.linearVelocity = new Vector2(body.linearVelocity.x, jumpForce);
        grounded = false;
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Platform")
            grounded = true;
    }
}
