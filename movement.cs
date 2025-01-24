using UnityEngine;

public class IsometricMovement3D : MonoBehaviour
{
    public float speed = 5f;
    private CharacterController characterController;
    private Vector3 movement;

    void Start()
    {
        characterController = GetComponent<CharacterController>();
    }

    void Update()
    {
        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");

        Vector3 forward = Camera.main.transform.forward;
        Vector3 right = Camera.main.transform.right;

        forward.y = 0;
        right.y = 0;

        forward.Normalize();
        right.Normalize();

        movement = forward * vertical + right * horizontal;
        movement = movement.normalized * speed;

        if (movement != Vector3.zero)
        {
            Quaternion toRotation = Quaternion.LookRotation(movement, Vector3.up);
            transform.rotation = Quaternion.RotateTowards(transform.rotation, toRotation, 720 * Time.deltaTime);
        }
    }

    void FixedUpdate()
    {
        characterController.Move(movement * Time.deltaTime);
    }
}
