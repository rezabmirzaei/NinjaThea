using UnityEngine;
public class PlayerMovement : MonoBehaviour
{

    public CharacterController2D controller;
    public Animator animator;
    public float runSpeed = 40f;

    float horizontalMove = 0f;
    bool jump = false;

    void Update()
    {

        horizontalMove = Input.GetAxisRaw("Horizontal") * runSpeed;

        animator.SetFloat("Speed", Mathf.Abs(horizontalMove));

        if (Input.GetButtonDown("Jump"))
        {
            jump = true;
            animator.SetBool("IsJumping", true);
        }

    }

    void FixedUpdate()
    {
        controller.Move(horizontalMove * Time.fixedDeltaTime, jump);
        jump = false;
    }

    public void OnLoanding()
    {
        animator.SetBool("IsJumping", false);
    }
}
