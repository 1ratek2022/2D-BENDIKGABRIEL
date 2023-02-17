using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerMovementNew : MonoBehaviour

{
private float horizontal;
public float speed = 8f;
public float jumpingPower = 20f;
private bool isFacingRight = true;
private bool crouch;

private bool canDash = true;
private bool isDashing;
public float dashingPower = 24f;
private float dashingTime = 0.2f;
private float dashingCooldown = 1f;

[SerializeField] private Rigidbody2D rb;
[SerializeField] private Collider2D standingCollider;
[SerializeField] private Transform groundCheck;
[SerializeField] private LayerMask groundLayer;
[SerializeField] private TrailRenderer tr;
  

    // Update is called once per frame
    void Update()

    
    {
        if (isDashing)
        {
         return;
        }
  horizontal = Input.GetAxisRaw("Horizontal");

  if (Input.GetButtonDown("Jump") && IsGrounded())
  {
     rb.velocity = new Vector2(rb.velocity.x, jumpingPower);
  }
  // hvis vi slepper hoppeknapp og karateren fortsatt beveger seg oppover, så ganger vi vertical/lodrett  hastighet med 0.5
 if (Input.GetButtonDown("Jump") && rb.velocity.y > 0f)
 {
    rb.velocity = new Vector2(rb.velocity.x, rb.velocity.y * 0.5f);
 }

    //input for dashing

     if (Input.GetKeyDown(KeyCode.LeftShift) && canDash)
     {
      StartCoroutine(Dash());

     }

  Flip();

  
  
  
    }


    

      private void FixedUpdate()
      
      {
          if (isDashing)
         {
           return;
         }
        rb.velocity = new Vector2(horizontal * speed, rb.velocity.y);
      }

     private bool IsGrounded()
     {
         return Physics2D.OverlapCircle( groundCheck.position, 0.2f, groundLayer);
     }

      private void Flip()
      {
        if (isFacingRight && horizontal < 0f || !isFacingRight && horizontal > 0f)
         {
            isFacingRight = !isFacingRight;
            Vector3 localScale = transform.localScale;
            localScale.x *= -1f;
            transform.localScale = localScale;
         }
      }

      private IEnumerator Dash()
      {
         canDash = false;
         isDashing = true;
         float originalGravity = rb.gravityScale;
         rb.gravityScale = 0f;
         rb.velocity = new Vector2(transform.localScale.x * dashingPower, 0f);
          
          //enable trail for dashing / skru på trail for karakter / det lar oss dashe i forhold til trailen
          tr.emitting = true;
          yield return new WaitForSeconds(dashingTime);
          tr.emitting = false;
          rb.gravityScale = originalGravity;
          isDashing = false;
          yield return new WaitForSeconds(dashingCooldown);
          canDash = true;
      }
}
