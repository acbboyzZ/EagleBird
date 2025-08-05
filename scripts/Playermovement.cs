using UnityEngine;



public class Playermovement : MonoBehaviour
{
    private float jumpForce = 10f;
    public float moveSpeed = 5f;
private Rigidbody2D rb;
private Vector2 movement;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        movement.x = Input.GetAxisRaw("Horizontal");
        movement.y = Input.GetAxisRaw("Vertical");

        movement = movement.normalized;

        if (Input.GetKeyDown(KeyCode.Space)) {
            Jump();
        }
    }
    void FixedUpdate()
    {
        rb.linearVelocity = new Vector2(movement.x * moveSpeed, rb.linearVelocity.y);
        //rb.MovePosition(rb.position + movement * moveSpeed * Time.deltaTime);
    }
    
    public void Jump()
    {
        rb.linearVelocity = new Vector2(rb.linearVelocity.x, jumpForce);
    }
}
