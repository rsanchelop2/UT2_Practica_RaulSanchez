using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float speed = 5f;
    public float jumpForce = 7f;
    public LayerMask grounLayer;
    public float rayLength = 1.2f;
    private Rigidbody2D rb;
    
    
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        Vector2 position = transform.position;
        position.x = position.x + Input.GetAxis("Horizontal") * speed * Time.deltaTime;
        position.y = position.y + Input.GetAxis("Vertical") * speed * Time.deltaTime;
        transform.position = position;

    }

    void FixedUpdate()
    {
        RaycastHit2D hit = Physics2D.Raycast(transform.position, Vector2.down, rayLength, grounLayer);

    }

    void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawLine(transform.position, transform.position + Vector3.down * rayLength);
    }
}
