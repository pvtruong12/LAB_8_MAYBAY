using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VienDan : MonoBehaviour
{
    private Rigidbody2D rb;
    public float shootMove = 2f;
    public float dame = 1f;
    public Vector2 vector;
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void FixedUpdate()
    {
        rb.velocity = vector.normalized * shootMove;
    }
    void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag("GioiHan"))
        {
            Destroy(gameObject);
        }
        if(collision.CompareTag("ThienThach"))
        {
            ThienThach tt = collision.gameObject.GetComponent<ThienThach>();
            if(tt != null)
            {
                tt.TakeDame(dame);
            }
            Destroy(gameObject);
        }
    }
}
