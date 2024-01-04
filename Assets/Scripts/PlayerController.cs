using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private FloatingJoystick _joystick;
    [SerializeField] private Rigidbody2D rb;
    [SerializeField] private float speed = 5f;

    private Vector2 movement;
    void Update()
    {
        //ίκωξ οκ
        movement = _joystick.Direction * speed;

#if UNITY_EDITOR
        float horizontalInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");
        movement = new Vector2(horizontalInput, verticalInput) * speed;
#endif

        rb.velocity = movement;
    }
}
