using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThirdPersonController : MonoBehaviour
{

    public CharacterController controller;

    public Vector3 moveDir;

    public float speed = 6f;
    public float jumpHeight = 3f;

    public float turnSmoothTime = 0.1f;
    float turnSmoothVelocity;

    public Transform cam;

    public bool isGrounded = true;

    public float fallVelocity = 0f;

    public float gravity = 9.81f;

    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
    }

    void Update()
    {
        SetMovement();
        SetGravity();
    }

    void SetGravity()
    {
        if (isGrounded)
        {
            fallVelocity = -gravity * Time.deltaTime;
            moveDir.y = fallVelocity;
        }
        else
        {
            fallVelocity -= gravity * Time.deltaTime;
            moveDir.y = fallVelocity;
        }
    }

    void SetMovement()
    {
        float x = Input.GetAxisRaw("Horizontal");
        float z = Input.GetAxisRaw("Vertical");
        Vector3 move = new Vector3(x, 0f, z);

        if (move.magnitude >= 0.1f)
        {
            float targetAngle = Mathf.Atan2(move.x, move.z) * Mathf.Rad2Deg + cam.eulerAngles.y;
            float angle = Mathf.SmoothDampAngle(transform.eulerAngles.y, targetAngle, ref turnSmoothVelocity, turnSmoothTime);

            transform.rotation = Quaternion.Euler(0f, angle, 0f);


            moveDir = Quaternion.Euler(0f, targetAngle, 0f) * Vector3.forward;
            controller.Move(moveDir.normalized * speed * Time.deltaTime);

            if (Input.GetKeyDown("space"))
            {
                Debug.Log("Dash animation");
                //move controller forward
                controller.Move(moveDir.normalized * speed * Time.deltaTime * 16);
            }
        }

    }
}
