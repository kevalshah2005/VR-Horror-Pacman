using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NoVRMovement : MonoBehaviour
{
    public float speed;
    public CharacterController controller;
    Vector3 velocity;

    float gravity = -9.81f;

    // Start is called before the first frame update
    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
    }

    // Update is called once per frame
    void Update()
    {
        float x = Input.GetAxis("Horizontal");
        float z = Input.GetAxis("Vertical");

        Vector3 move = transform.right * x + transform.forward * z;

        controller.Move(move * speed * Time.deltaTime);

        velocity.y += gravity * Time.deltaTime;

        controller.Move(velocity);
    }
}
