using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LadderMovement : MonoBehaviour
{

    private float vertical;
    private float speed = 6f;
    private bool isLadder;
    private bool isClimbing;

    [SerializeField] private Rigidbody2D rb;


    // Update is called once per frame
    void Update()
    {
        vertical = Input.GetAxis("Vertical");

        if (isLadder && Mathf.Abs(vertical) >0f)
        {
            isClimbing = true;
        }
    }


    private void FixedUpdate() 
    {
       if (isClimbing) // hvis vi klatrer svever vi/ vi setter gravitasjon til 0
       {
        rb.gravityScale = 0f;
        rb.velocity = new Vector2(rb.velocity.x, vertical * speed);
       }
       else  //setter den til normal gravitasjon hvis vi ikke klatrer
       {
        rb.gravityScale = 3f;
       }        

    }

    private void  OnTriggerEnter2D(Collider2D collision)
    {
      if (collision.CompareTag("Ladder"))
      {
        isLadder = true;
        isClimbing = true;
      }


    }

       private void  OnTriggerExit2D(Collider2D collision)
    {
      if (collision.CompareTag("Ladder"))
      {
        isLadder = false;
        isClimbing = false;
      }


    }
}
