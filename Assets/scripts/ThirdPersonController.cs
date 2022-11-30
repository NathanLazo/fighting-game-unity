using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThirdPersonController : MonoBehaviour
{
    // Character components
    public CharacterController controller;
    private Animator animator;

    // Movement variables
    Vector3 move;
    float x;
    float z;
    Vector3 moveDir;
    public float speed = 6f;
    public float turnSmoothTime = 0.1f;
    public float turnSmoothVelocity;

    public static bool isPunching;
    public static bool isPunchingSpecialAttack;
    public static bool specialAttackCooldown = false;

    // Cameras
    public Transform cam;


    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        animator = GetComponent<Animator>();
    }

    void Update()
    {
        SetGravity();
        SetMovement();
        SetAnimations();
    }



    void SetGravity()
    {
        float gravity = -9.81f * Time.deltaTime;
        Vector3 moveY = new Vector3(0, gravity, 0);
        controller.Move(moveY);
    }

    void SetMovement()
    {
        //Get axis input
        x = Input.GetAxisRaw("Horizontal");
        z = Input.GetAxisRaw("Vertical");

        //Set movement direction
        move = new Vector3(x, 0f, z);

        if (move.magnitude >= 0.1f)
        {
            float targetAngle = Mathf.Atan2(move.x, move.z) * Mathf.Rad2Deg + cam.eulerAngles.y;
            float angle = Mathf.SmoothDampAngle(transform.eulerAngles.y, targetAngle, ref turnSmoothVelocity, turnSmoothTime);

            transform.rotation = Quaternion.Euler(0f, angle, 0f);


            moveDir = Quaternion.Euler(0f, targetAngle, 0f) * Vector3.forward;
            controller.Move(moveDir.normalized * speed * Time.deltaTime);


            // Dash mechanic
            if (Input.GetKeyDown("space"))
            {
                animator.SetTrigger("dash");
            }


            if (
                animator.GetCurrentAnimatorStateInfo(0).IsTag("damage") ||
                animator.GetCurrentAnimatorStateInfo(0).IsTag("special-attack") ||
                animator.GetCurrentAnimatorStateInfo(0).IsTag("defense")
                )
            {
                speed = 1.5f;
            }
            else if (!Input.GetKey(KeyCode.LeftShift))
            {
                speed = 6f;
            }
            else if (Input.GetKey(KeyCode.LeftShift))
            {
                speed = 12f;
            }
        }


    }


    void SetAnimations()
    {

        if (!animator.GetCurrentAnimatorStateInfo(0).IsTag("damage"))
        {

            //If left mouse button is pressed
            if (Input.GetMouseButtonDown(0))
            {
                animator.SetTrigger("damage");
                isPunching = true;
            }
        }


        if (
            !animator.GetCurrentAnimatorStateInfo(0).IsTag("special-attack") &&
            !specialAttackCooldown
        )
        {

            //If "E" button is pressed
            if (Input.GetKey(KeyCode.E))
            {
                animator.SetTrigger("special-attack");
                isPunchingSpecialAttack = true;
                StartCoroutine(SpecialAttackCooldown());
            }
        }

        //player defense
        if (Input.GetMouseButton(1))
        {
            animator.SetBool("defense", true);
        }
        else
        {
            animator.SetBool("defense", false);
        }


        //if player moves
        if (move.magnitude >= 0.1f)
        {
            animator.SetBool("walk", true);
        }
        else
        {
            animator.SetBool("walk", false);
        }

        //if shift is pressed
        if (Input.GetKey(KeyCode.LeftShift))
        {
            animator.SetBool("run", true);
        }
        else
        {
            animator.SetBool("run", false);
        }
    }


    IEnumerator SpecialAttackCooldown()
    {
        specialAttackCooldown = true;
        yield return new WaitForSeconds(5f);
        specialAttackCooldown = false;
    }

}
