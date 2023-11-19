using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class characterMovement : MonoBehaviour
{



    public float moveSpeed = 30f; // Adjust this value to control the movement speed.
    public float rotationSpeed = 5f;


    public GameObject feet, head;


    private Vector2 moveDirection;
    private Vector2 rotationDirection;

    private Rigidbody2D rb;
    private Animator animator;

    private void Start()
    {
        
        rb = GetComponent<Rigidbody2D>();

        animator = GetComponent<Animator>();


        if (feet == null)
        {

            feet = transform.Find("Feet").gameObject;

        }

        if (head == null)
        {

            head = transform.Find("Head").gameObject;

        }

    }

    private void OnMove(InputValue value)
    {

        moveDirection = value.Get<Vector2>().normalized;


    }

    private void OnLook(InputValue value)
    {

        rotationDirection = value.Get<Vector2>().normalized;



    }

    private void move(Vector2 directionIn)
    {

        if (!(directionIn.x == 0.0f && directionIn.y == 0.0f))
        {

            rb.AddForce(directionIn * moveSpeed);

            float angle = Mathf.Atan2(directionIn.y, directionIn.x) * Mathf.Rad2Deg + 90;

            // Create a rotation based on the angle.
            Quaternion rotation = Quaternion.Euler(new Vector3(0f, 0f, angle));

            // Apply the rotation to your character.
            //transform.rotation = Quaternion.Slerp(transform.rotation, rotation, rotationSpeed * Time.deltaTime);

            feet.transform.rotation = rotation;

        }


    }

    private void look(Vector2 directionIn)
    {

        if (!(directionIn.x == 0.0f && directionIn.y == 0.0f))
        {

            float angle = Mathf.Atan2(directionIn.y, directionIn.x) * Mathf.Rad2Deg + 90;

            // Create a rotation based on the angle.
            Quaternion rotation = Quaternion.Euler(new Vector3(0f, 0f, angle));

            // Apply the rotation to your character.
            //transform.rotation = Quaternion.Slerp(transform.rotation, rotation, rotationSpeed * Time.deltaTime);

            head.transform.rotation = rotation;

        }

    }

    private void FixedUpdate()
    {

        move(moveDirection);
        look(rotationDirection);

        animator.speed = (rb.velocity.magnitude / moveSpeed) * 40f;

    }



}

