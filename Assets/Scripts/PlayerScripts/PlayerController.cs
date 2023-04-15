using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private PlayerData playerData = null;
    private int speed;
    private int turnSpeed;
    public DynamicJoystick dynamicJoystick;

    Rigidbody rb;
    Vector3 direction;

    private void Start()
    {
        GetNeededDatas();
    }

    void GetNeededDatas()
    {
        rb = GetComponent<Rigidbody>();
        speed = playerData.playerSpeed;
        turnSpeed = playerData.playerTurnSpeed;
    }
    private void FixedUpdate()
    {
        JoystickMovement();
    }
    public void JoystickMovement()
    {
        float horizontal = dynamicJoystick.Horizontal;
        float vertical = dynamicJoystick.Vertical;

        Vector3 addedPos = new Vector3(horizontal * speed, 0, vertical * speed);
        rb.velocity = addedPos;
        direction = Input.GetMouseButton(0) ? Vector3.forward * vertical + Vector3.right * horizontal : direction;
        transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(direction), turnSpeed * Time.deltaTime);
    }
}
