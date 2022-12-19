using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallController : MonoBehaviour
{
    public float upForce = 200f;

    private bool isDead = false;
    private Rigidbody2D rigidbody;
    private Animator animator;
    
    // Start is called before the first frame update
    void Start()
    {
        rigidbody = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (isDead == false)
        {
            if (Input.GetMouseButtonDown(0))
            {
                rigidbody.velocity = Vector2.zero;
                rigidbody.AddForce(new Vector2(0, upForce));
                animator.SetTrigger("Jump");
            }
        }
        
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        isDead = true;
        animator.SetTrigger("Die");
        GameController.instance.BallDied();
    }
}
