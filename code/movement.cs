using System;
using UnityEngine;
using UnityEngine.UIElements;

public class Movement : MonoBehaviour
{
    public float step = 1f;
    public float speed = 5f;
    private CharacterController characterController;
    private Rigidbody rigidbody;
    private Vector3 movementVector;

    void Start()
    {
        characterController = GetComponent<CharacterController>();
        rigidbody = GetComponent<Rigidbody>();
    }

    void Update()
    {
        RotateMouse();

        movementVector = Vector3.zero;

        if (Input.GetKey(KeyCode.W))
        {
            movementVector += Vector3.right;
            movementVector += Vector3.forward;
        }
        if (Input.GetKey(KeyCode.A))
        {
            movementVector += Vector3.left;
            movementVector += Vector3.forward;
        }
        if (Input.GetKey(KeyCode.S))
        {
            movementVector += Vector3.back;
            movementVector += Vector3.left;
        }
        if (Input.GetKey(KeyCode.D))
        {
            movementVector += Vector3.right;
            movementVector += Vector3.back;
        }

        movementVector = movementVector.normalized * speed;
    }

    void RotateMouse()
    {
        Plane plane = new Plane(Vector3.up, transform.position);
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

        if (plane.Raycast(ray, out float distance))
        {
            Vector3 target = ray.GetPoint(distance);
            transform.LookAt(target);
        }
    }

    void FixedUpdate()
    {
        var frameMovement = movementVector * Time.fixedDeltaTime;
        transform.position += frameMovement;
        movementVector -= frameMovement;
    }
}