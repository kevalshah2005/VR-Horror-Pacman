using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using OVR;

public class PlayerMovement : MonoBehaviour
{
    public GameObject camera;
    public float speed;
    public Vector3 targetDirection = Vector3.zero;
    public CharacterController controller;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        var axis = OVRInput.Get(OVRInput.RawAxis2D.LThumbstick, OVRInput.Controller.LTouch);
        targetDirection = axis.x * camera.transform.right + axis.y * camera.transform.forward;
        controller.Move(targetDirection * speed * Time.deltaTime);
        // transform.position = Vector3.MoveTowards(transform.position, targetDirection + transform.position, Time.deltaTime * speed);
    }
}
