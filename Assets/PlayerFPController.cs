using UnityEngine;

public class PlayerFPController : MonoBehaviour
{
    public Rigidbody rb;
    public PlayerAttribute playerAttribute;
    Vector3 movement;
    float speedMultiplier = 1f;
    float h, v;
    void Start()
    {
    }

    void FixedUpdate()
    {
        Move();
    }
    void Update()
    {
        h = Input.GetAxisRaw("Horizontal");
        v = Input.GetAxisRaw("Vertical");
    }

    void Move()
    {
        movement = transform.forward * v + transform.right * h;

        movement = movement.normalized * speedMultiplier * playerAttribute.speed * Time.fixedDeltaTime;

        rb.MovePosition(transform.position + movement);
    }
}
