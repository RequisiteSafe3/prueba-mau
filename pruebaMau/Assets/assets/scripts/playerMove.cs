using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerMove : MonoBehaviour
{
    Rigidbody2D rb2D; /*rb2D stands for rigidbody2D*/

    public SpriteRenderer spriteR;
    public Animator animator;
    [SerializeField] private float runningSpeed; /*SerializeField is used for showing private variables in unity's inspector*/
    [SerializeField] private float maxSpeed;
    [SerializeField] private float runningMultiplier;
    [SerializeField] private float maxRunningSpeed;
    [SerializeField] private float jumpForce;

    private void Start() {
        rb2D = GetComponent<Rigidbody2D>();
    }

    private void Update() {
        if (Input.GetKeyDown(KeyCode.Space)) {
            rb2D.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
        }
    }
    
    private void FixedUpdate() {
        if (Input.GetKey(KeyCode.D)) {
            rb2D.AddForce(new Vector2(runningSpeed, 0) * Time.deltaTime);
            spriteR.flipX = false;
            animator.SetBool("walk", true); /* Animator */
            animator.SetBool("idle", false); /* Animator */
            if (Input.GetKey(KeyCode.W)) {
                rb2D.AddForce(new Vector2(runningSpeed * runningMultiplier, 0) * Time.deltaTime);
                animator.SetBool("run", true); /* Animator */
                animator.SetBool("walk", false); /* Animator */
                if (rb2D.velocity.magnitude >= maxRunningSpeed) {
                    rb2D.velocity = Vector2.ClampMagnitude(rb2D.velocity, maxRunningSpeed);}
            }
            else {
                if (rb2D.velocity.magnitude >= maxSpeed) {
                    rb2D.velocity = Vector2.ClampMagnitude(rb2D.velocity, maxSpeed);
                    animator.SetBool("walk", true); /* Animator */
                    animator.SetBool("run", false); /* Animator */
                }
            }
        }
        else if (Input.GetKey(KeyCode.A)) {
            rb2D.AddForce(new Vector2(-runningSpeed, 0) * Time.deltaTime);
            spriteR.flipX = true;
            animator.SetBool("walk", true); /* Animator */
            animator.SetBool("idle", false); /* Animator */
            if (Input.GetKey(KeyCode.W)) {
                rb2D.AddForce(new Vector2(-runningSpeed * runningMultiplier, 0) * Time.deltaTime);
                animator.SetBool("run", true); /* Animator */
                animator.SetBool("walk", false); /* Animator */
                if (rb2D.velocity.magnitude >= maxRunningSpeed) {
                    rb2D.velocity = Vector2.ClampMagnitude(rb2D.velocity, maxRunningSpeed);}
            }
            else {
                if (rb2D.velocity.magnitude >= maxSpeed) {
                    rb2D.velocity = Vector2.ClampMagnitude(rb2D.velocity, maxSpeed);
                    animator.SetBool("walk", true); /* Animator */
                    animator.SetBool("run", false); /* Animator */
                }
            }
        }
        else {
            animator.SetBool("idle", true); /* Animator */
            animator.SetBool("walk", false); /* Animator */
            animator.SetBool("run", false); /* Animator */
        }

    }
}
