using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class characterMovement : MonoBehaviour
{
    public float moveSpeed = 30f; // Adjust this value to control the movement speed.
    public float rotationSpeed = 5f;


    private Vector2 moveDirection;
    private Vector2 rotationDirection;

    private Rigidbody2D rb;

    private void Start()
    {
        
        rb = GetComponent<Rigidbody2D>();

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

            transform.rotation = rotation;

        }

    }

    private void FixedUpdate()
    {

        move(moveDirection);
        look(rotationDirection);

    }


}

